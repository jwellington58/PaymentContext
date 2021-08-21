using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{   [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var name = new Name("Zé", "Do Picole");
            var document = new Document("09115005020", EDocumentType.CPF);
            var email = new Email("zedopicole@gmail.com");
            var address = new Address("Rua 0", "1234", "Bairro 0", "Cidade 0", "Estado 0", "País 0", "123456");
            var student = new Student(name, document, email);
            var subscription = new Subscription(null);
            var payment = new PaypalPayment("486ee52c-02c9-11ec-9a03-0242ac130003", DateTime.UtcNow, DateTime.UtcNow.AddDays(6), 10, 10, document, "ze do picole corp", address, email);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenHadNoActiveSubscription()
        {
            var name = new Name("Zé", "Do Picole");
            var document = new Document("09115005020", EDocumentType.CPF);
            var email = new Email("zedopicole@gmail.com");
            var student = new Student(name, document, email);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenHadNoActiveSubscriptionWhithoutPayments()
        {

        }
    }
}
