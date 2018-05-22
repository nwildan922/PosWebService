using Pos.Model.Core;
using System;

namespace Pos.Model.Core
{
    public class AccountPayment : BaseModelLite
    {
        public DateTime PaymentDate { get; set; }
        public int Period { get; set; }
        public decimal TotalPayment { get; set; }
    }
}