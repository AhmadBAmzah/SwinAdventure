using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    abstract class GameObject : IdentifiableObject
    {
        private string _name {get; set;}
        private string _description  {get; set;}

        public GameObject(){}
        
        public GameObject(string[] ids, string name, string desc) : base(ids)
        {
            this._name = name;
            this._description = desc;
        }

        public virtual string Name()
        {
            return this._name;
        }

        public string shortDesc()
        {
            string textDesc = "a " + this._name + " (" + base.firstId() + ")" ;
            return textDesc;
        }

        public virtual string longDesc()
        {
            string textDesc = this._description;
            return textDesc;
        }
    }
}