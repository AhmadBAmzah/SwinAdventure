using System;
using NUnit.Framework;

namespace SwinAdventure
{
    [TestFixture()]
    public class TestPutCommand
    {
        [Test()]
        public void Test_PutCommand_PutItem()
        {
            Command newCommand = new PutCommand();
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Location newLocation = new Location(new[] { "house" }, "House", "Made of dirt...");
            newLocation.Inventory.Put(newItem1);
            newPlayer.Location = newLocation;

            Assert.AreEqual("sword has been placed in inventory", newCommand.Execute(newPlayer, new string[] { "put", "sword", "in", "inventory" }), "Test PutCommand_PutItem");
        }

        [Test()]
        public void Test_PutCommand_PutNoItem()
        {
            Command newCommand = new PutCommand();
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Location newLocation = new Location(new[] { "house" }, "House", "Made of dirt...");
            newPlayer.Location = newLocation;

            Assert.AreEqual("Cannot find sword item", newCommand.Execute(newPlayer, new string[] { "put", "sword", "in", "inventory" }), "Test PutCommand_PutNoItem");
        }

        [Test()]
        public void Test_PutCommand_PutNoContainer()
        {
            Command newCommand = new PutCommand();
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Location newLocation = new Location(new[] { "house" }, "House", "Made of dirt...");
            newLocation.Inventory.Put(newItem1);
            newPlayer.Location = newLocation;

            Assert.AreEqual("Cannot find bag to put sword in", newCommand.Execute(newPlayer, new string[] { "put", "sword", "in", "bag" }), "Test PutCommand_PutNoContainer");
        }

        [Test()]
        public void Test_PutCommand_NoPut()
        {
            Command newCommand = new PutCommand();
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Location newLocation = new Location(new[] { "house" }, "House", "Made of dirt...");
            newLocation.Inventory.Put(newItem1);
            newPlayer.Location = newLocation;

            Assert.AreEqual("Error in put input", newCommand.Execute(newPlayer, new string[] { "place", "sword", "in", "bag" }), "Test PutCommand_PutNoPut");
        }

        [Test()]
        public void Test_PutCommand_WrongInput()
        {
            Command newCommand = new PutCommand();
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Location newLocation = new Location(new[] { "house" }, "House", "Made of dirt...");
            newLocation.Inventory.Put(newItem1);
            newPlayer.Location = newLocation;

            Assert.AreEqual("I don't know how to put to that", newCommand.Execute(newPlayer, new string[] { "sword", "in", "bag" }), "Test PutCommand_PutWrongInput");
        }

        [Test()]
        public void Test_PutCommand_NoIn()
        {
            Command newCommand = new PutCommand();
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            Location newLocation = new Location(new[] { "house" }, "House", "Made of dirt...");
            newLocation.Inventory.Put(newItem1);
            newPlayer.Location = newLocation;

            Assert.AreEqual("What do you want to put in", newCommand.Execute(newPlayer, new string[] { "put", "sword", "inside", "bag" }), "Test PutCommand_PutNoIn");
        }
    }
}