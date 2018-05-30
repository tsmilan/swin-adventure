using System;
namespace Task9
{
	public class MoveCommand : Command
	{
		public MoveCommand(string[] ids) : base(ids)
		{
		}

		public override string Execute(Player p, string[] text)
		{
			string result = "";
			if (AreYou(text[0]))
			{
				if (text.Length == 2)
				{
					if (p.Location.Path.AreYou(text[1]))
					{

						if (p.Location.Path.Destination == null)
						{
							result += "You have made it out of the maze.";
						}
						else if (p.Location.Path.LastId().ToLower() == text[1].ToLower() && p.Location.Path.Count() > 2)
						{
							p.Location.Path.Move(p, text[1]);
							result += "You head " + text[1] + "\n" + p.Location.Path.Traveltext;
							result += "\nYou have arrived in " + p.Location.Name;
						}
						else
						{
							result += "You head " + text[1] + "\n" + p.Location.Path.Traveltext;
							p.Location.Path.Move(p, text[1]);
							result += "\nYou have arrived in " + p.Location.Name;
						}
					}
					else
					{
						return "Invalid direction " + text[1];
					}
				}
				else
				{
					return "Invalid path identifier.";
				}
			}
			else
			{
				return "Invalid path identifier.";
			}
			return result;
		}
	}
}

