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
            DBConnection d = new DBConnection();
            d.OpenConnection();
            d.CloseConnection();
        }

        [TestMethod]
        [ExpectedException(typeof(UnknownUserEmailAddressException))]
        public void TestCheckEmailException()
        {
            string testEmail = "oof@oof.oof";
            DBConnection d = new DBConnection();

            d.CheckEmail(testEmail);
        }

        [TestMethod]
        public void TestGetUserIDFromUsername()
        {
            DBConnection db = new DBConnection();
            string username = "TestUser1";
            var result = db.GetUserIDFromUsername(username);
            Assert.AreEqual("21",result);
        }

        [TestMethod]
        public void TestInsertDataInDB()
        {
            string username = "TestNo4";
            string useremail = "Test.Email@Address.fun";
            string password = "12345678";


            DBConnection db = new DBConnection();
            db.InsertDataInDB(username,useremail,password);
        }
        [TestMethod]
        public void TestGetUserPassword()
        {
            string useremail = "test.Test@test.test";

            DBConnection db = new DBConnection();
            var userpassword= db.GetUserPassword(useremail);

            Assert.AreEqual("X2wCdhr31aEeQ/hSrxOQ2MWinioteo3v1aupG54OMg8ifV6f", userpassword);
        }



    }
}
