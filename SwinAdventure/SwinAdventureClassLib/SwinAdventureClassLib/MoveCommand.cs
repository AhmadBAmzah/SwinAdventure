using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    public class MoveCommand : Command
    {
        public MoveCommand() : base(new string[] {"move", "go", "head", "leave"}) {}

        public override string Execute(Player p, string[] text)
        {
            Path NewPath;
            if (text.Length == 2)
            {
                if(AreYou(text[0]))
                {
                    NewPath = p.Location.FetchPath(text[1]);
                    if(NewPath != null)
                    {
                        if(!NewPath.Locked)
                        {
                            p.Location = NewPath.Location;
                            return $"Player moved to {text[1]} location";
                        }
                        return $"{text[1]} path is blocked";
                    }
                    return $"{text[1]} path does not exist";
                }
                return "Error in move input";
            }
            return "I don't know how to move to that";
        }
    }
}
