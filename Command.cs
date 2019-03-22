using System;
using System.Collections.Generic;

namespace SwinAd
{
    abstract class Command : IdentifiableObject
    {
        public Command(string[] ids) : base(ids){}

        public abstract string Execute(Player player, string[] text);
    }
}