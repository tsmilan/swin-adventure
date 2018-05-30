using System;
using NUnit.Framework;

namespace Task9
{
	[TestFixture()]
	public class BagUnitTest
	{
		[Test()]
		public void TestBagLocatesItems()
		{
			Item shovel = new Item(new String[] { "shovel", "spade" }, "a shovel", "This is a might fine ...");
			Item sword = new Item(new String[] { "sword", "short sword" }, "a sword", "This is a short sword ...");
			Bag mybag = new Bag(new String[] { "bag", "bag1" }, "awesome bag", "This is my bag");

			mybag.Inventory.Put(shovel);
			mybag.Inventory.Put(sword);
			Assert.AreEqual("shovel", mybag.Locate("shovel").FirstId());
			Assert.AreEqual("sword", mybag.Locate("sword").FirstId());
		}

		[Test()]
		public void TestBagLocatesItself()
		{
			Bag mybag = new Bag(new String[] { "bag", "bag1" }, "awesome bag", "This is my bag");
			Assert.IsInstanceOf<Bag>(mybag.Locate("bag"));
		}

		[Test()]
		public void TestBagLocatesNothing()
		{
			Item sword = new Item(new String[] { "sword", "short sword" }, "a sword", "This is a short sword ...");
			Bag mybag = new Bag(new String[] { "bag", "bag1" }, "awesome bag", "This is my bag");

			mybag.Inventory.Put(sword);
			Assert.IsNull(mybag.Locate("shovel"));
		}

		[Test()]
		public void TestBagFullDescription()
		{
			Item sword = new Item(new String[] { "sword", "short sword" }, "a sword", "This is a short sword ...");
			Bag mybag = new Bag(new String[] { "bag", "bag1" }, "awesome bag", "This is my bag");
			mybag.Inventory.Put(sword);
			Assert.AreEqual("In the " + mybag.Name + " you can see \n" + mybag.Inventory.ItemList, mybag.FullDescription);
		}

		[Test()]
		public void TestBagInBag()
		{
			Item shovel = new Item(new String[] { "shovel", "spade" }, "a shovel", "This is a might fine ...");
			Item sword = new Item(new String[] { "sword", "short sword" }, "a sword", "This is a short sword ...");
			Bag b1 = new Bag(new String[] { "b1", "bag1" }, "awesome bag 1", "This is my bag 1");
			Bag b2 = new Bag(new String[] { "b2", "bag2" }, "awesome bag 2", "This is my bag 2");

			b1.Inventory.Put(b2);
			b1.Inventory.Put(sword);
			b2.Inventory.Put(shovel);

			Assert.AreEqual("b2", b1.Locate("b2").FirstId());
			Assert.AreEqual("sword", b1.Locate("sword").FirstId());
			Assert.IsNull(b1.Locate("shovel"));
		}
	}
}

