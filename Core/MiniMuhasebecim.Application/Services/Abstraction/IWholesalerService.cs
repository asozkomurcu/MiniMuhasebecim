using MiniMuhasebecim.Application.Models.Dtos.WholasalerDtos;
using MiniMuhasebecim.Application.Models.RequestModels.WholasalerRM;
using MiniMuhasebecim.Application.Wrapper;

namespace MiniMuhasebecim.Application.Services.Abstraction
{
    public interface IWholesalerService
    {
        Task<Result<List<WholesalerDto>>> GetAllWholesaler();
        Task<Result<WholesalerDto>> GetWholesalerById(GetWholesalerByIdVM getWholesalerByIdVM);
        Task<Result<int>> CreateWholesaler(CreateWholesalerVM createWholesalerVM);
        Task<Result<bool>> UpdateWholesaler(UpdateWholesalerVM updateWholesalerVM);
        Task<Result<bool>> DeleteWholesaler(DeleteWholesalerVM deleteWholesalerVM);
    }
}
