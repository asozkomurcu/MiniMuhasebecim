using MiniMuhasebecim.UI.Models.Dtos.WholasalerDtos;

namespace MiniMuhasebecim.UI.Models.Dtos.PaymentDtos
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
