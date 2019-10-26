using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class LookCommand : Command
    {
        public LookCommand() : base(new string[] {"look"}) {}

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory Container;
            String Result;
            if(text.Length == 3 || text.Length == 5)
            {
                if(AreYou(text[0]))
                {
                    if(text[1] == "at")
                    {
                        if(text.Length == 5)
                        {
                            if(text[3] == "in")
                            {
                                Container = FetchContainer(p, text[4]);
                                if (Container != null)
                                {
                                    Result = LookAtIn(text[2], Container);
                                    if (Result != null)
                                    {
                                        return Result;
                                    }
                                    else
                                    {
                                        return $"I cannot find the {text[2]} in the {text[4]}";
                                    }
                                }
                                else
                                {
                                    return $"I cannot find the {text[4]}";
                                }
                            }
                            else
                            {
                                return "What do you want to look in";
                            }
                        }
                        else
                        {
                            Result = LookAtIn(text[2], p);
                            if (Result != null)
                                return Result;
                            else
                            {
                                Result = LookAtIn(text[2], p.Location);
                                if (Result != null)
                                    return Result;
                                return $"I cannot find the {text[2]}";
                            }
                        }
                    }
                    else
                    {
                        return "What do you want to look at";
                    }
                }
                else
                {
                    return "Error in look input";
                }
            }
            else
            {
                return "I don't know how to look like that";
            }
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            var LocateObject = container.Locate(thingId);
            if (LocateObject != null)
                return LocateObject.LongDescription;
            else
                return null;
        }
		
		private IHaveInventory FetchContainer(Player p, string containerId)
        {
            return (IHaveInventory)p.Locate(containerId);
        }
    }
}
