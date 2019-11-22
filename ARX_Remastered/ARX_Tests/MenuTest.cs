using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainMenuLib;
using MainMenu;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ARX_Tests
{
    class MenuTest
    {
        [TestClass]
        public class LoginFormTest
        {
            /// <summary>
            /// Test if the login form
            /// First, username and password are initialised
            /// Then, Test if username or/and password are empty or not
            /// Next, test if username and password are longer than 8 characters
            /// then the login is tested, with method from MainMenu\CheckData.cs
            /// </summary>
            [TestMethod]
            public void TestLoginFormBothEmpty()
            {
                string username = "";
                string password = "";
                CheckData logincheck = new CheckData(username, password);
                Assert.IsTrue(username == "" && password == "");
            }
            [TestMethod]
            public void TestLoginFormUsernameEmpty()
            {
                string username = "";
                string password = "12345678";
                CheckData logincheck = new CheckData(username, password);
                Assert.IsTrue(username == "");
            }
            [TestMethod]
            public void TestLoginFormPasswordEmpty()
            {
                string username = "Gerardine";
                string password = "";
                CheckData logincheck = new CheckData(username, password);
                Assert.IsTrue(password == "" && username == "Gerardine");
            }
            [TestMethod]
            public void TestLoginFormUsernameTooshort()
            {
                string username = "Gerard";
                string password = "12345678";
                CheckData logincheck = new CheckData(username, password);
                Assert.IsTrue(username.Length < 8);
            }
            [TestMethod]
            public void TestLoginFormPasswordTooshort()
            {
                string username = "Gerardine";
                string password = "1234";
                CheckData logincheck = new CheckData(username, password);
                Assert.IsTrue(password.Length < 8);
            }
        }
    }
}
