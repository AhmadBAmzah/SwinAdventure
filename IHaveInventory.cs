using System;
using System.Collections.Generic;

namespace SwinAd
{
    interface IHaveInventory
    {
        GameObject Locate(string id);

        string Name();
    }
}