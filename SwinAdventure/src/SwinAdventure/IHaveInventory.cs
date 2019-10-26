using System;
using System.Collections.Generic;

namespace SwinAdventure
{
    interface IHaveInventory
    {
        GameObject Locate(string id);
		string Name {get;}
        Inventory Inventory {get;}
    }
}
