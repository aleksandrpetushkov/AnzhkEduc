namespace dbProvider
{
	public class Provider
	{
		public Provider(int _pk, string _nm)
		{
			pk = _pk;
			nm = _nm;
		}

		public int pk { get; }
		public string nm { get; }
	}
}