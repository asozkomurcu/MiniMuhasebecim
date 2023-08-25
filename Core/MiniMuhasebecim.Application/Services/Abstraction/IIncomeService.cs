using MiniMuhasebecim.Application.Models.Dtos.IncomeDtos;
using MiniMuhasebecim.Application.Models.RequestModels.IncomeRM;
using MiniMuhasebecim.Application.Wrapper;

namespace MiniMuhasebecim.Application.Services.Abstraction
{
    public interface IIncomeService
    {
        Task<Result<List<IncomeDto>>> GetAllIncomes();
        Task<Result<IncomeDto>> GetIncomeById(int id);

        Task<Result<int>> CreateIncome(CreateIncomeVM createIncomeVM);
        Task<Result<bool>> UpdateIncome(UpdateIncomeVM updateIncomeVM);
    }
}
