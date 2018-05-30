using System;
using NUnit.Framework;

namespace Task9
{
	[TestFixture()]
	public class LookCommandUnitTest
	{
		[Test()]
		public void TestLookAtMe()
		{
			Player me = new Player("me", "inventory");
			LookCommand look = new LookCommand(new string[] { "look" });
			Assert.AreEqual("You are carrying:",look.Execute(me, new string[] { "look", "at", "me" }));
		}

		[Test()]
		public void TestLookAtGem()
		{
			Player me = new Player("me", "inventory");
			Item gem = new Item(new String[] { "gem", "my gem" }, "a gem", "A bright red ...");
			me.Inventory.Put(gem);
			LookCommand look = new LookCommand(new string[] { "look" });
			Assert.AreSame("A bright red ...", look.Execute(me, new string[] { "look", "at", "gem" }));
		}

		[Test()]
		public void TestLookAtUnk()
		{
			Player me = new Player("me", "inventory");
			Item gem = new Item(new String[] { "gem", "my gem" }, "a gem", "A bright red ...");
			Bag mybag = new Bag(new String[] { "bag", "bag1" }, "awesome bag", "This is my bag");
			mybag.Inventory.Put(gem);
			LookCommand look = new LookCommand(new string[] { "look" });
			Assert.AreEqual("I can't find the gem", look.Execute(me, new string[] { "look", "at", "gem", "in", "inventory" }));
		}

		[Test()]
		public void TestLookAtGemInMe()
		{
			Player me = new Player("me", "inventory");
			Item gem = new Item(new String[] { "gem", "my gem" }, "a gem", "A bright red ...");
			me.Inventory.Put(gem);
			LookCommand look = new LookCommand(new string[] { "look" });
			Assert.AreSame("A bright red ...", look.Execute(me, new string[] { "look", "at", "gem", "in", "inventory" }));
		}

		[Test()]
		public void TestLookAtGemInBag()
		{
			Player me = new Player("me", "inventory");
			Item gem = new Item(new String[] { "gem", "my gem" }, "a gem", "A bright red ...");
			Bag mybag = new Bag(new String[] { "bag", "bag1" }, "awesome bag", "This is my bag");
			mybag.Inventory.Put(gem);
			me.Inventory.Put(mybag);
			LookCommand look = new LookCommand(new string[] { "look" });
			Assert.AreSame("A bright red ...", look.Execute(me, new string[] { "look", "at", "gem", "in", "bag" }));
		}

		[Test()]
		public void TestLookAtGemInNoBag()
		{
			Player me = new Player("me", "inventory");
			Item gem = new Item(new String[] { "gem", "my gem" }, "a gem", "A bright red ...");
			me.Inventory.Put(gem);
			LookCommand look = new LookCommand(new string[] { "look" });
			Assert.AreEqual("I can't find the bag", look.Execute(me, new string[] { "look", "at", "gem", "in", "bag" }));
		}

		[Test()]
		public void TestLookAtNoGemInBag()
		{
			Player me = new Player("me", "inventory");
			Bag mybag = new Bag(new String[] { "bag", "bag1" }, "awesome bag", "This is my bag");
			me.Inventory.Put(mybag);
			LookCommand look = new LookCommand(new string[] { "look" });
			Assert.AreEqual("I can't find the gem", look.Execute(me, new string[] { "look", "at", "gem", "in", "bag" }));
		}

		[Test()]
		public void TestInvalidLook()
		{
			Player me = new Player("me", "inventory");
			LookCommand look = new LookCommand(new string[] { "look" });
			Assert.AreEqual("Error in look input", look.Execute(me, new string[] { "look", "around" }));
			Assert.AreEqual("Error in look input", look.Execute(me, new string[] { "hello" }));
			Assert.AreEqual("What do you want to look in?",look.Execute(me, new string[] { "look", "at", "a", "at", "b" }));
			Assert.AreEqual("I don't know how to look like that", look.Execute(me, new string[] { "look", "at", "look", "around" }));
		}

	}
}

