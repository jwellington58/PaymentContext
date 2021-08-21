using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PaymentContext.Domain.Enums;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Tests.ValueObjects
{
    [TestClass]
    public class DocumentTests
    {
        //Red, Green, Refactor
        [TestMethod]
        public void ShouldReturnErrorWhenCNPJIsInvalid()
        {
            var document = new Document("123", EDocumentType.CNPJ);
            Assert.IsFalse(document.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCNPJIsValid()
        {
            var document = new Document("25584574000185", EDocumentType.CNPJ);
            Assert.IsTrue(document.IsValid);
        }

        [TestMethod]
        public void ShouldReturnErrorWhenCPFIsInvalid()
        {
            var document = new Document("123", EDocumentType.CPF);
            Assert.IsFalse(document.IsValid);
        }

        [TestMethod]
        public void ShouldReturnSuccessWhenCPFIsValid()
        {
            var document = new Document("09115005020", EDocumentType.CPF);
            Assert.IsTrue(document.IsValid);
        }
    }
}
