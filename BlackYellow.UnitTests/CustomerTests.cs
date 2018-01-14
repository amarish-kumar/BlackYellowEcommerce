using BlackYellow.Domain.Entites;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BlackYellow.UnitTests
{
    [TestClass]
    public class CustomerTests
    {
        [TestMethod]
        public void ValidCpfTest()
        {
            var customer = new Customer()
            {
                Cpf = "44166763873"
            };
            var isValid = customer.IsValidCpf();
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void InvalidCpfTest()
        {
            var customer = new Customer()
            {
                Cpf = "444444444"
            };

            var isValid = customer.IsValidCpf();
            Assert.IsFalse(isValid);
        }


    }
}
