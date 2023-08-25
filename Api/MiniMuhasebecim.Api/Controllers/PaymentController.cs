using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebecim.Application.Models.Dtos.PaymentDtos;
using MiniMuhasebecim.Application.Models.RequestModels.PaymentRM;
using MiniMuhasebecim.Application.Services.Abstraction;
using MiniMuhasebecim.Application.Wrapper;

namespace MiniMuhasebecim.Api.Controllers
{
    [Route("payment")]
    [ApiController]
    [Authorize]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<PaymentDto>>> GetAllPayments()
        {
            var payments = await _paymentService.GetAllPayments();
            return Ok(payments);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<PaymentDto>>> GetPaymentById(int id)
        {
            var payment = await _paymentService.GetPaymentById(id);
            return Ok(payment);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreatePayment(CreatePaymentVM createPaymentVM)
        {
            var paymentId = await _paymentService.CreatePayments(createPaymentVM);
            return Ok(paymentId);
        }

        [HttpPost("update")]
        public async Task<ActionResult<Result<int>>> UpdatePayment(int id, UpdatePaymentVM updatePaymentVM)
        {
            if (id != updatePaymentVM.Id)
            {
                return BadRequest();
            }
            var paymentId = await _paymentService.UpdatePayments(updatePaymentVM);
            return Ok(paymentId);
        }


    }
}
