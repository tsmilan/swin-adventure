using System;
using System.Collections.Generic;

namespace Task9
{
	public class Inventory
	{
		private List<Item> _items = new List<Item>();

		public Inventory()
		{
		}

		public bool HasItem(string id)
		{
			foreach (Item i in _items)
			{
				return i.AreYou(id);
			}
			return false;
		}

		public void Put(Item itm)
		{
			_items.Add(itm);
		}

		public void Take(Item id)
		{
			_items.Remove(id);
		}

		public Item Fetch(string id)
		{
			foreach (Item itm in _items)
			{
				if (itm.AreYou(id))
				{
					return itm;
				}
			}
			return null;
		}

		public string ItemList
		{
			get {
				string result = "";
				foreach (Item i in _items)
				{
					result += "\n\t" + i.ShortDescription;
				}
				return result;
			}
		}
	}
}

