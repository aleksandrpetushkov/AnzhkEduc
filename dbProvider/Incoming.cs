namespace dbProvider
{
	public class Incoming
	{
		public int pk { get; }
		public int goods_pk { get; }
		public int provider_pk { get; }
		public int price { get; }
		public int count { get; }

		public Incoming(int _pk, int _goods_pk, int _provider_pk, int _price, int _count)
		{
			pk = _pk;
			goods_pk = _goods_pk;
			provider_pk = _provider_pk;
			price = _price;
			count = _count;
		}
	}
}