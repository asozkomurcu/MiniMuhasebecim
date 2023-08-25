using MiniMuhasebecim.Application.Models.Dtos.PaymentDtos;
using MiniMuhasebecim.Application.Models.RequestModels.PaymentRM;
using MiniMuhasebecim.Application.Wrapper;

namespace MiniMuhasebecim.Application.Services.Abstraction
{
    public interface IPaymentService
    {
        Task<Result<List<PaymentDto>>> GetAllPayments();
        Task<Result<PaymentDto>> GetPaymentById(int id);
        Task<Result<int>> CreatePayments(CreatePaymentVM createPaymentVM);
        Task<Result<bool>> UpdatePayments(UpdatePaymentVM updatePaymentVM);

    }
}
