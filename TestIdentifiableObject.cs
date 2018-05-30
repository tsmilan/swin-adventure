using System;
using NUnit.Framework;

namespace Task9
{
	[TestFixture()]
	public class TestIdentifiableObject
	{
		[Test()]
		public void TestItemIsIdentifiable()
		{
			Item shovel = new Item(new String[] { "shovel", "spade" }, "a shovel", "This is a might fine ...");
			Assert.True(shovel.AreYou("shovel")); 
		}

		[Test()]
		public void TestShortDescription()
		{
			Item shovel = new Item(new String[] { "shovel", "spade" }, "a shovel", "This is a might fine ...");
			Assert.AreEqual("a shovel (shovel)", shovel.ShortDescription);
		}

		[Test()]
		public void TestFullDescription()
		{
			Item shovel = new Item(new String[] { "shovel", "spade" }, "a shovel", "This is a might fine ...");
			Assert.AreEqual("This is a might fine ...", shovel.FullDescription);
		}

		[Test()]
		public void TestFindItem()
		{
			Item shovel = new Item(new String[] { "shovel", "spade" }, "a shovel", "This is a might fine ...");
			Player me = new Player("me", "inventory");
			me.Inventory.Put(shovel);
			Assert.True(me.Inventory.HasItem("shovel"));
		}

		[Test()]
		public void TestNoItemFind()
		{
			Item shovel = new Item(new String[] { "shovel", "spade" }, "a shovel", "This is a might fine ...");
			Player me = new Player("me", "inventory");
			me.Inventory.Put(shovel);
			Assert.False(me.Inventory.HasItem("sword"));
		}

		[Test()]
		public void TestFetchItem()
		{
			Item shovel = new Item(new String[] { "shovel", "spade" }, "a shovel", "This is a might fine ...");
			Player me = new Player("me", "inventory");
			me.Inventory.Put(shovel);
			Assert.AreEqual("shovel", me.Inventory.Fetch("shovel").FirstId());
		}

		[Test()]
		public void TestTakeItem()
		{
			Item shovel = new Item(new String[] { "shovel", "spade" }, "a shovel", "This is a might fine ...");
			Player me = new Player("me", "inventory");
			me.Inventory.Put(shovel);
			me.Inventory.Take(shovel);
			Assert.IsNull(me.Inventory.Fetch("shovel"));
		}

		[Test()]
		public void TestItemList()
		{
			Item shovel = new Item(new String[] { "shovel", "spade" }, "a shovel", "This is a might fine ...");
			Item sword = new Item(new String[] { "sword", "short sword" }, "a sword", "This is a short sword ...");
			Player me = new Player("me", "inventory");
			me.Inventory.Put(shovel);
			me.Inventory.Put(sword);

			Assert.AreEqual("\n\t" + shovel.ShortDescription + "\n\t" + sword.ShortDescription, me.Inventory.ItemList);
		}

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

