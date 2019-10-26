using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<Path> _Paths;

        public Location(string[] idents, string name, string desc) : base(idents, name, desc)
        {
            _inventory = new Inventory();
            _Paths = new List<Path>();
        }

        public void AddPath(Path pth)
        {
            _Paths.Add(pth);
        }

        public void RemovePath(Path pth)
        {
            _Paths.Remove(pth);
        }

        public Path FetchPath(string id)
        {
            int FetchIndex;
            foreach (Path Path in _Paths)
            {
                if (Path.AreYou(id))
                {
                    FetchIndex = _Paths.IndexOf(Path);
                    return _Paths[FetchIndex];
                }
            }
            return null;
        }

        public override string LongDescription
        {
            get
            {
                string textDesc;
                textDesc = $"In {Name} you can see:\n";
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
    }
}