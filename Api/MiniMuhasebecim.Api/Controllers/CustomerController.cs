using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebecim.Application.Models.Dtos.CustomerDtos;
using MiniMuhasebecim.Application.Models.RequestModels.CustomerRM;
using MiniMuhasebecim.Application.Services.Abstraction;
using MiniMuhasebecim.Application.Wrapper;

namespace MiniMuhasebecim.Api.Controllers
{
    [Route("customer")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<CustomerDto>>> GetAllCustomers()
        {
            var customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<CustomerDto>>> GetCustomerById(int id)
        {
            var customer = await _customerService.GetCustomerById(new GetCustomerByIdVM { Id=id});
            return Ok(customer);
        }
                
        [HttpPost("update")]
        public async Task<ActionResult<Result<int>>> UpdateCustomer(int id, UpdateCustomerVM updateCustomerVM)
        {
            if (id != updateCustomerVM.Id)
            {
                return BadRequest();
            }
            var customerId = await _customerService.UpdateCustomer(updateCustomerVM);
            return Ok(customerId);
        }
    }
}
