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
            DBConnection d = new DBConnection();
            d.OpenConnection();
            d.CloseConnection();
        }
        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void TestSelectInDatabase()
        {
            DBConnection d = new DBConnection();
            d.OpenConnection();
            var dOut = d.GetPlayerName(1);
            Assert.AreEqual("Havachi",dOut);
            d.CloseConnection();
        }


    }
}
