using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MiniMuhasebecim.Application.Behaviors;
using MiniMuhasebecim.Application.Exceptions;
using MiniMuhasebecim.Application.Models.Dtos.CustomerDtos;
using MiniMuhasebecim.Application.Models.RequestModels.CustomerRM;
using MiniMuhasebecim.Application.Services.Abstraction;
using MiniMuhasebecim.Application.Validators.CustomersValidators;
using MiniMuhasebecim.Application.Wrapper;
using MiniMuhasebecim.Domain.Entities;
using MiniMuhasebecim.Domain.UWork;

namespace MiniMuhasebecim.Application.Services.Implementation
{
    public class CustomerService : ICustomerService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _uWork;
        public CustomerService(IMapper mapper, IUnitWork uWork)
        {
            _mapper = mapper;
            _uWork = uWork;
        }

        public async Task<Result<List<CustomerDto>>> GetAllCustomers()
        {
            var result = new Result<List<CustomerDto>>();

            var customerEntites = await _uWork.GetRepository<Customer>().GetAllAsync();
            var customerDtos = await customerEntites.ProjectTo<CustomerDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            result.Data = customerDtos;
            _uWork.Dispose();
            return result;
        }


        [ValidationBehavior(typeof(GetCustomerByIdValidator))]
        public async Task<Result<CustomerDto>> GetCustomerById(GetCustomerByIdVM getCustomerByIdVM)
        {
            var result = new Result<CustomerDto>();

            var customerExists = await _uWork.GetRepository<Customer>().AnyAsync(x => x.Id == getCustomerByIdVM.Id);
            if (!customerExists)
            {
                throw new NotFoundException($"{getCustomerByIdVM.Id} numaralı kullanıcı bulunamadı.");
            }

            var customerEntity = await _uWork.GetRepository<Customer>().GetById(getCustomerByIdVM.Id);

            var customerDto = _mapper.Map<Customer, CustomerDto>(customerEntity);

            result.Data = customerDto;
            _uWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(UpdateCustomerValidator))]
        public async Task<Result<bool>> UpdateCustomer(UpdateCustomerVM updateCustomerVM)
        {
            var result = new Result<bool>();
            
            var customerEntites = await _uWork.GetRepository<Customer>().GetSingleByFilterAsync(x => x.Id == updateCustomerVM.Id, "Account");
            if (customerEntites == null)
            {
                throw new NotFoundException($"{updateCustomerVM.Id} numaralı kullanıcı bulunamadı.");
            }

            //Kullanıcı rol bilgisi değiştirme
            if ((updateCustomerVM.RoleName).ToLower() == "admin")
            {
                int roles = (int)Roles.Admin;
                customerEntites.Account.Role = (Roles)roles;

            }
            else if (updateCustomerVM.RoleName.ToLower() == "user")
            {
                int roles = (int)Roles.User;
                customerEntites.Account.Role = (Roles)roles;
            }
            else
            {
                throw new NotFoundException($"Girmiş olduğunuz rol bilgisi hatalıdır.");
            }
            

            
            _mapper.Map(updateCustomerVM, customerEntites);

            _uWork.GetRepository<Customer>().Update(customerEntites);

            result.Data = await _uWork.CommitAsync();
            return result;
        }
    }
}
