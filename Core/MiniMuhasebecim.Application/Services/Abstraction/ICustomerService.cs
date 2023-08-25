using MiniMuhasebecim.Application.Models.Dtos.CustomerDtos;
using MiniMuhasebecim.Application.Models.RequestModels.CustomerRM;
using MiniMuhasebecim.Application.Wrapper;

namespace MiniMuhasebecim.Application.Services.Abstraction
{
    public interface ICustomerService
    {
        Task<Result<List<CustomerDto>>> GetAllCustomers();
        Task<Result<CustomerDto>> GetCustomerById(GetCustomerByIdVM getCustomerByIdVM);
        Task<Result<bool>> UpdateCustomer(UpdateCustomerVM updateCustomerVM);

    }
}
