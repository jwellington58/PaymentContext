using PaymentContext.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentContext.Domain.Entities
{
    public class BoletoPayment : Payment
    {
        public BoletoPayment(
            string barCode, 
            string boletoNumber, 
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
            BarCode = barCode;
            BoletoNumber = boletoNumber;
        }

        public string BarCode { get; private set; }
        public string BoletoNumber { get; private set; }
    }
}
