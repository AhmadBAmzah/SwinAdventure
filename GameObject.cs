using System;
using System.Collections.Generic;

namespace SwinAd
{
    abstract class GameObject : IdentifiableObject
    {
        private string _name {get; set;}
        private string _description  {get; set;}

        public GameObject(){}
        
        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            _name = name;
            _description = desc;
        }

        public virtual string Name()
        {
            return _name;
        }

        public string shortDesc()
        {
            string textDesc = "a " + _name + " (" + base.firstId() + ")" ;
            return textDesc;
        }

        public virtual string longDesc()
        {
            string textDesc = _description;
            return textDesc;
        }
    }
}