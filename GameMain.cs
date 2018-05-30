using System;
namespace Task9
{
	public class GameMain
	{
		public GameMain()
		{
		}

		public static void Main()
		{

			//char delimiterChar = ' ';

			//string text = "one two three four five six seven";
			//string[] words = text.Split(delimiterChar);

			//foreach (string s in words)
			//{
			//	System.Console.WriteLine(s);
			//}
			string name, desc;

			Console.WriteLine("What's your name?");
			name = Console.ReadLine();
			Console.WriteLine("Tell me something about yourself");
			desc = Console.ReadLine();

			Console.WriteLine(name, desc);
			//Player p = new Player(name, desc);

			//Item shovel = new Item(new String[] { "shovel", "spade" }, "a shovel", "This is a might fine ...");
			//Item sword = new Item(new String[] { "sword", "short sword" }, "a sword", "This is a short sword ...");

			//p.Inventory.Put(shovel);
			//p.Inventory.Put(sword);

			//Bag b1 = new Bag(new String[] { "b1", "bag1" }, "awesome bag 1", "This is my bag 1");
			//p.Inventory.Put(b1);

			//Item shield = new Item(new String[] { "shield", "rusty shield" }, "a shield", "This is a shield");
			//b1.Inventory.Put(shield);

			//Console.WriteLine("Enter look commands, or type quit to exit.");
			//while (Console.ReadLine().ToLower() != "quit")
			//{
			//	LookCommand look = new LookCommand(new string[] { "look" });

			//	Console.WriteLine(look.Execute(p, words));
			//}

			//Player me = new Player("me", "inventory");
			//Item gem = new Item(new String[] { "gem", "my gem" }, "a gem", "A bright red ...");
			//Bag mybag = new Bag(new String[] { "bag", "bag1" }, "awesome bag", "This is my bag");
			//mybag.Inventory.Put(gem);
			//LookCommand look = new LookCommand(new string[] { "look" });
			//Console.WriteLine(look.Execute(me, new string[] { "look", "around" }));
			//Console.WriteLine(look.Execute(me, new string[] { "hello" }));
			//Console.WriteLine(look.Execute(me, new string[] { "look", "at", "a", "at", "b" }));
			//Console.WriteLine(look.Execute(me, new string[] { "look", "at", "look", "around"}));

		}
	}
}

