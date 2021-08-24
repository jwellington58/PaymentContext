using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.Entities
{   [TestClass]
    public class StudentTests
    {
        private readonly Student _student;
        private readonly Name _name;
        private readonly Document _document;
        private readonly Email _email;
        private readonly Address _address;
        private readonly Subscription _subscription;

        public StudentTests()
        {
            _name = new Name("Zé", "Do Picole");
            _document = new Document("09115005020", EDocumentType.CPF);
            _email = new Email("zedopicole@gmail.com");
            _address = new Address("Rua 0", "1234", "Bairro 0", "Cidade 0", "Estado 0", "País 0", "123456");
            _student = new Student(_name, _document, _email);
            _subscription = new Subscription(null);
                 
        }

        [TestMethod]
        public void ShouldReturnErrorWhenHadActiveSubscription()
        {
            var payment = new PaypalPayment("486ee52c-02c9-11ec-9a03-0242ac130003", 
                DateTime.UtcNow, 
                DateTime.UtcNow.AddDays(6), 
                10, 
                10, 
                _document, 
                "ze do picole corp", 
                _address, 
                _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            _student.AddSubscription(_subscription);

            Assert.IsFalse(_student.IsValid);

        }

        [TestMethod]
        public void ShouldReturnSuccessWhenAddSubscription()
        {
            var payment = new PaypalPayment("486ee52c-02c9-11ec-9a03-0242ac130003",
                DateTime.UtcNow,
                DateTime.UtcNow.AddDays(6),
                10,
                10,
                _document,
                "ze do picole corp",
                _address,
                _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);
            Assert.IsTrue(_student.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenHadNoActiveSubscriptionWhithoutPayments()
        {
            var payment = new PaypalPayment("486ee52c-02c9-11ec-9a03-0242ac130003",
               DateTime.UtcNow,
               DateTime.UtcNow.AddDays(6),
               10,
               10,
               _document,
               "ze do picole corp",
               _address,
               _email);
            _subscription.AddPayment(payment);
            _student.AddSubscription(_subscription);

            Assert.IsTrue(_student.IsValid);
        }
    }
}
