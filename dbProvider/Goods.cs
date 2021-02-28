namespace dbProvider
{
	public class Goods
	{
		public Goods(int _pk, string _nm)
		{
			pk = _pk;
			nm = _nm;
		}

		public int pk { get; }
		public string nm { get; }
	}
}