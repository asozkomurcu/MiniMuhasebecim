using MiniMuhasebecim.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniMuhasebecim.Application.Models.RequestModels.PaymentRM
{
    public class CreatePaymentVM
    {
        public int WholesalerId { get; set; }
        public decimal OrderPayment { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}
