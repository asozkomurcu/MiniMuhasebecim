namespace MiniMuhasebecim.UI.Models.RequestModels.OrderRM
{
    public class CreateOrderVM
    {
        public int WholesalerId { get; set; }
        public decimal OrderPrice { get; set; }
        public decimal? TotalOrderPrice { get; set; }

    }
}
