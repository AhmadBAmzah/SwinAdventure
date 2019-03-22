using System;
using System.Collections.Generic;

namespace SwinAd
{
    class Location : GameObject
    {
        private Inventory _inventory {get; set;}

        public Location(string[] ids, string name, string desc) : base(ids, name, desc)
        {
            this._inventory = new Inventory();
        }

        public virtual GameObject Locate(string id)
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
    }
}