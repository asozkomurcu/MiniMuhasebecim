namespace MiniMuhasebecim.UI.Models.RequestModels.IncomeRM
{
    public class CreateIncomeVM
    {
        public DateTime Date { get; set; }
        public decimal Cash { get; set; }
        public decimal CreditCard1 { get; set; }
        public decimal? CreditCard2 { get; set; }

    }
}
