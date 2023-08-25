namespace MiniMuhasebecim.UI.Models.Dtos.AccountDtos
{
    public class TokenDto
    {
        public Roles Role { get; set; }
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
