using System;
using NUnit.Framework;

namespace SwinAdventure
{
    [TestFixture()]
    public class TestInventory
    {
        [Test()]
        public void Test_Inv_ItemFind()
        {
            Inventory newInv = new Inventory();
            Item newItem = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            newInv.Put(newItem);
            Assert.AreEqual(newItem, newInv.Fetch("longsword"), "Test Inv Item Find");
        }

        [Test()]
        public void Test_Inv_NoItemFind()
        {
            Inventory newInv = new Inventory();
            Item newItem = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            newInv.Put(newItem);
            Assert.Null(newInv.Fetch("shield"), "Test Inv No Item Find");
        }

        [Test()]
        public void Test_Inv_Fetch()
        {
            Inventory newInv = new Inventory();
            Item newItem = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            newInv.Put(newItem);
            newInv.Fetch("longsword");
            Assert.AreEqual(newItem, newInv.Fetch("longsword"), "Test Inv Fetch");
        }

        [Test()]
        public void Test_Inv_Take()
        {
            Inventory newInv = new Inventory();
            Item newItem = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            newInv.Put(newItem);
            newInv.Take(newItem);
            Assert.Null(newInv.Fetch("sword"), "Test Inv Take"); 
        }

        [Test()]
        public void Test_Inv_ItemList()
        {
            Inventory newInv = new Inventory();
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Item newItem2 = new Item(new[] { "shield", "board" }, "Shield", "Door Squad");
            newInv.Put(newItem1);
            newInv.Put(newItem2);
            Assert.AreEqual("a Sword (sword): Slice and Dice", newInv.ItemList()[0], "Test Inv ItemList");
        }       
    }
}