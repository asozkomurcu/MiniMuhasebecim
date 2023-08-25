using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebecim.Application.Models.RequestModels.DebtRM
{
    public class UpdateDebtVM
    {
        public int? Id { get; set; }
        public int? WholesalerId { get; set; }
        public decimal OrderDebt { get; set; }
    }
}
