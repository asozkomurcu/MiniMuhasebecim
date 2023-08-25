namespace MiniMuhasebecim.UI.Models.RequestModels.PaymentRM
{
    public class CreatePaymentVM
    {
        public int WholesalerId { get; set; }
        public decimal OrderPayment { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
