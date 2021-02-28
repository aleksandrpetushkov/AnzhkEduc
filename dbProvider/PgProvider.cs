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
			var sb = new NpgsqlConnectionStringBuilder
			{
				Password = pswd
				, Port = port
				, Database = dbnm
				, Host = ip
				, Pooling = false
				, CommandTimeout = 360
				, ApplicationName = apnm
				, Username = unm
			};
			var sb1 = new NpgsqlConnectionStringBuilder();
			sb1.Password = pswd;
			sb1.Port = port;
			sb1.Database = dbnm;
			sb1.Host = ip;
			sb1.Pooling = false;
			sb1.CommandTimeout = 360;
			sb1.ApplicationName = apnm;
			sb1.Username = unm;
			var st = sb.ToString();
			_npcon = new NpgsqlConnection(st);
			_npcon.Open();
			if(_npcon.State != ConnectionState.Open) throw new Exception("ALLLBAAAD");
			//выбросить исключение
		}

		public PgProvider()
		{
		}

		public Dictionary<int, Provider> GetPrvds()
		{
			var res = new Dictionary<int, Provider>();
			using(var cmd = new NpgsqlCommand(@"SELECT * FROM provider;", _npcon))
			{
				using(var r = cmd.ExecuteReader())
				{
					while(r.Read())
					{
						var pr_pk = (int)r["pk"];
						var pr_nm = (string)r["nm"];
						var p = new Provider(pr_pk, pr_nm);
						res[pr_pk] = p;
					}
				}
			}
			return res;
		}

		public Dictionary<int, Consumer> GetConsumers()
		{
			var res = new Dictionary<int, Consumer>();
			using(var cmd = new NpgsqlCommand(@"SELECT * FROM consumer", _npcon))
			{
				using(var r = cmd.ExecuteReader())
				{
					while(r.Read())
					{
						var cs_pk = (int)r["pk"];
						var cs_nm = (string)r["nm"];
						var cns = new Consumer(cs_pk, cs_nm);
						res[cs_pk] = cns;
					}
				}
			}
			return res;
		}

		public Dictionary<int, Goods> GetGoods()
		{
			var res = new Dictionary<int, Goods>();
			using(var cmd = new NpgsqlCommand(@"SELECT * FROM goods", _npcon))
			{
				using(var r = cmd.ExecuteReader())
				{
					while(r.Read())
					{
						var gs_pk = (int)r["pk"];
						var gs_nm = (string)r["nm"];
						var gds = new Goods(gs_pk, gs_nm);
						res[gs_pk] = gds;
					}
				}
			}
			return res;
		}

		public Dictionary<int, Incoming> GetIncom()
		{
			var res = new Dictionary<int, Incoming>();
			using(var cmd = new NpgsqlCommand(@"SELECT * FROM incoming", _npcon))
			{
				using(var r = cmd.ExecuteReader())
				{
					while(r.Read())
					{
						var inc_pk = (int)r["pk"];
						var goods_pk = (int)r["goods_pk"];
						var provider_pk = (int)r["provider_pk"];
						var price = (int)r["price"];
						var count = (int)r["count"];
						var inc = new Incoming(inc_pk, goods_pk, provider_pk, price, count);
						res[inc_pk] = inc;
					}
				}
			}
			return res;
		}

		public void InsertPrvd(string st)
		{
//			string str = command DB
//			string strq=str;
//			st.Replace("Ситилинк",st);
//			Console.WriteLine("Мы пытались загрузить строку {st_reader} и чота мы эксепшн словили вот его мессадж: {e.Message}");
			int i;
			using(var cmd = new NpgsqlCommand($@"INSERT INTO provider (nm) VALUES ('{st}')", _npcon))
			{
				i = cmd.ExecuteNonQuery();
			}
		}

		public void InsertCs(string st)
		{
			int i;
			using(var cmd = new NpgsqlCommand($@"INSERT INTO consumer (nm) VALUES ('{st}')", _npcon))
			{
				i = cmd.ExecuteNonQuery();
			}
		}

		public void InsertGoods(string st)
		{
			int i;
			using(var cmd = new NpgsqlCommand($@"INSERT INTO goods (nm) VALUES ('{st}')", _npcon))
			{
				i = cmd.ExecuteNonQuery();
			}
		}

		public List<string> execCmd(string query)
		{
			var st = new List<string>();
			using(var cmd = new NpgsqlCommand(query, _npcon))
			{
				using(var r = cmd.ExecuteReader())
				{
					while(r.Read()) st.Add((string)r["nm"]);
				}
			}
			return st;
		}

		public void InsertIncom(int goods_pk, int provider_pk, int price, int count)
		{
			int i;
			using(var cmd = new NpgsqlCommand($@"INSERT INTO incoming (goods_pk, provider_pk, price, count)
			VALUES ('{goods_pk}', '{provider_pk}', '{price}', '{count}')", _npcon))
			{
				i = cmd.ExecuteNonQuery();
			}
		}
	}
}