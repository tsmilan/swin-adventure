using System;
using NUnit.Framework;
namespace Task9
{
	[TestFixture()]
	public class PlayerUnitTest
	{
		
		[Test()]
		public void TestPlayerIsIdentifiable()
		{
			Player me = new Player("me", "inventory");
			Assert.True(me.AreYou("me"));
			Assert.True(me.AreYou("inventory"));
		}

		[Test()]
		public void TestPlayerLocatesItems()
		{
			Item shovel = new Item(new String[] { "shovel", "spade" }, "a shovel", "This is a might fine ...");
			Item sword = new Item(new String[] { "sword", "short sword" }, "a sword", "This is a short sword ...");
			Player me = new Player("me", "inventory");
			me.Inventory.Put(shovel);
			me.Inventory.Put(sword);

			Assert.AreEqual("sword", me.Locate("sword").FirstId());
		}

		[Test()]
		public void TestPlayerLocatesItself()
		{
			Item shovel = new Item(new String[] { "shovel", "spade" }, "a shovel", "This is a might fine ...");
			Item sword = new Item(new String[] { "sword", "short sword" }, "a sword", "This is a short sword ...");
			Player me = new Player("me", "inventory");
			me.Inventory.Put(shovel);
			me.Inventory.Put(sword);

			Assert.AreEqual("me", me.Locate("me").FirstId());
		}

		[Test()]
		public void TestPlayerLocatesNothing()
		{
			Item shovel = new Item(new String[] { "shovel", "spade" }, "a shovel", "This is a might fine ...");
			Item sword = new Item(new String[] { "sword", "short sword" }, "a sword", "This is a short sword ...");
			Player me = new Player("me", "inventory");
			me.Inventory.Put(shovel);
			me.Inventory.Put(sword);

			Assert.IsNull(me.Locate("You"));
		}

		[Test()]
		public void TestPlayerFullDescription()
		{
			Item shovel = new Item(new String[] { "shovel", "spade" }, "a shovel", "This is a might fine ...");
			Item sword = new Item(new String[] { "sword", "short sword" }, "a sword", "This is a short sword ...");
			Player me = new Player("me", "inventory");
			me.Inventory.Put(shovel);
			me.Inventory.Put(sword);

			Assert.AreEqual("You are carrying:" + "\n\t" + shovel.ShortDescription + "\n\t" + sword.ShortDescription, me.FullDescription);
		}
	}
}

