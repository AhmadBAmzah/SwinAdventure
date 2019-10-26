using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class IdentifiableObject
    {
        private List<string> _identifier;
        
        public IdentifiableObject(string[] idents)
        {
            _identifier = new List<string>(idents);
        }

        public virtual bool AreYou(string id)
        {
            return _identifier.Contains(id);
        }

        public string FirstId()
        {
            return _identifier[0];
        }

        public void AddIdentifier(string addId)
        {
            _identifier.Add(addId.ToLower());
        }
    }
}