using MiniMuhasebecim.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebecim.Domain.Entities
{
    public class CustomerImage : AuditableEntity
    {
        public int CustomerId { get; set; }
        public string Path { get; set; }

        public Customer Customer { get; set; }
    }
}
