using System;
using System.Text;
using System.Collections.Generic;
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
            string password = "1234";
            Register r = new Register(userEmail, username, password);
            Assert.IsTrue(r.RegisterInDB(r));
        }

        [TestMethod]
        [ExpectedException(typeof(UsernameAlreadyExistException))]
        public void TryRegisterInDbWithInvalidInput()
        {
            string userEmail = "alessandro.rossi@cpnv.ch";
            string username = "Havachi";
            string password = "1234";
            Register r = new Register(userEmail, username, password);
            r.RegisterInDB(r);
        }
    }
}
