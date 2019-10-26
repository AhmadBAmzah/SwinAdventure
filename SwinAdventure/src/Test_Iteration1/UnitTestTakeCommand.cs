using System;
using NUnit.Framework;

namespace SwinAdventure
{
    [TestFixture()]
    public class TestTakeCommand
    {
        [Test()]
        public void Test_TakeCommand_TakeItem()
        {
            Command newCommand = new TakeCommand();
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Location newLocation = new Location(new[] { "house" }, "House", "Made of dirt...");
            newPlayer.Inventory.Put(newItem1);
            newPlayer.Location = newLocation;

            Assert.AreEqual("Taken sword from inventory", newCommand.Execute(newPlayer, new string[] { "take", "sword", "from", "inventory" }), "Test TakeCommand_TakeItem");
        }

        [Test()]
        public void Test_TakeCommand_TakeNoItem()
        {
            Command newCommand = new TakeCommand();
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Location newLocation = new Location(new[] { "house" }, "House", "Made of dirt...");
            newPlayer.Location = newLocation;

            Assert.AreEqual("Cannot find sword item", newCommand.Execute(newPlayer, new string[] { "take", "sword", "from", "inventory" }), "Test TakeCommand_TakeNoItem");
        }

        [Test()]
        public void Test_TakeCommand_TakeNoContainer()
        {
            Command newCommand = new TakeCommand();
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Location newLocation = new Location(new[] { "house" }, "House", "Made of dirt...");
            newPlayer.Inventory.Put(newItem1);
            newPlayer.Location = newLocation;

            Assert.AreEqual("Cannot find bag container", newCommand.Execute(newPlayer, new string[] { "take", "sword", "from", "bag" }), "Test TakeCommand_TakeNoContainer");
        }

        [Test()]
        public void Test_TakeCommand_TakeNoFrom()
        {
            Command newCommand = new TakeCommand();
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Location newLocation = new Location(new[] { "house" }, "House", "Made of dirt...");
            newPlayer.Inventory.Put(newItem1);
            newPlayer.Location = newLocation;

            Assert.AreEqual("What do you want to take from", newCommand.Execute(newPlayer, new string[] { "take", "sword", "fom", "inventory" }), "Test TakeCommand_TakeNoFrom");
        }

        [Test()]
        public void Test_TakeCommand_TakeNoTake()
        {
            Command newCommand = new TakeCommand();
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Location newLocation = new Location(new[] { "house" }, "House", "Made of dirt...");
            newPlayer.Inventory.Put(newItem1);
            newPlayer.Location = newLocation;

            Assert.AreEqual("Error in take input", newCommand.Execute(newPlayer, new string[] { "get", "sword", "from", "inventory" }), "Test TakeCommand_TakeNoTake");
        }

        [Test()]
        public void Test_TakeCommand_TakeWrongInputs()
        {
            Command newCommand = new TakeCommand();
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Location newLocation = new Location(new[] { "house" }, "House", "Made of dirt...");
            newPlayer.Inventory.Put(newItem1);
            newPlayer.Location = newLocation;

            Assert.AreEqual("I don't know how to take that", newCommand.Execute(newPlayer, new string[] { "sword", "from", "inventory" }), "Test TakeCommand_TakeWrongInputs");
        }
    }
}