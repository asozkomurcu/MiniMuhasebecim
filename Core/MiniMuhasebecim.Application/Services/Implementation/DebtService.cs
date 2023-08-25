using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using MiniMuhasebecim.Application.Behaviors;
using MiniMuhasebecim.Application.Exceptions;
using MiniMuhasebecim.Application.Models.Dtos.DebtDtos;
using MiniMuhasebecim.Application.Models.RequestModels.DebtRM;
using MiniMuhasebecim.Application.Services.Abstraction;
using MiniMuhasebecim.Application.Validators.OrdersValidators;
using MiniMuhasebecim.Application.Wrapper;
using MiniMuhasebecim.Domain.Entities;
using MiniMuhasebecim.Domain.UWork;

namespace MiniMuhasebecim.Application.Services.Implementation
{
    public class DebtService : IDebtService
    {
        private readonly IMapper _mapper;
        private readonly IUnitWork _uWork;

        public DebtService(IMapper mapper, IUnitWork uWork)
        {
            _mapper = mapper;
            _uWork = uWork;
        }

        public async Task<Result<List<DebtDto>>> GetAllDebts()
        {
            var result = new Result<List<DebtDto>>();

            var debtEntites = await _uWork.GetRepository<Debt>().GetAllAsync();

            var debtDtos = await debtEntites.ProjectTo<DebtDto>(_mapper.ConfigurationProvider).ToListAsync();
            result.Data = debtDtos;
            _uWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(GetOrderByIdValidator))]
        public async Task<Result<DebtDto>> GetDebtById(GetDebtByIdVM getDebtByIdVM)
        {
            var result = new Result<DebtDto>();

            var debtExists = await _uWork.GetRepository<Debt>().AnyAsync(x => x.Id == getDebtByIdVM.Id);
            if (!debtExists)
            {
                throw new NotFoundException($"{getDebtByIdVM.Id} numaralı borç bilgisi bulunamadı.");
            }

            var debtEntity = await _uWork.GetRepository<Debt>().GetById(getDebtByIdVM.Id);

            var debtDto = _mapper.Map<Debt, DebtDto>(debtEntity);

            result.Data = debtDto;
            _uWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(UpdateOrderValidator))]
        public async Task<Result<int>> CreateDebts(CreateDebtVM createDebtVM)
        {
            var result = new Result<int>();

            //Kayıt sırasında girilen WholesalerId silimiş mi?
            //var debtExists = await _uWork.GetRepository<Debt>().AnyAsync(x => x.Wholesaler.IsDeleted == true);
            //if (!debtExists)
            //{
            //    throw new NotFoundException($"{createDebtVM.WholesalerId} numaralı tedarikçi bulunamadı.");
            //}

            var debtEntity = _mapper.Map<CreateDebtVM, Debt>(createDebtVM);

            _uWork.GetRepository<Debt>().Add(debtEntity);
            await _uWork.CommitAsync();

            result.Data = debtEntity.Id;
            _uWork.Dispose();
            return result;
        }

        [ValidationBehavior(typeof(GetOrderByIdValidator))]
        public async Task<Result<int>> UpdateDebts(UpdateDebtVM updateDebtVM)
        {
            var result = new Result<int>();

            var existsDebt = await _uWork.GetRepository<Debt>().GetById(updateDebtVM.Id);
            if (existsDebt is null)
            {
                throw new Exception($"{updateDebtVM.Id} numaralı borç bilgisi bulunamadı.");
            }


            var updatedDebt = _mapper.Map(updateDebtVM, existsDebt);

            _uWork.GetRepository<Debt>().Update(updatedDebt);
            await _uWork.CommitAsync();

            result.Data = updatedDebt.Id;
            _uWork.Dispose();
            return result;
        }


    }
}
