using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebecim.Application.Models.Dtos.OrderDtos;
using MiniMuhasebecim.Application.Models.Dtos.PaymentDtos;
using MiniMuhasebecim.Application.Models.RequestModels.OrderRM;
using MiniMuhasebecim.Application.Models.RequestModels.PaymentRM;
using MiniMuhasebecim.Application.Services.Abstraction;
using MiniMuhasebecim.Application.Services.Implementation;
using MiniMuhasebecim.Application.Wrapper;
using MiniMuhasebecim.Domain.Entities;

namespace MiniMuhasebecim.Api.Controllers
{
    [Route("order")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<OrderDto>>> GetAllOrders()
        {
            var orders = await _orderService.GetAllOrder();
            return Ok(orders);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<OrderDto>>> GetOrderById(int id)
        {
            var order = await _orderService.GetOrderById(id);
            return Ok(order);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateOrder(CreateOrderVM createOrderVM)
        {
            var orderId = await _orderService.CreateOrder(createOrderVM);
            return Ok(orderId);
        }

        [HttpPost("update")]
        public async Task<ActionResult<Result<int>>> UpdateOrder(int id, UpdateOrderVM updateOrderVM)
        {
            if (id != updateOrderVM.Id)
            {
                return BadRequest();
            }
            var orderId = await _orderService.UpdateOrder(updateOrderVM);
            return Ok(orderId);
        }

    }
}
