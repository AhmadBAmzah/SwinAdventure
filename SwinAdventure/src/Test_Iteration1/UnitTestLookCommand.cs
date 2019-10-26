using System;
using NUnit.Framework;

namespace SwinAdventure
{
    [TestFixture()]
    public class TestLookCommand
    {
        [Test()]
        public void Test_LookCommand_LookAtMe()
        {
            Player newPlayer = new Player("John", "The Knight");
            Command newCommand = new LookCommand();

            Assert.AreEqual("You are carrying:\n", newCommand.Execute(newPlayer, new string[] {"look", "at", "inventory"}), "Test LookCommand_LookAtMe");
        }

        [Test()]
        public void Test_LookCommand_LookAtGem()
        {
            Command newCommand = new LookCommand();
            Player newPlayer = new Player("John", "The Knight");
            Item newItem = new Item(new[] { "gem", "stone" }, "Gem", "Shiny...");
            newPlayer.Inventory.Put(newItem);
            
            Assert.AreEqual("Shiny...", newCommand.Execute(newPlayer, new string[] { "look", "at", "gem" }), "Test LookCommand_Gem");
        }

        [Test()]
        public void Test_LookCommand_LookAtUnk()
        {
            Command newCommand = new LookCommand();
            Player newPlayer = new Player("John", "The Knight");
            
            Assert.AreEqual("I cannot find the gem", newCommand.Execute(newPlayer, new string[] { "look", "at", "gem" }), "Test LookCommand_NoGem");
        }

        [Test()]
        public void Test_LookCommand_LookAtGemInMe()
        {
            Command newCommand = new LookCommand();
            Player newPlayer = new Player("John", "The Knight");
            Item newItem = new Item(new[] { "gem", "stone" }, "Gem", "Shiny...");
            newPlayer.Inventory.Put(newItem);

            Assert.AreEqual("Shiny...", newCommand.Execute(newPlayer, new string[] { "look", "at", "gem", "in", "me" }), "Test LookCommand_GemInMe");
        }

        [Test()]
        public void Test_LookCommand_LookAtGemInBag()
        {
            Command newCommand = new LookCommand();
            Player newPlayer = new Player("John", "The Knight");
            Item newItem = new Item(new[] { "gem", "stone" }, "Gem", "Shiny...");
            Bag newBag = new Bag(new[] { "sock", "bag" }, "Sock", "Smells like cheese...");

            newBag.Inventory.Put(newItem);
            newPlayer.Inventory.Put(newBag);

            Assert.AreEqual("Shiny...", newCommand.Execute(newPlayer, new string[] { "look", "at", "gem", "in", "bag" }), "Test LookCommand_GemInBag");
        }

        [Test()]
        public void Test_LookCommand_LookAtGemInNoBag()
        {
            Command newCommand = new LookCommand();
            Player newPlayer = new Player("John", "The Knight");
            Item newItem = new Item(new[] { "gem", "stone" }, "Gem", "Shiny...");
            Bag newBag = new Bag(new[] { "sock", "bag" }, "Sock", "Smells like cheese...");

            newBag.Inventory.Put(newItem);

            Assert.AreEqual("I cannot find the bag", newCommand.Execute(newPlayer, new string[] { "look", "at", "gem", "in", "bag" }), "Test LookCommand_GemInNoBag");
        }

        [Test()]
        public void Test_LookCommand_LookAtNoGemInBag()
        {
            Command newCommand = new LookCommand();
            Player newPlayer = new Player("John", "The Knight");
            Item newItem = new Item(new[] { "gem", "stone" }, "Gem", "Shiny...");
            Bag newBag = new Bag(new[] { "sock", "bag" }, "Sock", "Smells like cheese...");
            Location newLocation = new Location(new[] { "house" }, "House", "Made of dirt...");
            newPlayer.Location = newLocation;

            newPlayer.Inventory.Put(newBag);

            Assert.AreEqual("I cannot find the gem in the bag", newCommand.Execute(newPlayer, new string[] { "look", "at", "gem", "in", "bag" }), "Test LookCommand_NoGemInBag");
        }

        [Test()]
        public void Test_LookCommand_LookInvalid()
        {
            Player newPlayer = new Player("John", "The Knight");
            Command newCommand = new LookCommand();
            Item newItem = new Item(new[] { "gem", "stone" }, "Gem", "Shiny...");
            Bag newBag = new Bag(new[] { "sock", "bag" }, "Sock", "Smells like cheese...");

            newBag.Inventory.Put(newItem);
            newPlayer.Inventory.Put(newBag);

            Assert.AreEqual("I don't know how to look like that", newCommand.Execute(newPlayer, new string[] { "look", "around" }), "Test LookCommand_LookInvalidNumber");
            Assert.AreEqual("Error in look input", newCommand.Execute(newPlayer, new string[] { "hello", "at", "me" }), "Test LookCommand_LookInvalidNoLook");
            Assert.AreEqual("What do you want to look at", newCommand.Execute(newPlayer, new string[] { "look", "in", "me" }), "Test LookCommand_LookInvalidNoAt");
            Assert.AreEqual("What do you want to look in", newCommand.Execute(newPlayer, new string[] { "look", "at", "me", "at", "bag" }), "Test LookCommand_LookInvalidNoIn");
        }
    }
}