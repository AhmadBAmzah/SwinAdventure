using System;
using System.Collections.Generic;

namespace SwinAd
{
    class LookCommand : Command
    {
        public LookCommand() : base(new[] {"look"}){}

        public override string Execute(Player player, string[] text)
        {
            string response;
            if(text.Length == 5 && text[0] == "look")
            {
                IHaveInventory container = FetchContainer(player, text[4]);
                if(container != null)
                {
                    response = LookAtIn(text[2], container);
                    if(response != null)
                        return response;
                    return $"I can't find {text[2]}.";
                }
                else
                    return $"I can't find {text[4]}.";
            }
            else if(text.Length == 3 && text[0] == "look")
            {
                response = LookAtIn(text[2], player);
                if(response != null)
                    return response;
                return $"I can't find {text[2]}.";
            }
            return "Invalid Command: " + text.ToString();
        }

        private IHaveInventory FetchContainer(Player player, string container)
        {
            return player.Locate(container) as IHaveInventory;
        }

        private string LookAtIn(string thingId, IHaveInventory container)
        {
            GameObject obj = container.Locate(thingId);
            if(obj != null)
                return obj.longDesc();
            return null;
        }
    }
}