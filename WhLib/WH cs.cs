using System.Collections.Generic;
using dbProvider;

namespace WhLib
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
			gs = PgP.GetGoods();
			incom = PgP.GetIncom();
			stock = PgP.GetStocks();
			leaving = PgP.GetLeav();
		}

		public WH(IDALWH dl)
		{
			PgP = dl;
			prvds = PgP.GetPrvds();
			cs = PgP.GetConsumers();
			gs = PgP.GetGoods();
			incom = PgP.GetIncom();
			stock = PgP.GetStocks();
			leaving = PgP.GetLeav();
			//PgP.InsertIncom(1, 4, 100, 33);
		}

		//TODO: Dictionаry - это
		public Dictionary<int, Provider> prvds { get; protected set; }
		public Dictionary<int, Consumer> cs { get; set; }
		public Dictionary<int, Goods> gs { get; set; }
		public Dictionary<int, Incoming> incom { get; set; }
		public Dictionary<int, Stocks> stock { get; set; }
		public Dictionary<int, Leaving> leaving { get; set; }

		//List<GoodsView>

		public void AddIncom(int goods_pk, int provider_pk, int price, int count)
		{
			//b logic
			PgP.InsertIncom(goods_pk, provider_pk, price, count);
			incom = PgP.GetIncom();
			stock = PgP.GetStocks();
		}

		public void AddIncom(object goods, object provider, int price, int count)
		{
				AddIncom(((Goods)goods).Pk, ((Provider)provider).Pk, price, count);

			//b logic
			//PgP.InsertIncom(goods_pk, provider_pk, price, count);
			//incom = PgP.GetIncom();
			//stock = PgP.GetStocks();
		}

		public void InsertLeav(int goods_pk, int consumer_pk, int price, int count)
		{
			PgP.InsertLeav(goods_pk, consumer_pk, price, count);
			leaving = PgP.GetLeav();
			stock = PgP.GetStocks();
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
			if(incom != null)
				foreach(KeyValuePair<int, Incoming> inco in incom)
					if(gds_key == inco.Value.goods_pk)
						inc += inco.Value.
							count; // тоже самое что и: inc = inc + inco.Value.count таким образом к инк прибавим  inco.Value.count
			if(stock != null)
			{
				foreach(KeyValuePair<int, Stocks> stok in stock)
					if(gds_key == stok.Value.pk_gs)
						stk = stok.Value.count;
			}
			else
			{
			}
			if(leaving != null)
			{
				foreach(KeyValuePair<int, Leaving> leav in leaving)
					if(gds_key == leav.Value.goods_pk)
						lev += leav.Value.count;
			}
			else
			{
			}
			sver = stk + lev - inc;
			return true;
		}
	}
}