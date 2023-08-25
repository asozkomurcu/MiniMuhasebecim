using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebecim.Application.Models.Dtos.CustomerImageDtos
{
    public class CustomerImageDto
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public string Path { get; set; }
    }
}
