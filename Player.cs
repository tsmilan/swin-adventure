using System;
using System.Collections.Generic;
namespace Task9
{
	public class Player : GameObject, IHaveInventory
	{
		private Inventory _inventory;
		private Location _location;
		private List<Location> _locationlist = new List<Location>();

		public Player(string name, string desc, Location location, List<Location> locationlist) : base( new string[] { name, desc } , name, desc)
		{
			_inventory = new Inventory();
			_location = location;
			Locationlist = locationlist;
		}

		public GameObject Locate(string id)
		{
			if (AreYou(id))
			{
				return this;
			}
			else {
				if (Inventory.Fetch(id) != null)
				{
					return Inventory.Fetch(id);
				}
				else {
					return Location.Locate(id);
				}
			}
		}

		public override string FullDescription
		{
			get
			{
				return "You are carrying:" + Inventory.ItemList;
			}
		}

		public Inventory Inventory
		{
			get 
			{
				return _inventory;
			}
		}

		public Location Location
		{
			get
			{
				return _location;
			}
			set
			{
				_location = value;
			}
		}

		public List<Location> Locationlist
		{
			get
			{
				return _locationlist;
			}

			set
			{
				_locationlist = value;
			}
		}
	}
}

