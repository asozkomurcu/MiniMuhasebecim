using MiniMuhasebecim.Application.Models.Dtos.AccountDtos;
using MiniMuhasebecim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebecim.Application.Models.Dtos.CustomerDtos
{
    public class CustomerDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birtdate { get; set; }
        public Gender Gender { get; set; }
        public AccountDto Account { get; set; }
    }
}
