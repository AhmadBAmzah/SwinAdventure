using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Inventory
    {
        private List<Item> _items;
        public Inventory()
        {
            _items = new List<Item>();
        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(Item itm)
        {
            if (_items.Remove(itm))
                return itm;
            else
                return null;
        }

        public Item Fetch(string id)
        {

            int FetchIndex = -1;
            foreach (Item itm in _items)
            {
                if (itm.AreYou(id))
                {
                    FetchIndex = _items.IndexOf(itm);
                    break;
                }
            }
            if (FetchIndex != -1)
                return _items[FetchIndex];
            else
                return null;
        }

        public List<string> ItemList()
        {
            List<string> listAll = new List<string>();
            foreach (Item itm in _items)
            {
                listAll.Add(itm.ShortDescription + ": " + itm.LongDescription);
            }
            return listAll;
        }
    }
}