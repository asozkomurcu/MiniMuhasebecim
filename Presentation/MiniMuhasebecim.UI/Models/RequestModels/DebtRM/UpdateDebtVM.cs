namespace MiniMuhasebecim.UI.Models.RequestModels.DebtRM
{
    public class UpdateDebtVM
    {
        public int Id { get; set; }
        public int WholesalerId { get; set; }
        public decimal OrderDebt { get; set; }
    }
}
