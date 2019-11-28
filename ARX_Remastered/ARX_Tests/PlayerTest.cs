using System;
using GameLib;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ARX_Tests
{
    [TestClass]
    public class PlayerTest
    {
        
        private static string username = "Havachi";
        private static double lifepoint = 100.0;
        private static Position position = new Position(0, 0);
        private static Inventory inventory = new Inventory();
        private static string direction = "S";
        
        private static Movement m = new Movement();
        
        [TestMethod]
        public void CreateNewPlayerTest()
        {
            Player p = new Player(username, lifepoint, position, inventory, direction);
            Assert.AreEqual(username, p.Username);
            Assert.AreEqual(lifepoint, p.Lifepoint);
            Assert.AreEqual(position, p.Position);
            Assert.AreEqual(inventory, p.Inventory);
            Assert.AreEqual(direction, p.Direction);
        }
        [TestMethod]
        public void MovePlayerTest()
        {
            Player p = new Player(username, lifepoint, position, inventory, direction);
            m.Move(p);
            Assert.AreEqual(0,p.Position.PositionX);
            Assert.AreEqual(1, p.Position.PositionY);
        }
        
        [TestMethod]
        public void TurnPlayerTest()
        {
            Player p = new Player(username, lifepoint, position, inventory, direction);
            m.Turn(p,"left");
            Assert.AreEqual("E",p.Direction);
        }
        
        [TestMethod]
        public void TeleportPlayerTest()
        {
            Player p = new Player(username, lifepoint, position, inventory, direction);
            m.Teleport(p,7,15);
            Assert.AreEqual(7, p.Position.PositionX);
            Assert.AreEqual(15, p.Position.PositionY);
        }
        
        [TestMethod]
        public void MoveAndTurnTest()
        {
            Player p = new Player(username, lifepoint, position, inventory, direction);
            m.Move(p);
            m.Move(p);
            m.Move(p);

            m.Turn(p,"left");

            m.Move(p);
            m.Move(p);
            m.Move(p);
            m.Move(p);

            m.Turn(p,"right");

            Assert.AreEqual("S", p.Direction);
            Assert.AreEqual(4, p.Position.PositionX);
            Assert.AreEqual(3, p.Position.PositionY);
        }
    }
}
