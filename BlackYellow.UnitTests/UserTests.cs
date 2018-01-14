using BlackYellow.Domain.Entites;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlackYellow.UnitTests
{
    [TestClass]
    public class UserTests
    {
        [TestMethod]
        public void EmailIsValid()
        {
            var user = new User()
            {
                Email = "walter.vlopes@gmail.com"
            };

            var isValid = user.EmailisValid();

            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void EmailIsInvalid()
        {
            var user = new User()
            {
                Email = "walter.vlopesgmail.com"
            };

            var isValid = user.EmailisValid();

            Assert.IsFalse(isValid);
        }
    }
}
