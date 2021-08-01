using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class PaypalPayment : Payment
    {
        public PaypalPayment(
            string transactionCode, 
            DateTime paidDate, 
            DateTime expireDate, 
            decimal total, 
            decimal totalPaid,
            Document document, 
            string payer, 
            Address address, 
            Email email) : base(
                paidDate, 
                expireDate, 
                total,
                totalPaid, 
                document, 
                payer, 
                address, 
                email)
        {
            TransactionCode = transactionCode;
        }
        public string TransactionCode { get; private set; }
    }
}
