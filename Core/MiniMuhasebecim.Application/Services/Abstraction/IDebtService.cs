using MiniMuhasebecim.Application.Models.Dtos.DebtDtos;
using MiniMuhasebecim.Application.Models.RequestModels.DebtRM;
using MiniMuhasebecim.Application.Wrapper;

namespace MiniMuhasebecim.Application.Services.Abstraction
{
    public interface IDebtService
    {
        Task<Result<List<DebtDto>>> GetAllDebts();
        Task<Result<DebtDto>> GetDebtById(GetDebtByIdVM getDebtByIdVM);
        Task<Result<int>> CreateDebts(CreateDebtVM createDebtVM);
        Task<Result<int>> UpdateDebts(UpdateDebtVM updateDebtVM);
    }
}
