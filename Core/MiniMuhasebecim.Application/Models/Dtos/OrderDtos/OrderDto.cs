using MiniMuhasebecim.Application.Models.Dtos.WholasalerDtos;

namespace MiniMuhasebecim.Application.Models.Dtos.OrderDtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public int WholesalerId { get; set; }
        public decimal OrderPrice { get; set; }

        public WholesalerDto Wholesaler { get; set; }
    }
}

