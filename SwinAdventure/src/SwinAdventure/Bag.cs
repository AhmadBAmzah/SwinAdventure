using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory;

        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (AreYou(id))
            {
                return this;
            }
            else
            {
                return _inventory.Fetch(id);
            }
        }

        public override string LongDescription
        {
            get
            {
                string textDesc;
                textDesc = $"In the {Name} you can see:\n";
                foreach (string ListItem in _inventory.ItemList())
                {
                    textDesc += ListItem + "\n";
                }
                return textDesc;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}
