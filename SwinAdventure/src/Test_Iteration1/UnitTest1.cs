using System;
using NUnit.Framework;

namespace SwinAdventure
{
    [TestFixture()]
    public class Test1
    {
        [Test()]
        public void Test_AreYou()
        {
            IdentifiableObject Object = new IdentifiableObject(new[] { "sword", "longsword" });
            Assert.True(Object.AreYou("sword"), "Test AreYou true");
        }

        [Test()]
        public void Test_NotAreYou()
        {
            IdentifiableObject Object = new IdentifiableObject(new[] { "sword", "longsword" });
            Assert.False(Object.AreYou("shield"), "Test AreYou false");
        }

        [Test()]
        public void Test_CaseSensitive()
        {
            IdentifiableObject Object = new IdentifiableObject(new[] { "sword", "longsword" });
            Assert.False(Object.AreYou("Sword"), "Test Case Sensitive");
        }

        [Test()]
        public void Test_FirstID()
        {
            IdentifiableObject Object = new IdentifiableObject(new[] { "sword", "longsword" });
            string firstID;
            firstID = Object.FirstId();
            Assert.AreEqual("sword", firstID, "Test FirstID");
        }

        [Test()]
        public void Test_AddID()
        {
            IdentifiableObject Object = new IdentifiableObject(new[] { "sword", "longsword" });
            Object.AddIdentifier("blade");
            Assert.True(Object.AreYou("blade"), "Test AddID");
        }
    }
}