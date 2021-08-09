namespace dbProvider
{
	public class Incoming
	{
		public int pk{ get; }
		public int goods_pk{ get; }
		public int provider_pk{ get; }
		// public string p_nm { get; }
		// public string g_nm { get; }
		public int Price{ get; }
		public int Count{ get; }

		public Incoming(int _pk, int _goods_pk, int _provider_pk, int _price, int _count)
		{
			pk = _pk;
			goods_pk = _goods_pk;
			provider_pk = _provider_pk;
			Price = _price;
			Count = _count;
		}

		/*public Incoming(int __pk, string __p_nm, string __g_nm, int __price, int __count)
		{
			pk = __pk;
			p_nm = __p_nm;
			g_nm = __g_nm;
			price = __price;
			count = __count;
		}*/
	}
}