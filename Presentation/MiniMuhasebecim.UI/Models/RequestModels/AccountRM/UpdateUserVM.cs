namespace MiniMuhasebecim.UI.Models.RequestModels.AccountRM
{
    public class UpdateUserVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public DateTime Birtdate { get; set; }
        public Gender Gender { get; set; }
    }
}
