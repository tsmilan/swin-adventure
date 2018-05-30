using System;
using NUnit.Framework;
namespace Task9
{
	[TestFixture()]
	public class InventoryUnitTest
	{
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
			Assert.IsInstanceOf<Item>(me.Inventory.Fetch("shovel"));
			Assert.AreSame(shovel, me.Inventory.Fetch("shovel"));
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
	}
}

