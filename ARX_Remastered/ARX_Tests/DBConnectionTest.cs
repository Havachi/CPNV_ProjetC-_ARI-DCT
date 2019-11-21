using System;
using DBConnectionLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ARX_Tests
{
    [TestClass]
    public class DbConnectionTest
    {
        [TestMethod]
        public void TestConnectionWithDatabase()
        {
            try
            {
                //init of the connection
                DBConnection connDB = new DBConnection();
                connDB.OpenConnection();

                //insert a player
                connDB.AddPlayer("Toto");

                //get a specific player
                string name = connDB.GetPlayerName(1);

                Console.WriteLine("nom : " + name);

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
    }
}
