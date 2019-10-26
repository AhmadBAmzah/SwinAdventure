using System;
using NUnit.Framework;

namespace SwinAdventure
{
    [TestFixture()]
    public class TestItem
    {
        [Test()]
        public void Test_Item_AreYou()
        {
            Item newItem = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Assert.True(newItem.AreYou("sword"), "Test Item AreYou true");
        }

        [Test()]
        public void Test_Item_ShortDesc()
        {
            Item newItem = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Assert.AreEqual("a Sword (sword)", newItem.ShortDescription, "Test Item ShortDesc");
        }

        [Test()]
        public void Test_Item_LongDesc()
        {
            Item newItem = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Assert.AreEqual("Slice and Dice", newItem.LongDescription, "Test Item LongDesc");
        }
    }
}