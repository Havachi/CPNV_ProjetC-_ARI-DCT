using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameLib;
namespace ARX_Tests
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void CreateNewPlayer()
        {
            string username = "Havachi";
            double hp = 100;
            Position posXY = new Position("0","0");
            List<Item> Ilist=new List<Item>();
            Inventory inv = new Inventory(Ilist);

            Player player = new Player(username,hp,posXY,inv);


        }
    }
}
