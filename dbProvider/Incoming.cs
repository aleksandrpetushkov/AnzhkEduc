namespace dbProvider
{
	public class Incoming
	{
		public int pk { get; }
		public int p_nm { get; }
		public int g_nm { get; }
		public int price { get; }
		public int count { get; }

		public Incoming(int _pk, int _p_nm,int _g_nm, int _price, int _count)
		{
			pk = _pk;
			p_nm = _p_nm;
			g_nm = _g_nm;
			price = _price;
			count = _count;
		}
	}
}