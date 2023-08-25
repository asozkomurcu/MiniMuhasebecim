using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebecim.Application.Models.Dtos.DebtDtos;
using MiniMuhasebecim.Application.Models.RequestModels.DebtRM;
using MiniMuhasebecim.Application.Services.Abstraction;
using MiniMuhasebecim.Application.Wrapper;

namespace MiniMuhasebecim.Api.Controllers
{
    [Route("debt")]
    [ApiController]
    [Authorize]
    public class DebtController : ControllerBase
    {
        private readonly IDebtService _debtService;

        public DebtController(IDebtService debtService)
        {
            _debtService = debtService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<DebtDto>>> GetAllDebts()
        {
            var debts = await _debtService.GetAllDebts();
            return Ok(debts);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<DebtDto>>> GetDebtById(int id)
        {
            var debt = await _debtService.GetDebtById(new GetDebtByIdVM { Id=id});
            return Ok(debt);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateDebt(CreateDebtVM createDebtVM)
        {
            var debtId = await _debtService.CreateDebts(createDebtVM);
            return Ok(debtId);
        }

        [HttpPost("update")]
        public async Task<ActionResult<Result<int>>> UpdateDebt(int id,UpdateDebtVM updateDebtVM)
        {
            if (id != updateDebtVM.Id)
            {
                return BadRequest();
            }
            var debtId = await _debtService.UpdateDebts(updateDebtVM);
            return Ok(debtId);
        }
    }
}
