using System;
namespace Task9
{
	public class LookCommand : Command
	{
		public LookCommand(string[] ids) : base (ids)
		{
		}

		public override string Execute(Player p, string[] text)
		{
			if (AreYou("look"))
			{
				IHaveInventory container;

				if (text.Length == 1 && text[0] == "look")
				{
					return "You are in the " + p.Location.FirstId() + "\n" + p.Location.FullDescription;
				}

				if (text[0].ToLower() != "look" || text[1].ToLower() != "at")
				{
					return "Error in look input";
				}
			
				if (text.Length == 3)
				{
					container = p as IHaveInventory;
				}
				else if (text.Length == 5)
				{
					if (text[3].ToLower() != "in")
					{
						return "What do you want to look in?";
					}
					container = FetchContainer(p, text[4]);
				}
				else
				{
					return "I don't know how to look like that";
				}


				return LookAtIn(text[2], container);
			}
			else {
				return "Error in command";
			}
		}

		private IHaveInventory FetchContainer(Player p, string containerId)
		{
			if (containerId != null)
			{
				return p.Locate(containerId) as IHaveInventory;
			}
			else {
				return null;
			}
		}

		private string LookAtIn(string thingId, IHaveInventory container)
		{
			if (container != null)
			{
				GameObject itm = container.Locate(thingId);

				if (itm != null)
				{
					return itm.FullDescription;
				}
				else {
					return "I can't find the " + thingId;
				}
			}
			else {
				return "I can't find the bag";
			}
		}
	}
}

