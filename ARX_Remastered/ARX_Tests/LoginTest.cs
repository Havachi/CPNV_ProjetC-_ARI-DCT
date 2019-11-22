using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using 
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
            string username = "Havachi";
            string password = "1234";

            
        }
        /// <summary>
        /// Test if the login not work
        /// The test try to login with an unexisting user username
        /// TBD: The test should catch an exception 
        /// </summary>
        [TestMethod]
        public void TestLoginNonExistingUser()
        {

        }
    }
}
