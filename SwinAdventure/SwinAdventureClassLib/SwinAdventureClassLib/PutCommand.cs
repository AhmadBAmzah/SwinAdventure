using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class PutCommand : Command
    {
        public PutCommand() : base(new string[] {"put"}) {}

        public override string Execute(Player p, string[] text)
        {
            //put {object} in inventory
            //put {object} in {bag}

            IHaveInventory Container;
            GameObject Object;
            if(text.Length == 4)
            {
                if (AreYou(text[0]))
                {
                    Object = FetchObject(p, text[1]);
                    if(Object != null)
                    {
                        if (text[2] == "in")
                        {
                            Container = FetchContainer(p, text[3]);
                            if (Container != null)
                            {
                                Container.Inventory.Put((Item)Object);
                                return $"{text[1]} has been placed in {text[3]}";
                            }
                            return $"Cannot find {text[3]} to put {text[1]} in";
                        }
                        return "What do you want to put in";
                    }
                    return $"Cannot find {text[1]} item";
                }
                return "Error in put input";
            }
            return "I don't know how to put to that";
        }

        private GameObject FetchObject(Player p, string objectId)
        {
            GameObject Object = p.Location.Locate(objectId);
            if (Object != null)
                return p.Location.Inventory.Take((Item)Object);
            return null;
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return (IHaveInventory)p.Locate(containerId);
        }
    }
}
