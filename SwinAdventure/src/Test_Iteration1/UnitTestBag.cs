using System;
using NUnit.Framework;

namespace SwinAdventure
{
    [TestFixture()]
    public class TestBag
    {
        [Test()]
        public void Test_Bag_LocateItem()
        {
            Bag newBag = new Bag(new[] {"sock", "bag"}, "Sock", "It has a hole in it...");
            Item newItem = new Item(new[] { "hamster", "food" }, "Hamster", "Tasty...");
            newBag.Inventory.Put(newItem);
            Assert.AreEqual(newItem, newBag.Locate("hamster"), "Test Bag_LocateItem");
        }

        [Test()]
        public void Test_Bag_LocateBag()
        {
            Bag newBag = new Bag(new[] { "sock", "bag" }, "Sock", "It has a hole in it...");
            Item newItem = new Item(new[] { "hamster", "food" }, "Hamster", "Tasty...");
            newBag.Inventory.Put(newItem);
            Assert.AreEqual(newBag, newBag.Locate("bag"), "Test Bag_LocateBag");
        }

        [Test()]
        public void Test_Bag_LocateNothing()
        {
            Bag newBag = new Bag(new[] { "sock", "bag" }, "Sock", "It has a hole in it...");
            Item newItem = new Item(new[] { "hamster", "food" }, "Hamster", "Tasty...");
            newBag.Inventory.Put(newItem);
            Assert.Null(newBag.Locate("sword"), "Test Bag_LocateNothing");
        }

        [Test()]
        public void Test_Bag_LongDescription()
        {
            Bag newBag = new Bag(new[] { "sock", "bag" }, "Sock", "It has a hole in it...");
            Item newItem = new Item(new[] { "hamster", "food" }, "Hamster", "Tasty...");

            newBag.Inventory.Put(newItem);

            Assert.AreEqual("In the Sock you can see:\na Hamster (hamster): Tasty...\n", newBag.LongDescription, "Test Bag_LongDescription");
        }

        [Test()]
        public void Test_Bag_MultipleBags()
        {
            Bag newBag1 = new Bag(new[] {"pouch"}, "Pouch", "Too small...");
            Bag newBag2 = new Bag(new[] { "sock", "bag" }, "Sock", "It has a hole in it...");
            Item newItem1 = new Item(new[] { "hamster", "food" }, "Hamster", "Tasty...");
            Item newItem2 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");

            newBag2.Inventory.Put(newItem1);
            newBag1.Inventory.Put(newItem2);
            newBag1.Inventory.Put(newBag2);

            Assert.AreEqual(newBag2, newBag1.Locate("sock"), "Test Bag_MultiplBagsLocateBag");
            Assert.AreEqual(newItem2, newBag1.Locate("sword"), "Test Bag_MultiplBagsLocateItem");
            Assert.Null(newBag1.Locate("hamster"), "Test Bag_MultiplBagsLocateNotItem");
        }
    }
}