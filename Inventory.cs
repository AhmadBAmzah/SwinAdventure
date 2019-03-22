using System;
using System.Collections.Generic;

namespace SwinAd
{
    class Inventory : GameObject
    {
        private List<Item> _items {get; set;}
        public Inventory() : base()
        {
            this._items = new List<Item>();
        }

        public void Put(Item itm)
        {
            this._items.Add(itm);
        }

        public Item Take(Item itm)
        {
            this._items.Remove(itm);
            return itm;
        }

        public Item Fetch(string id)
        {

            int fetchIndex = -1;
            foreach(Item itm in this._items)
            {
                if(itm.firstId() == id)
                {
                    fetchIndex = this._items.IndexOf(itm);
                    break;
                }
            }
            if(fetchIndex != -1)
                return this._items[fetchIndex];
            else
                return null;
        }

        public string ItemList()
        {
            string listAll = "\n";
            foreach(Item itm in this._items)
            {
                listAll += itm.shortDesc() + itm.longDesc() + "\n";
            }
            return listAll;
        }
    }
}