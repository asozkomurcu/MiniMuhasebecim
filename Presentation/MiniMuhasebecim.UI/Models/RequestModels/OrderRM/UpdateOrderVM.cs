namespace MiniMuhasebecim.UI.Models.RequestModels.OrderRM
{
    public class UpdateOrderVM
    {
        public int Id { get; set; }
        public int WholesalerId { get; set; }
        public decimal OrderPrice { get; set; }
    }
}
