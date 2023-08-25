using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebecim.Application.Models.Dtos.IncomeDtos;
using MiniMuhasebecim.Application.Models.RequestModels.IncomeRM;
using MiniMuhasebecim.Application.Services.Abstraction;
using MiniMuhasebecim.Application.Wrapper;

namespace MiniMuhasebecim.Api.Controllers
{
    [Route("income")]
    [ApiController]
    [Authorize]
    public class IncomeController : ControllerBase
    {
        private readonly IIncomeService _incomeService;

        public IncomeController(IIncomeService incomeService)
        {
            _incomeService = incomeService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<IncomeDto>>> GetAllIncomes()
        {
            var incomes = await _incomeService.GetAllIncomes();
            return Ok(incomes);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<IncomeDto>>> GetIncomeById(int id)
        {
            var income = await _incomeService.GetIncomeById(id);
            return Ok(income);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreatePayment(CreateIncomeVM createIncomeVM)
        {
            var incomeId = await _incomeService.CreateIncome(createIncomeVM);
            return Ok(incomeId);
        }

        [HttpPost("update")]
        public async Task<ActionResult<Result<int>>> UpdateIncome(int id, UpdateIncomeVM updateIncomeVM)
        {
            if (id != updateIncomeVM.Id)
            {
                return BadRequest();
            }
            var incomeId = await _incomeService.UpdateIncome(updateIncomeVM);
            return Ok(incomeId);
        }

    }
}
