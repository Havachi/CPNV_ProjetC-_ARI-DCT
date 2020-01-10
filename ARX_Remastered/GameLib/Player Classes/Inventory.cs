using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using Org.BouncyCastle.Math.EC.Multiplier;



namespace GameLib
{
    public class Inventory
    {
        private List<Item> contentList = new List<Item>();

        public Inventory(List<Item> contentList)
        {
            this.contentList = contentList;
        }

        public Inventory()
        {
        }

        public void AddItemInInventory(Inventory inventory, Item itemToAdd)
        {
            inventory.ContentList.Add(itemToAdd);
        }

        public void RemoveItemInInventory(Inventory inventory, Item itemToDel)
        {
            inventory.ContentList.Remove(itemToDel);
        }
        public List<Item> ContentList
        {
            get { return contentList; }
            set { contentList = value;}
        }
    }
}