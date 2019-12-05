using System;
using System.Text;
using System.Collections.Generic;
using DBConnectionLib;
using MainMenuLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ARX_Tests
{
    /// <summary>
    /// Description résumée pour RegisterTest
    /// </summary>
    [TestClass]
    public class RegisterTest
    {
        [TestMethod]
        public void TryRegisterInDbWithValidInput()
        {
            string userEmail = "test.Test@test.test";
            string username = "TestUser1";
            string password = "12345678";
            Register r = new Register(userEmail, username, password);
            Assert.IsTrue(r.RegisterInDB(r));
        }

        [TestMethod]
        [ExpectedException(typeof(PasswordTooShortException))]
        public void TestLoginWithTooShortPassword()
        {
            string userEmail = "test2@test.test";
            string username = "TestUser2";
            string password = "1234";
            Register r = new Register(userEmail, username, password);
            Assert.IsTrue(r.RegisterInDB(r));

        }

        [TestMethod]
        [ExpectedException(typeof(EmailTooShortException))]
        public void TestLoginWithTooShortEmailAddress()
        {
            string userEmail = "mail";
            string username = "TestUser3";
            string password = "12345678";
            Register r = new Register(userEmail, username, password);
            Assert.IsTrue(r.RegisterInDB(r));

        }

    }
}
