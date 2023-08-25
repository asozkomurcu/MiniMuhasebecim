using MiniMuhasebecim.Application.Models.Dtos.WholasalerDtos;
using MiniMuhasebecim.Domain.Entities;

namespace MiniMuhasebecim.Application.Models.Dtos.PaymentDtos
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int WholesalerId { get; set; }
        public decimal OrderPayment { get; set; }
        public decimal? TotalPayment { get; set; }
        public PaymentType PaymentType { get; set; }

        public WholesalerDto Wholesaler { get; set; }
    }
}
