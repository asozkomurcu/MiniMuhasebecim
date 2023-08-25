using MiniMuhasebecim.Application.Models.Dtos.OrderDtos;
using MiniMuhasebecim.Application.Models.RequestModels.OrderRM;
using MiniMuhasebecim.Application.Wrapper;

namespace MiniMuhasebecim.Application.Services.Abstraction
{
    public interface IOrderService
    {
        Task<Result<List<OrderDto>>> GetAllOrder();
        Task<Result<OrderDto>> GetOrderById(int id);
        Task<Result<int>> CreateOrder(CreateOrderVM createOrderVM);
        Task<Result<bool>> UpdateOrder(UpdateOrderVM updateOrderVM);
    }
}
