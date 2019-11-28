using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainMenu;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainMenuLib;
using InvalidPasswordException = DBConnectionLib.InvalidPasswordException;


namespace ARX_Tests
{
    [TestClass]
    public class LoginTest
    {
        /// <summary>
        /// Test if the login work with an existing user
        /// First the user is created
        /// then the login is tested, with method from MainMenulLib\login.cs
        /// </summary>
        [TestMethod]
        public void TestLoginExistingUser()
        {
            
            string userEmail = "test.Test@test.test";
            string password = "1234";
            Login l = new Login(userEmail, password);

            Assert.IsTrue(l.LoginDB(l));
        }

        /// <summary>
        /// Test if the login not work
        /// The test try to login with an unexisting user username
        /// TBD: The test should catch an exception 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(DBConnectionLib.UnknownUsernameException))]
        public void TestLoginInvalidUsername()
        {
            string userEmail = "alessandro.rossicpnv.ch";
            string password = "1234";
            Login login = new Login(userEmail, password);

            login.LoginDB(login);
        }

        /// <summary>
        /// Test if the login not work
        /// The test try to login with an unexisting user username
        /// TBD: The test should catch an exception 
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordException))]
        public void TestLoginInvalidPassword()
        {
            string userEmail = "alessandro.rossi@cpnv.ch";
            string password = "4321";
            Login login = new Login(userEmail, password);

            login.LoginDB(login);
        }

    }
}
