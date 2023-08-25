using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MiniMuhasebecim.Application.Models.Dtos.WholasalerDtos;
using MiniMuhasebecim.Application.Models.RequestModels.CategoryRM;
using MiniMuhasebecim.Application.Models.RequestModels.WholasalerRM;
using MiniMuhasebecim.Application.Services.Abstraction;
using MiniMuhasebecim.Application.Services.Implementation;
using MiniMuhasebecim.Application.Wrapper;
using MiniMuhasebecim.Domain.Entities;

namespace MiniMuhasebecim.Api.Controllers
{
    [Route("wholesaler")]
    [ApiController]
    [Authorize]
    public class WholesalerController : ControllerBase
    {
        private readonly IWholesalerService _wholesalerService;

        public WholesalerController(IWholesalerService wholesalerService)
        {
            _wholesalerService = wholesalerService;
        }

        [HttpGet("get")]
        public async Task<ActionResult<List<WholesalerDto>>> GetAllWholesalers()
        {
            var wholesalers = await _wholesalerService.GetAllWholesaler();
            return Ok(wholesalers);
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<Result<WholesalerDto>>> GetWholesalerById(int id)
        {
            var wholesaler = await _wholesalerService.GetWholesalerById(new GetWholesalerByIdVM { Id = id });
            return Ok(wholesaler);
        }

        [HttpPost("create")]
        public async Task<ActionResult<Result<int>>> CreateWholesaler (CreateWholesalerVM createWholesalerVM)
        {
            var wholesalerId = await _wholesalerService.CreateWholesaler(createWholesalerVM);
            return Ok(wholesalerId);
        }

        [HttpPost("update")]
        public async Task<ActionResult<Result<int>>> UpdateWholesaler(int id, UpdateWholesalerVM updateWholesalerVM)
        {
            if (id != updateWholesalerVM.Id)
            {
                return BadRequest();
            }
            var wholesalerId = await _wholesalerService.UpdateWholesaler(updateWholesalerVM);
            return Ok(wholesalerId);
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult<Result<int>>> DeleteWholesaler(int id)
        {
            var wholesalerId = await _wholesalerService.DeleteWholesaler(new DeleteWholesalerVM { Id = id });
            return Ok(wholesalerId);
        }
    }
}
