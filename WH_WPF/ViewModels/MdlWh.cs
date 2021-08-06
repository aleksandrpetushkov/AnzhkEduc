using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using dbProvider;
using WhLib;

namespace WH_WPF.ViewModels
{
	public class MdlWh: INotifyPropertyChanged
	{
		protected IDALWH PgP;
		public MdlWh() : this("h.petushkov.com", "ang", "ang", "warehouse", "tst_wh")
		{
			WH whm = new WH("h.petushkov.com", "ang", "ang", "warehouse", "tst_wh");
			//this("h.petushkov.com", "ang", "ang", "warehouse", "tst_wh");

		}
		public MdlWh(string ip, string unm, string pswd, string dbnm, string appnm, int port = 5432)
		{
			//Как происходит инициализация объектов?
			//Как происходит создание объекта?
			//new PgProvider(ip, unm, pswd, dbnm, appnm) - создание объекта
			PgP = new PgProvider(ip, unm, pswd, dbnm, appnm);
			prvds = PgP.GetPrvds();
			cs = PgP.GetConsumers();
			lstPrvd = new ListCollectionView(prvds.Select(v => v.Value).ToList());
		}
		public MdlWh(IDALWH dl)
		{
			PgP = dl;
			prvds = PgP.GetPrvds();
			cs = PgP.GetConsumers();
			gs = PgP.GetGoods();
			incom = PgP.GetIncom();
			stock = PgP.GetStocks();
			//PgP.InsertIncom(1, 4, 100, 33);
		}
		protected ListCollectionView _view_record;
		public ListCollectionView lstPrvd
		{
			get
			{
				return _view_record;
			}
			set
			{
				if(_view_record != value)
				{
					_view_record = value;
					PropertyChanged?.Invoke(this, EA_ViewRecords);
				}
			}
		}
		public MainWindow Dispatcher { get; internal set; }

		private static readonly PropertyChangedEventArgs EA_ViewRecords = new(nameof(lstPrvd));
		public event PropertyChangedEventHandler PropertyChanged;
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


			foreach(KeyValuePair<int, Incoming> inco in incom)
			{
				if(gds_key == inco.Value.goods_pk)
				{
					inc += inco.Value.count; // тоже самое что и: inc = inc+ inco.Value.count таким образом к инк прибавим  inco.Value.count
				}
			}
			return true;
		}
	}
}
