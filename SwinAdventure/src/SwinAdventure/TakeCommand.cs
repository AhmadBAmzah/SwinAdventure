using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class TakeCommand : Command
    {
        public TakeCommand() : base(new string[] { "take" }) { }

        public override string Execute(Player p, string[] text)
        {
            //take {object} from inventory
            //take {object} from {bag}
            //take {object} from {location}

            IHaveInventory Container;
            GameObject Object;
            if (text.Length == 4)
            {
                if (AreYou(text[0]))
                {
                    if(text[2] == "from")
                    {
                        Container = FetchContainer(p, text[3]);
                        if (Container != null)
                        {
                            Object = Container.Locate(text[1]);
                            if (Object != null)
                            {
                                Container.Inventory.Take((Item)Object);
                                return $"Taken {text[1]} from {text[3]}";
                            }
                            return $"Cannot find {text[1]} item";
                        }
                        return $"Cannot find {text[3]} container";
                    }
                    return "What do you want to take from";
                }
                return "Error in take input";
            }
            return "I don't know how to take that";
        }

        private IHaveInventory FetchContainer(Player p, string containerId)
        {
            IHaveInventory Container = (IHaveInventory)p.Locate(containerId);
            if(Container != null)
                return Container;
            else
                return (IHaveInventory)p.Location.Locate(containerId);
        }
    }
}
