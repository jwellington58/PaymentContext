using System;
using System.Collections.Generic;
using Flunt.Validations;
using PaymentContext.Shared.Entities;

namespace PaymentContext.Domain.Entities
{
    public class Subscription : Entity
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
            AddNotifications(new Contract<Payment>()
                .Requires()
                .IsGreaterThan(DateTime.Now, payment.PaidDate, "Subscription.Payments", "The payment date must be in the future.")
             );
            if(IsValid)
                _payments.Add(payment);
        }
    }
}