using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    class IdentifiableObject
    {
        private List<string> _identifier {get; set;}

        public IdentifiableObject(){}
        
        public IdentifiableObject(string[] idents)
        {
            this._identifier = new List<string>(idents);
        }

        public virtual bool areYou(string id)
        {
            return this._identifier.Contains(id);
        }

        public string firstId()
        {
            return this._identifier[0];
        }

        public void addIdentifier(string addId)
        {
            this._identifier.Add(addId.ToLower());
        }
    }
}