//using System;
//using NUnit.Framework;
//namespace Iteration78
//{
//	[TestFixture()]
//	public class LocationUnitTest
//	{
//		[Test()]
//		public void TestLocateSelf()
//		{
//			Location lc = new Location(new String[] { "hallway", "long hallway" }, "a hallway", "This is a long well lit hallway");
//			Assert.IsInstanceOf<Location>(lc.Locate("hallway"));
//		}

//		[Test()]
//		public void TestLocateItems()
//		{
//			Location lc = new Location(new String[] { "hallway", "long hallway" }, "a hallway", "This is a long well lit hallway");
//			Item shield = new Item(new String[] { "shield", "rusty shield" }, "a shield", "This is a shield");

//			lc.Inventory.Put(shield);

//			Assert.AreEqual("shield", lc.Locate("shield").FirstId());
//		}

//		[Test()]
//		public void TestPlayerLocateItemInLocation()
//		{
//			Location lc = new Location(new String[] { "hallway", "long hallway" }, "a hallway", "This is a long well lit hallway");

//			Player p = new Player("fred", "mighty programmer", lc);

//			Item shield = new Item(new String[] { "shield", "rusty shield" }, "a shield", "This is a shield");

//			lc.Inventory.Put(shield);

//			Assert.AreEqual("shield", p.Locate("shield").FirstId());
//		}

//	}
//}

