using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public abstract class GameObject : IdentifiableObject
    {
        private string _name;
        private string _description;

        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }

        public string Description
        {
            get
            {
                return _description;
            }
        }

        public string ShortDescription
        {
            get
            {
                string textDesc = "a " + Name + " (" + FirstId() + ")";
                return textDesc;
            }
        }

        public virtual string LongDescription
        {
            get
            {
                return Description;
            }
        }
    }
}