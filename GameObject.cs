using System;
namespace Task9
{
	public abstract class GameObject : IdentifiableObject
	{
		private string _description, _name;

		protected GameObject(string[] ids, string name, string desc) : base (ids)
		{
			_description = desc;
			_name = name;
		}

		public string Name
		{
			get
			{
				return _name;
			}
		}

		public string ShortDescription
		{
			get
			{
				return Name + " (" + FirstId() + ")";
			}
		}

		public virtual string FullDescription
		{
			get
			{
				return _description;
			}
		}

	}
}

