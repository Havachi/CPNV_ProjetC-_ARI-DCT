using System;
using DBConnectionLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ARX_Tests
{
    [TestClass]
    public class DbConnectionTest
    {
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestConnectionWithDatabase()
        {
            try
            {
                //init of the connection
                DBConnection connDB = new DBConnection();
                connDB.OpenConnection();

                //close connection
                connDB.CloseConnection();
            }
            catch (Exception exc)
            {
                //we display the error message.
                Console.WriteLine(exc.Message);
            }
            finally
            {
                Console.ReadKey();
            }
        }
        /// <summary>
        /// Test if the login work with an existing user
        /// First the user is created
        /// then the login is tested, with method from MainMenulLib\login.cs
        /// </summary>
        [TestMethod]
        public void TestLoginExistingUser()
        {

        }
        /// <summary>
        /// Test if the login not work
        /// The test try to login with an unexisting user username
        /// TBD: The test should catch anexception 
        /// </summary>
        [TestMethod]
        public void TestLoginNonExistingUser()
        {

        }

    }
}
