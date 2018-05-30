using System;
using System.Collections.Generic;
using NUnit.Framework;
namespace Task9
{
	[TestFixture()]
	public class PathUnitTest
	{
		[Test()]
		public void MovePlayerToDestination()
		{
			Location smallcloset = new Location(new String[] { "small closet" }, "smallcloset",
												"A small dark closet, with an odd smell", null);
			Path hallway_path = new Path(new String[] { "hallway", "South", }, smallcloset,
										 "You go through a door.", new Direction[] { Direction.South });
			Location hallway = new Location(new String[] { "hallway", "long hallway" }, "hallway",
											"This is a long well lit hallway", hallway_path);
			Player p = new Player("me", "mighty programmer", hallway, null);
			hallway_path.Move(p, "South");
			Assert.AreSame(smallcloset, p.Location);
		}

		[Test()]
		public void GetPathFromLocation()
		{
			Location smallcloset = new Location(new String[] { "small closet" }, "smallcloset",
											"A small dark closet, with an odd smell", null);
			Path hallway_path = new Path(new String[] { "hallway", "South", }, smallcloset,
										 "You go through a door.", new Direction[] { Direction.South });
			Location hallway = new Location(new String[] { "hallway", "long hallway" }, "hallway",
											"This is a long well lit hallway", hallway_path);
			Player p = new Player("me", "mighty programmer", hallway, null);
			Assert.IsInstanceOf<Path>(p.Location.Path);
		}

		[Test()]
		public void ValidPathIdentifier()
		{
			Location smallcloset = new Location(new String[] { "small closet" }, "smallcloset",
											"A small dark closet, with an odd smell", null);
			Path hallway_path = new Path(new String[] { "hallway", "South", }, smallcloset,
										 "You go through a door.", new Direction[] { Direction.South });
			Location hallway = new Location(new String[] { "hallway", "long hallway" }, "hallway",
											"This is a long well lit hallway", hallway_path);
			List<Location> locationlist = new List<Location>();
			locationlist.Add(hallway);
			locationlist.Add(smallcloset);
			Player p = new Player("me", "mighty programmer", hallway, null);

			string command = "move south";
			char delimiterChar = ' ';
			string[] cmd = command.Split(delimiterChar);

			MoveCommand move = new MoveCommand(new string[] { "move", "go", "head", "leave" });

			Assert.AreEqual("You head south\nYou go through a door.\nYou have arrived in smallcloset", move.Execute(p, cmd));
		}

		[Test()]
		public void InvalidPathIdentifier()
		{
			string command = "mov d";
			char delimiterChar = ' ';
			string[] cmd = command.Split(delimiterChar);
			Location smallcloset = new Location(new String[] { "small closet" }, "smallcloset",
										"A small dark closet, with an odd smell", null);
			Path hallway_path = new Path(new String[] { "hallway", "South", }, smallcloset,
										 "You go through a door.", new Direction[] { Direction.South });
			Location hallway = new Location(new String[] { "hallway", "long hallway" }, "hallway",
											"This is a long well lit hallway", hallway_path);
			Player p = new Player("me", "mighty programmer", hallway, null);
			MoveCommand move = new MoveCommand(new string[] { "move", "go", "head", "leave" });

			Assert.AreEqual("Invalid path identifier.", move.Execute(p, cmd));
		}

	}
}

