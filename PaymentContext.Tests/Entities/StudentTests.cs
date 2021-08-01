using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Entities;

namespace PaymentContext.Tests.Entities
{   [TestClass]
    public class StudentTests
    {
        [TestMethod]
        public void TestMethod()
        {
            var subscription = new Subscription(null);
            var student = new Student("Wellington", "Junior", "1234", "wj070996@gmail.com");
            student.AddSubscription(subscription);
        }
    }
}
