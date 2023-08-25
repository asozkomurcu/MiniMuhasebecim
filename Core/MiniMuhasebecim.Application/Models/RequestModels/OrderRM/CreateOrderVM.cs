using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebecim.Application.Models.RequestModels.OrderRM
{
    public class CreateOrderVM
    {
        public int WholesalerId { get; set; }
        public decimal OrderPrice { get; set; }
        public decimal? TotalOrderPrice { get; set; }

    }
}
