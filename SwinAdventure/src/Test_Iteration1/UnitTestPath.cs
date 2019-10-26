using System;
using NUnit.Framework;

namespace SwinAdventure
{
    [TestFixture()]
    public class TestPath
    {
        [Test()]
        public void Test_Path_LocateLocation()
        {
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Location newLocation = new Location(new[] {"house"}, "House", "Made of dirt...");
            Location newLocation1 = new Location(new[] { "mountain" }, "Mountain", "Careful of falling...");
            Path newPath = new Path(new[] {"north"}, newLocation1, false);

            newPlayer.Location = newLocation;
            newLocation.AddPath(newPath);
            newLocation1.Inventory.Put(newItem1);

            Assert.AreEqual(newLocation1, newPath.Location.Locate("mountain"), "Test Path Locate Location");
        }

        [Test()]
        public void Test_Path_LocateItem()
        {
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Location newLocation = new Location(new[] { "house" }, "House", "Made of dirt...");
            Location newLocation1 = new Location(new[] { "mountain" }, "Mountain", "Careful of falling...");
            Path newPath = new Path(new[] { "north" }, newLocation1, false);

            newPlayer.Location = newLocation;
            newLocation.AddPath(newPath);
            newLocation1.Inventory.Put(newItem1);

            Assert.AreEqual(newItem1, newPath.Location.Locate("sword"), "Test Path Locate Item");
        }

        [Test()]
        public void Test_Path_LocateNoItem()
        {
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Location newLocation = new Location(new[] { "house" }, "House", "Made of dirt...");
            Location newLocation1 = new Location(new[] { "mountain" }, "Mountain", "Careful of falling...");
            Path newPath = new Path(new[] { "north" }, newLocation1, false);

            newPlayer.Location = newLocation;
            newLocation.AddPath(newPath);
            newLocation1.Inventory.Put(newItem1);

            Assert.Null(newPath.Location.Locate("shield"), "Test Path Locate No Item");
        }

        [Test()]
        public void Test_Path_NotLocked()
        {
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Location newLocation = new Location(new[] { "house" }, "House", "Made of dirt...");
            Location newLocation1 = new Location(new[] { "mountain" }, "Mountain", "Careful of falling...");
            Path newPath = new Path(new[] { "north" }, newLocation1, false);

            newPlayer.Location = newLocation;
            newLocation.AddPath(newPath);
            newLocation1.Inventory.Put(newItem1);

            Assert.False(newPath.Locked, "Test Path Not Locked");
        }

        [Test()]
        public void Test_Path_Locked()
        {
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Location newLocation = new Location(new[] { "house" }, "House", "Made of dirt...");
            Location newLocation1 = new Location(new[] { "mountain" }, "Mountain", "Careful of falling...");
            Path newPath = new Path(new[] { "north" }, newLocation1, true);

            newPlayer.Location = newLocation;
            newLocation.AddPath(newPath);
            newLocation1.Inventory.Put(newItem1);

            Assert.True(newPath.Locked, "Test Path Locked");
        }
    }
}