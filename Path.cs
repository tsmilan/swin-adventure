using System;

namespace Task9
{
	public class Path : IdentifiableObject
	{
		private Location _destination;
		private string _traveltext;
		private string[] _identifier;
		private Direction[] _exits;

		public Path(string[] ids, Location destination, string traveltext, Direction[] exits) : base(ids)
		{
			_destination = destination;
			_identifier = ids;
			_traveltext = traveltext; 
			_exits = exits;
		}

		public string Traveltext
		{
			get
			{
				return _traveltext;
			}
		}

		public string Exits
		{
			get
			{
				string result = "";
				result += "\nThere are exits to the ";
				if (_exits.Length > 1)
				{
					result +=  string.Join(" and ", _exits);
				}
				else {
					result += _exits[0].ToString();

				}
				return result;
			}

		}

		public string[] Identifier
		{
			get
			{
				return _identifier;
			}
		}

		public Location Destination
		{
			get
			{
				return _destination;
			}
		}

		public void Move(Player p, string exit)
		{
			if (p.Location.Path._exits[0].ToString().ToLower() == exit.ToLower())
			{
				p.Location = Destination;
			}
			else
			{
				
				foreach (Location l in p.Locationlist)
				{
					if (p.Location.Path.Identifier[1].ToLower() == l.Name.ToLower())
					{
						p.Location = l;
					}
				}
			}


		}

	}
}

