namespace dbProvider
{
	public class Provider: IPkName
	{
		public Provider(int _pk, string _nm)
		{
			Pk = _pk;
			Name = _nm;
		}

		public int Pk { get;}
		public string Name { get; }

	}
}