using System;
namespace Task9
{
	public class Location : GameObject, IHaveInventory
	{
		private Inventory _inventory;
		private string _description;
		private Path _path;

		public Location(string[] ids, string name, string desc, Path path) : base(ids, name, desc)
		{
			_inventory = new Inventory();
			_description = desc;
			_path = path;
		}

		public GameObject Locate(string id)
		{
			if (AreYou(id))
			{
				return this;
			}
			else {
					return _inventory.Fetch(id);
			}
		}
		public override string FullDescription
		{
			get { return Description + _path.Exits + "\nIn this room you can see" + _inventory.ItemList; }
		}

		public Inventory Inventory
		{
			get { return _inventory; }
		}

		public string Description
		{
			get
			{
				return _description;
			}
		}

		public Path Path
		{
			get
			{
				return _path;
			}
		}
	}
}

