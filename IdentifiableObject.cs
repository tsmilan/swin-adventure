using System;
using System.Collections.Generic;
using System.Linq;

namespace Task9
{
	public class IdentifiableObject
	{
		private List<string> _identifiers = new List<string>();

		public IdentifiableObject (string[] idents)
		{
			foreach (string i in idents)
			{
				AddIdentifier(i);
			}
		}

		public bool AreYou (string id)
		{
			foreach (string i in _identifiers)
			{
				if (i == id.ToLower())
				{
					return true;
				}
			}
			return false;
		}

		public string FirstId ()
		{
			return _identifiers.First();
		}

		public string LastId()
		{
			return _identifiers.Last();
		}

		public int Count()
		{
			return _identifiers.Count;
		}

		public void AddIdentifier (string id)
		{
			_identifiers.Add( id.ToLower ());
		}
	}



}

