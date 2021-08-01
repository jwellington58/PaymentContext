using System;
using System.Collections.Generic;

namespace PaymentContext.Domain.Entities
{
    public class Subscription
    {
        public DateTime CreateDate { get; set; }
        public DateTime LasUpdateDate { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string Address { get; set; }
        public List<Payment> Payments { get; set; }
    }
}