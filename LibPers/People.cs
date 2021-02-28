using System;

namespace LibPers
{
	public abstract class People
	{
		public string Name { get; set; }
		public string Last_name { get; set; }
		public DateTime Birthday { get; set; }
		public abstract void Print();
	}
}