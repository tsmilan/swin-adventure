using System;
namespace Task9
{
	public interface IHaveInventory
	{
		GameObject Locate(string id);
		string Name
		{
			get;
		}
	}
}

