using System;
using System.Drawing;
using DBConnectionLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ARX_Tests
{


    /// <summary>
    /// This is the test class for the DbConnection class and connection with database in general.
    /// </summary>
    [TestCategory("DatabaseTests")]
    [TestClass]
    public class DbConnectionTest
    {
        /// <summary>
        /// Test if it is possible to connect to the database.
        /// </summary>
        [TestMethod]
        public void TestConnectionWithDatabase()
        {
            DbConnection d = new DbConnection();
            d.OpenConnection();
            d.CloseConnection();
        }

        /// <summary>
        /// Test if the method CheckEmail from DbConnection return an exception if the userEmail doesn't exist
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(UnknownUserEmailAddressException))]
        public void TestCheckEmailException()
        {
            string testEmail = "oof@oof.oof";
            DbConnection d = new DbConnection();

            d.CheckEmail(testEmail);
        }

        /// <summary>
        /// Test if the method for input data in database is working correctly.
        /// </summary>
        [TestMethod]
        public void TestInsertDataInDB()
        {
            string username = "TestNo4";
            string useremail = "Test.Email@Address.fun";
            string password = "12345678";


            DbConnection db = new DbConnection();
            db.InsertDataInDb(username,useremail,password);
        }

    }
}
