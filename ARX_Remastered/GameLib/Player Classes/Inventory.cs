using System.Collections.Generic;
using System.Drawing;
using Org.BouncyCastle.Math.EC.Multiplier;

namespace GameLib
{
    public class Inventory
    {

        private List<Item> contentList = new List<Item>();

        public Inventory(string key, Color selectedPixelColor, Color TestPixel)
        {
            switch (key)
            {
                case "W":

                    break;
                case "A":

                    break;
                case "S":

                    break;
                case "D":

                    break;

            }
        }
        public Inventory(List<Item> contentList)
        {
            this.contentList = contentList;
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
