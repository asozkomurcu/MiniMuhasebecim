using MiniMuhasebecim.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebecim.Domain.Entities
{
    public class Payment : AuditableEntity
    {
        public int? WholesalerId { get; set; }
        public decimal OrderPayment { get; set; }
        public decimal? TotalPayment { get; set; }
        public PaymentType PaymentType { get; set; }

        public Wholesaler Wholesaler { get; set; }
    }

    public enum PaymentType
    {
        CahsPayment = 1,
        CreditCardPayment = 2
    }
}
