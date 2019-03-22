using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory {get; set;}
        public Player(string name, string desc) : base(new string[] {"me", "inventory"}, name, desc)
        {
            this._inventory = new Inventory();
        }

        public override string longDesc()
        {
            string textDesc;
            textDesc = this._inventory.longDesc() + "\n" + "You are carrying:" + this._inventory.ItemList();//wip
            return textDesc;
        }

        public GameObject Locate(string id)
        {
            if(this.areYou(id))
            {
                return this._inventory;
            }
            else
            {
                return this._inventory.Fetch(id) as GameObject;
            }
        }

        public override string Name()
        {
            return this.Name();
        }

        public Inventory inventory()
        {
            return this._inventory;
        }
    }
}