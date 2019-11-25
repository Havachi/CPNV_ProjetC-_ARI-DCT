using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLib
{
    public class Inventory
    {
        
        private List<Item> contentList;
        
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
            get { return ContentList; }
            set { ContentList = value;}
        }
    }
}
