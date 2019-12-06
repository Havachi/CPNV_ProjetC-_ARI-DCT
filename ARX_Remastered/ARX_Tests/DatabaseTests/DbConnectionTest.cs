using System;
using System.Drawing;
using DBConnectionLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ARX_Tests
{
    [TestClass]
    public class DbConnectionTest
    {
        /// <summary>
        /// Test if it is possible to connect to the database
        /// </summary>
        [TestMethod]
        public void TestConnectionWithDatabase()
        {
            DbConnection d = new DbConnection();
            d.OpenConnection();
            d.CloseConnection();
        }

        [TestMethod]
        [ExpectedException(typeof(UnknownUserEmailAddressException))]
        public void TestCheckEmailException()
        {
            string testEmail = "oof@oof.oof";
            DbConnection d = new DbConnection();

            d.CheckEmail(testEmail);
        }

        [TestMethod]
        public void TestGetUserIDFromUsername()
        {
            DbConnection db = new DbConnection();
            string username = "TestUser1";
            var result = db.GetUserIdFromUsername(username);
            Assert.AreEqual("21",result);
        }

        [TestMethod]
        public void TestInsertDataInDB()
        {
            string username = "TestNo4";
            string useremail = "Test.Email@Address.fun";
            string password = "12345678";


            DbConnection db = new DbConnection();
            db.InsertDataInDb(username,useremail,password);
        }
        [TestMethod]
        public void TestGetUserPassword()
        {
            string useremail = "test.Test@test.test";

            DbConnection db = new DbConnection();
            var userpassword= db.GetUserPassword(useremail);

            Assert.AreEqual("X2wCdhr31aEeQ/hSrxOQ2MWinioteo3v1aupG54OMg8ifV6f", userpassword);
        }

    }
}
