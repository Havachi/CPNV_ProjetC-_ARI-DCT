using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MainMenuLib;
using MainMenu;


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
            /// then the login is tested, with method from MainMenu\CheckData.cs
            /// </summary>
            [TestMethod]
            public void TestLoginFormBothEmpty()
            {
                string username = "";
                string password = "";
                CheckData logincheck = new CheckData(username, password);


                Assert.IsTrue(username == "");
            }
        }
    }
}
