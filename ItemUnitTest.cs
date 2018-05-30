using System;
using NUnit.Framework;
namespace Task9
{
	[TestFixture()]
	public class ItemUnitTest
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
	}
}

