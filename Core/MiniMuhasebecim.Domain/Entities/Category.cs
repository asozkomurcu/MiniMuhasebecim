using MiniMuhasebecim.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebecim.Domain.Entities
{
    public class Category : AuditableEntity
    {
        public string CategoryName { get; set; }

        public ICollection<Wholesaler> Wholesalers { get; set; }

    }
}
