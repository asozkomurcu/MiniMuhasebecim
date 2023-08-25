using MiniMuhasebecim.Application.Models.Dtos.WholasalerDtos;

namespace MiniMuhasebecim.Application.Models.Dtos.DebtDtos
{
    public class DebtDto
    {
        public int Id { get; set; }
        public int WholesalerId { get; set; }
        public decimal OrderDebt { get; set; }
        public decimal? TotalDebt { get; set; }

        public WholesalerDto Wholesaler { get; set; }
        public decimal TotalIncomeCash { get; internal set; }
    }
}
