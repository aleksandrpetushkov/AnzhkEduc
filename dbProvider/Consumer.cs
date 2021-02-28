namespace dbProvider
{
	public class Consumer
	{
		public Consumer(int _pk, string _nm)
		{
			pk = _pk;
			nm = _nm;
		}

		public int pk { get; }
		public string nm { get; }
	}
}