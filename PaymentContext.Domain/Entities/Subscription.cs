using System;
using System.Collections.Generic;

namespace PaymentContext.Domain.Entities
{
    public class Subscription
    {
        private IList<Payment> _payments;
        public Subscription(DateTime? expireDate)
        {
            CreateDate = DateTime.UtcNow;
            LastUpdateDate = DateTime.UtcNow;
            ExpireDate = expireDate;
            Active = true;
            _payments = new List<Payment>();
        }

        public DateTime CreateDate { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public DateTime? ExpireDate { get; private set; }
        public bool Active { get; private set; }
        public IReadOnlyCollection<Payment> Payments { get; set; }

        public void InactivateSubscription()
        {
            Active = false;
            LastUpdateDate = DateTime.UtcNow;
        }
        public void ActivateSubscription()
        {
            Active = true;
            LastUpdateDate = DateTime.UtcNow;
        }
        public void AddPayment(Payment payment)
        {
            _payments.Add(payment);
        }
    }
}