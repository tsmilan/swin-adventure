using System;
using System.Collections.Generic;
using Gtk;
using Iteration78;
using SwinAdv;

public partial class MainWindow : Gtk.Window
{
	private string _playername = ""; 
	private string _desc;
	private Player _player;
	private Location _defaultLocation;
	private List<Location> _locationlist;

	public MainWindow() : base(Gtk.WindowType.Toplevel)
	{
		Build();
		InitializeLocation();
		commandText.Hide();
		descText.Hide();

		_player = new Player("me", "" ,_defaultLocation, _locationlist);
		Iteration78.Item shovel = new Iteration78.Item(new String[] { "shovel", "cool shovel" }, "a shovel", "This is a shovel ...");
		Iteration78.Item sword = new Iteration78.Item(new String[] { "sword", "short sword" }, "a sword", "This is a short sword ...");
		Iteration78.Item paper = new Iteration78.Item(new String[] { "paper" }, "a paper", "This is a white paper ...");

		_player.Inventory.Put(shovel);
		_player.Inventory.Put(sword);

		Bag bag = new Bag(new String[] { "bag" }, "leather bag", "This is my bag.");
		_player.Inventory.Put(bag);
		bag.Inventory.Put(paper);

		TextArea.Buffer.Text = "What's your name?";
		CommandButton.Clicked += GetInfo;
	}

	protected void OnDeleteEvent(object sender, DeleteEventArgs a)
	{
		Application.Quit();
		a.RetVal = true;
	}

	protected void GetInfo(object obj, EventArgs args)
	{
		if (_playername == "")
		{
			_playername = playerText.Text;
			_player.AddIdentifier(_playername);
			playerText.Text = "";
			playerText.Hide();
			descText.Show();
			TextArea.Buffer.Text = "Tell me something about yourself";
		}
		else if (!IsEmpty(descText.Text) && !IsEmpty(_playername))
		{
			_desc = descText.Text;
			_player.Description = _desc;
			descText.Text = "";
			descText.Hide();
			commandText.Show();
			TextArea.Buffer.Text = "Enter commands or type quit to exit";
		}
		else 
		{
            string command = commandText.Text.ToLower();
			char delimiterChar = ' ';
			string[] cmd = command.Split(delimiterChar);
			LookCommand look = new LookCommand(new string[] { "look" });
			MoveCommand move = new MoveCommand(new string[] { "move", "go", "head", "leave" });
			PutCommand put = new PutCommand(new string[] { "put", "drop"});
			TakeCommand take = new TakeCommand(new string[] { "pickup", "take" });
			CommandProcessor cp = new CommandProcessor(new string[] { }, new Command[] { look, move, put, take });
			TextArea.Buffer.Text = cp.Execute(_player, cmd);
		}

	}

	protected bool IsEmpty(string str)
	{
		return str == "";
	}

	protected void InitializeLocation()
	{
		Path smallgarden_path = new Path(new String[] { "smallgarden", "smallcloset", "South", "North" }, null, "You go through a door2.", new Direction[] { Iteration78.Direction.South, Iteration78.Direction.North });
		Location smallgarden = new Location(new String[] { "small garden" }, "smallgarden", "There are many small shrubs and flowers growing from well tended garden beds.", smallgarden_path);
		Path smallcloset_path = new Path(new String[] { "smallcloset", "hallway", "East", "North" }, smallgarden, "You travel through a small door, and then crawl a few meters before " + "arriving from the north", new Direction[] {Iteration78.Direction.East, Iteration78.Direction.North });
		Location smallcloset = new Location(new String[] { "small closet" }, "smallcloset", "A small dark closet, with an odd smell", smallcloset_path);
		Path hallway_path = new Path(new String[] { "hallway", "South", }, smallcloset, "You go through a door.", new Direction[] { Iteration78.Direction.South });
		Location hallway = new Location(new String[] { "hallway", "long hallway" }, "hallway", "This is a long well lit hallway", hallway_path);

		List<Location> locationlist = new List<Location>();
		locationlist.Add(hallway);
		locationlist.Add(smallcloset);
		locationlist.Add(smallgarden);

		_defaultLocation = hallway;
		_locationlist = locationlist;

		Iteration78.Item shovel = new Iteration78.Item(new String[] { "shovel", "cool shovel" }, "a shovel", "This is a shovel ...");
		Iteration78.Item sword = new Iteration78.Item(new String[] { "sword", "short sword" }, "a sword", "This is a short sword ...");
		Iteration78.Item shield = new Iteration78.Item(new String[] { "shield", "rusty shield" }, "a shield", "This is a shield");

		hallway.Inventory.Put(shield);
		smallcloset.Inventory.Put(shovel);
		smallgarden.Inventory.Put(sword);
	
	}

}
