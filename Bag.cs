using System;
using System.Collections.Generic;

namespace SwinAd
{
    class Bag : Item, IHaveInventory
    {
        private Inventory _inventory {get; set;}

        public Bag(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            this._inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if(this.areYou(id))
            {
                return this._inventory;
            }
            else
            {
                return this._inventory.Fetch(id);
            }
        }

        public string FullDescription()
        {
            string textDesc = "In the " + this._inventory.Name() + " you can see:" + this._inventory.ItemList();//wip
            return textDesc;
        }

        public override string Name()
        {
            return this._inventory.Name();
        }

        public Inventory inventory()
        {
            return this._inventory;
        }
    }
}