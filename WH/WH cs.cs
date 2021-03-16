using System.Collections.Generic;
using dbProvider;

namespace WH
{
	/// <summary>
	///     Level Logics
	/// </summary>
	public class WH
	{
		protected IDALWH PgP;
		public WH(string ip, string unm, string pswd, string dbnm, string appnm, int port = 5432)
		{
			//Как происходит инициализация объектов?
			//Как происходит создание объекта?
			//new PgProvider(ip, unm, pswd, dbnm, appnm) - создание объекта
			PgP = new PgProvider(ip, unm, pswd, dbnm, appnm);
			prvds = PgP.GetPrvds();
			cs = PgP.GetConsumers();
		}
		public WH(IDALWH dl)
		{
			PgP = dl;
			prvds = PgP.GetPrvds();
			cs = PgP.GetConsumers();
			gs = PgP.GetGoods();
			incom = PgP.GetIncom();
			stock = PgP.GetStocks();
			//PgP.InsertIncom(1, 4, 100, 33);
		}

		//TODO: Dictionаry - это
		public Dictionary<int, Provider> prvds { get; protected set; }

		protected internal Dictionary<int, Consumer> cs { get; set; }

		public Dictionary<int, Goods> gs { get; set; }

		public Dictionary<int, Incoming> incom { get; set; }

		public Dictionary<int, Stocks> stock { get; set; }

		public Dictionary<int, Leaving> leaving { get; set; }

		public void AddIncom(int goods_pk, int provider_pk, int price, int count)
		{
			//b logic
			PgP.InsertIncom(goods_pk, provider_pk, price, count);
			incom = PgP.GetIncom();
		}
		public void InsertPrvd(string st)
		{
			PgP.InsertPrvd(st);
			prvds = PgP.GetPrvds();
		}
		public void InsertCs(string st)
		{
			PgP.InsertCs(st);
			cs = PgP.GetConsumers();
		}
		public void InsertGoods(string st)
		{
			PgP.InsertGoods(st);
			gs = PgP.GetGoods();
		}
		public bool KH(int gds_key, out int inc, out int stk, out int lev, out int sver)
		{
			inc = 0;
			stk = 0;
			lev = 0;
			sver = 0;
			return true;
		}
	}
}