using System;
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
 


    }
}
