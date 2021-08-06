namespace dbProvider
{
	public class Consumer: IPkName
	{
		public Consumer(int _pk, string _nm)
		{
			Pk = _pk;
			Name = _nm;
		}

		public int Pk{ get; }
		public string Name{ get; }
	}
}