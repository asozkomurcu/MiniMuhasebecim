namespace MiniMuhasebecim.UI.Models.RequestModels.PaymentRM
{
    public class UpdatePaymentVM
    {
        public int Id { get; set; }
        public int WholesalerId { get; set; }
        public decimal OrderPayment { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
