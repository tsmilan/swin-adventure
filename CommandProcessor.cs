using System;
using System.Collections.Generic;
namespace Task9
{
	public class CommandProcessor : Command
	{
		private List<Command> _command = new List<Command>();

		public CommandProcessor(string[] ids, Command[] command) : base(ids)
		{
			foreach (Command c in command)
			{
				_command.Add(c);
			}
		}


		public override string Execute(Player p, string[] text)
		{
			foreach (Command c in _command)
			{
				if (c.AreYou(text[0]))
				{
					return c.Execute(p, text);
				}
			}
			return "Invalid command.";
		}
	}
}

