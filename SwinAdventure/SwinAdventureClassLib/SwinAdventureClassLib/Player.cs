using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;

        public Player(string name, string desc) : base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
            _location = new Location(new[] { "start" }, "Start", "Starting location...");
        }

        public override string LongDescription
        {
            get
            {
                string textDesc;
                textDesc = "You are carrying:\n";
                foreach(string ListItem in _inventory.ItemList())
                {
                    textDesc += ListItem + "\n";
                }
                return textDesc;
            }
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

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }
    }
}