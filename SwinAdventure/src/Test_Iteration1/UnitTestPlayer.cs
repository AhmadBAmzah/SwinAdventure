using System;
using NUnit.Framework;

namespace SwinAdventure
{
    [TestFixture()]
    public class TestPlayer
    {
        [Test()]
        public void Test_Player_AreYou()
        {
            Player newPlayer = new Player("John", "The Knight");
            Assert.True(newPlayer.AreYou("me"), "Test Player AreYou");
        }

        [Test()]
        public void Test_Player_Locate_Item()
        {
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            newPlayer.Inventory.Put(newItem1);
            Assert.AreEqual(newItem1, newPlayer.Locate("sword"), "Test Player Locate Item");
        }

        [Test()]
        public void Test_Player_Locate_Player()
        {
            Player newPlayer = new Player("John", "The Knight");
            Assert.AreEqual(newPlayer, newPlayer.Locate("me"), "Test Player Locate Player");
        }

        [Test()]
        public void Test_Player_Locate_Nothing()
        {
            Player newPlayer = new Player("John", "The Knight");
            Assert.Null(newPlayer.Locate("shield"), "Test Player Locate Nothing");
        }

        [Test()]
        public void Test_Player_Locate_LongDesc()
        {
            Player newPlayer = new Player("John", "The Knight");
            Item newItem1 = new Item(new[] { "sword", "longsword" }, "Sword", "Slice and Dice");
            newPlayer.Inventory.Put(newItem1);
            Assert.AreEqual("You are carrying:\na Sword (sword): Slice and Dice\n", newPlayer.LongDescription, "Test Player LongDesc");
        }
    }
}