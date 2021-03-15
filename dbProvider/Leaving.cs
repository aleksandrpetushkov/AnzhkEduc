namespace dbProvider
{
	public class Leaving
	{
		public int pk { get; }
		public int goods_pk { get; }
		public int consumer_pk { get; }
		public int price { get; }
		public int count { get; }

		public Leaving(int _pk, int _goods_pk, int _consumer_pk, int _price, int _count)
		{
			pk = _pk;
			goods_pk = _goods_pk;
			consumer_pk = _consumer_pk;
			price = _price;
			count = _count;
		}
	}
}