using System;
using NUnit.Framework;

namespace SwinAdventure
{
    [TestFixture()]
    public class TestLocation
    {
        [Test()]
        public void Test_Location_Locate_Location()
        {
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Location newLocation = new Location(new[] {"house"}, "House", "Made of dirt...");
            newLocation.Inventory.Put(newItem1);
            newPlayer.Location = newLocation;

            Assert.AreEqual(newLocation, newPlayer.Location.Locate("house"), "Test Location Locate Location");
        }

        [Test()]
        public void Test_Location_Locate_Item()
        {
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Location newLocation = new Location(new[] { "house" }, "House", "Made of dirt...");
            newLocation.Inventory.Put(newItem1);
            newPlayer.Location = newLocation;

            Assert.AreEqual(newItem1, newPlayer.Location.Locate("sword"), "Test Location Locate Item");
        }

        [Test()]
        public void Test_Location_Locate_NoItem()
        {
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Location newLocation = new Location(new[] { "house" }, "House", "Made of dirt...");
            newLocation.Inventory.Put(newItem1);
            newPlayer.Location = newLocation;

            Assert.Null(newPlayer.Location.Locate("shield"), "Test Location Locate No Item");
        }
    }
}