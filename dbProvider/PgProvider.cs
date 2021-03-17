using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;

namespace dbProvider
{
	/// <summary>
	///     Level DB || DAL - dataBase access level
	/// </summary>
	public class PgProvider : IDALWH
	{
		protected NpgsqlConnection _npcon;

		//Конструктор это метод, название которого совпадает с названием класса и он ничего не возвращает
		//Конструктор используется для создания объектов.
		public PgProvider(string ip, string unm, string pswd, string dbnm, string apnm, int port = 5432)
		{
			NpgsqlConnectionStringBuilder sb = new NpgsqlConnectionStringBuilder
			{
				Password = pswd, Port = port, Database = dbnm, Host = ip, Pooling = false, CommandTimeout = 360
				, ApplicationName = apnm, Username = unm
			};
			NpgsqlConnectionStringBuilder sb1 = new NpgsqlConnectionStringBuilder();
			sb1.Password = pswd;
			sb1.Port = port;
			sb1.Database = dbnm;
			sb1.Host = ip;
			sb1.Pooling = false;
			sb1.CommandTimeout = 360;
			sb1.ApplicationName = apnm;
			sb1.Username = unm;
			string st = sb.ToString();
			_npcon = new NpgsqlConnection(st);
			_npcon.Open();
			if(_npcon.State != ConnectionState.Open)
				throw new Exception("ALLLBAAAD");
			//выбросить исключение
		}
		public PgProvider()
		{
		}
		public Dictionary<int, Provider> GetPrvds()
		{
			Dictionary<int, Provider> res = new Dictionary<int, Provider>();
			using(NpgsqlCommand cmd = new NpgsqlCommand(@"SELECT * FROM provider;", _npcon))
			{
				using(NpgsqlDataReader r = cmd.ExecuteReader())
				{
					while(r.Read())
					{
						int pr_pk = (int)r["pk"];
						string pr_nm = (string)r["nm"];
						Provider p = new Provider(pr_pk, pr_nm);
						res[pr_pk] = p;
					}
				}
			}
			return res;
		}
		public Dictionary<int, Consumer> GetConsumers()
		{
			Dictionary<int, Consumer> res = new Dictionary<int, Consumer>();
			using(NpgsqlCommand cmd = new NpgsqlCommand(@"SELECT * FROM consumer", _npcon))
			{
				using(NpgsqlDataReader r = cmd.ExecuteReader())
				{
					while(r.Read())
					{
						int cs_pk = (int)r["pk"];
						string cs_nm = (string)r["nm"];
						Consumer cns = new Consumer(cs_pk, cs_nm);
						res[cs_pk] = cns;
					}
				}
			}
			return res;
		}
		public Dictionary<int, Goods> GetGoods()
		{
			Dictionary<int, Goods> res = new Dictionary<int, Goods>();
			using(NpgsqlCommand cmd = new NpgsqlCommand(@"SELECT * FROM goods", _npcon))
			{
				using(NpgsqlDataReader r = cmd.ExecuteReader())
				{
					while(r.Read())
					{
						int gs_pk = (int)r["pk"];
						string gs_nm = (string)r["nm"];
						Goods gds = new Goods(gs_pk, gs_nm);
						res[gs_pk] = gds;
					}
				}
			}
			return res;
		}
		public Dictionary<int, Stocks> GetStocks()
		{
			Dictionary<int, Stocks> res = new Dictionary<int, Stocks>();
			using(NpgsqlCommand cmd = new NpgsqlCommand($@"SELECT gs_pk, count FROM stock", _npcon))
			{
				using(NpgsqlDataReader r = cmd.ExecuteReader())
				{
					while(r.Read())
					{
						int gsPk = (int)r["gs_pk"];
						int count = (int)r["count"];
						Stocks stk = new Stocks(gsPk, count);
						res[gsPk] = stk;
					}
				}
			}
			return res;
		}
		public Dictionary<int, Incoming> GetIncom()
		{
			Dictionary<int, Incoming> res = new Dictionary<int, Incoming>();
			using(NpgsqlCommand cmd = new NpgsqlCommand(@"SELECT * FROM incoming", _npcon))
			{
				using(NpgsqlDataReader r = cmd.ExecuteReader())
				{
					while(r.Read())
					{
						int inc_pk = (int)r["pk"];
						int goods_pk = (int)r["goods_pk"];
						int provider_pk = (int)r["provider_pk"];
						int price = (int)r["price"];
						int count = (int)r["count"];
						Incoming inc = new Incoming(inc_pk, goods_pk, provider_pk, price, count);
						res[inc_pk] = inc;
					}
				}
			}
			return res;
		}
		/*
		public Dictionary<int, Incoming> GetIncomNm()
		{
			Dictionary<int, Incoming> res = new Dictionary<int, Incoming>();
			using(NpgsqlCommand cmd = new NpgsqlCommand($@"SELECT p.nm pnm, g.nm gnm, count, price, inc.pk pk
			FROM incoming inc
			JOIN provider p ON inc.provider_pk = p.pk
			JOIN goods g ON inc.goods_pk = g.pk", _npcon))
			{
				using(NpgsqlDataReader r = cmd.ExecuteReader())
				{
					while(r.Read())
					{
						int inc_pk = (int)r["pk"];
						string p_nm = (string)r["pnm"];
						string g_nm = (string)r["gnm"];
						int price = (int)r["price"];
						int count = (int)r["count"];
						Incoming inc = new Incoming(inc_pk, p_nm, g_nm, price, count);
						res[inc_pk] = inc;
					}
				}
			}
			return res;
		}
		*/
		public void InsertPrvd(string st)
		{
//			string str = command DB
//			string strq=str;
//			st.Replace("Ситилинк",st);
//			Console.WriteLine("Мы пытались загрузить строку {st_reader} и чота мы эксепшн словили вот его мессадж: {e.Message}");
			int i;
			using(NpgsqlCommand cmd = new NpgsqlCommand($@"INSERT INTO provider (nm) VALUES ('{st}')", _npcon))
			{
				i = cmd.ExecuteNonQuery();
			}
		}
		public void InsertCs(string st)
		{
			int i;
			using(NpgsqlCommand cmd = new NpgsqlCommand($@"INSERT INTO consumer (nm) VALUES ('{st}')", _npcon))
			{
				i = cmd.ExecuteNonQuery();
			}
		}
		public void InsertGoods(string st)
		{
			int i;
			using(NpgsqlCommand cmd = new NpgsqlCommand($@"INSERT INTO goods (nm) VALUES ('{st}')", _npcon))
			{
				i = cmd.ExecuteNonQuery();
			}
		}
		public List<string> execCmd(string query)
		{
			List<string> st = new List<string>();
			using(NpgsqlCommand cmd = new NpgsqlCommand(query, _npcon))
			{
				using(NpgsqlDataReader r = cmd.ExecuteReader())
				{
					while(r.Read())
						st.Add((string)r["nm"]);
				}
			}
			return st;
		}
		public void InsertIncom(int goods_pk, int provider_pk, int price, int new_incom_count)
		{
			NpgsqlTransaction tr = _npcon.BeginTransaction();
			try
			{
				bool GsExist = false;
				using(NpgsqlCommand cmd_chek = new($@"SELECT gs_pk, count FROM stock", _npcon))
				{
					NpgsqlDataReader r = cmd_chek.ExecuteReader();
					if(r.Read())
					{
						GsExist = true;
					}
					r.Dispose();
				}
				using(NpgsqlCommand cmd = new($@"INSERT INTO incoming (goods_pk, provider_pk, price, count) 
VALUES ('{goods_pk}', '{provider_pk}', '{price}', '{new_incom_count}');", _npcon))
				{
					if(cmd.ExecuteNonQuery() != 1)
					{
						tr.Rollback();
						return;
					}
				}
				if(GsExist)																												
					using(NpgsqlCommand cmd_upd = new($@"update stock set count=count+{new_incom_count} 
where gs_pk={goods_pk};", _npcon, tr))
					{
						if(cmd_upd.ExecuteNonQuery() != 1)
						{
							tr.Rollback();
							return;
						}
					}
				else
					using(NpgsqlCommand cmd_ins = new NpgsqlCommand(@$"insert into stock (gs_pk, count) 
values({goods_pk}),{new_incom_count});", _npcon, tr))
					{
						if(cmd_ins.ExecuteNonQuery() != 1)
						{
							tr.Rollback();
							return;
						}
					}
				tr.Commit();
			}
			catch(Exception e)
			{
				tr.Rollback();
			}
			/*
			
			sing(NpgsqlCommand cmd = new NpgsqlCommand($@"INSERT INTO incoming (goods_pk, provider_pk, price, count)
			VALUES ('{goods_pk}', '{provider_pk}', '{price}', '{count}')", _npcon))
			{
				i = cmd.ExecuteNonQuery();
			}*/
		}
	}
}