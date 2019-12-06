using System;
using DBConnectionLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MainMenuLib;
using InvalidPasswordException = DBConnectionLib.InvalidPasswordException;


namespace ARX_Tests
{
    /// <summary>
    /// This test class is dedicated for the login
    /// </summary>
    [TestClass]
    public class LoginTest
    {
        /// <summary>
        /// Test if the login work with an existing user
        /// First the user is created
        /// then the login is tested, with method from MainMenulLib\login.cs
        /// </summary>
        [TestInitialize]
        public void Initialize()
        {
            string userEmail = "test.Test@test.test";
            string username = "Test";
            string password = "12345678";
            DbConnection db = new DbConnection();
            try
            {
                if (!db.CheckIfUserEmailExistInDb(userEmail))
                {
                    Register reg = new Register(userEmail, username, password, password);
                    reg.RegisterInDb(reg);
                }
            }
            catch (UserEmailAlreadyExistException e)
            {
                Console.WriteLine(@"UserEmail already exist, skipping user creation.");
            }

        }
        /// <summary>
        /// Test if the user can login with an existing user
        /// </summary>
        [TestMethod]
        public void TestLoginExistingUser()
        {
            string userEmail = "test.Test@test.test";
            string password = "12345678";

            Login l = new Login(userEmail, password);
            Assert.IsTrue(l.LoginDb(l));
        }
        /// <summary>
        /// Test if an exception is thrown if the field for login are empty.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(EmptyFieldException))]
        public void TestLoginEmptyField()
        {
            string userEmail = "";
            string password = "";
            Login login = new Login(userEmail,password);
            try
            {
                login.LoginDb(login);
            }
            catch(UnknownUserEmailAddressException exception)
            {
                
            }

            
        }
        /// <summary>
        /// Test if an exception is thrown if the password is wrong
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidPasswordException))]
        public void TestLoginWithWrongPassword()
        {
            string userEmail = "test.Test@test.test";
            string password = "abcdefgh1234";
            Login login = new Login(userEmail, password);
            login.LoginDb(login);
        }
    } 
}
