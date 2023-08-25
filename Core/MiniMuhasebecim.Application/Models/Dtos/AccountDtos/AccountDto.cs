using MiniMuhasebecim.Application.Models.Dtos.CustomerDtos;
using MiniMuhasebecim.Domain.Entities;

namespace MiniMuhasebecim.Application.Models.Dtos.AccountDtos
{
    public class AccountDto
    {
        public int CustomerId { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime? LastLoginDate { get; set; }
        public string LastUserIp { get; set; }
        public Roles Role { get; set; }

        public CustomerDto Customer { get; set; }
    }
}
