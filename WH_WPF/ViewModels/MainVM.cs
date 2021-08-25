using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using WH_WPF.Cmd;
using WhLib;
using dbProvider;

namespace ViewModels
{
	internal class MainVM: AVM
	{
		#region Заголовок окна

		public ICommand AddPrvd { get; }
		protected WH wh;

		public ICommand AddCs { get; }

		public ICommand AddGs { get; }

		public ICommand AddInc { get; }

		public ICommand AddLeav { get; }

		public MainVM() //Constructor 
		{
			wh = new WH("h.petushkov.com", "ang", "ang", "warehouse", "tst_wh");

			ViewRecordsPrvd = new ListCollectionView(wh.prvds.Select(vl => vl.Value).ToList());
			NameColumnPrvd = "Providers";
			AddPrvd = new CmdCommon(OnAddPrvd, CanExAddPrvd);

			ViewRecordsCs = new ListCollectionView(wh.cs.Select(vl => vl.Value).ToList());
			NameColumnCs = "Consumers";
			AddCs = new CmdCommon(OnAddCs, CanExAddCs);


			ViewRecordsGs = new ListCollectionView(wh.gs.Select(k_v => k_v.Value).ToList());
			AddGs = new CmdCommon(OnAddGs, CanExAddGs);

			AddInc = new CmdCommon(OnAddInc, CanExAddInc);

			AddLeav = new CmdCommon(OnAddLeav, CanExAddLeav);


			//1

			var prvlistE = wh.prvds.Select(vl => vl.Value);
			var incLisctE = wh.incom.Select(vl => vl.Value);
			var gsE = wh.gs.Select(vl => vl.Value);
			//2

			/*IEnumerable<object> result_inc = from prvd in wh.prvds.Select(vl => vl.Value)//.Where(o=>o.Name[0]=='Э')
											 join inc in wh.incom.Select(vl => vl.Value) on prvd.Pk equals inc.provider_pk
											 join g in wh.gs.Select(vl => vl.Value) on inc.goods_pk equals g.Pk
											 select new { Pk = inc.pk, NameP = prvd.Name, NameG = g.Name, Count = inc.Count, Price = inc.Price };
*/
			ViewRecordsInc = new ListCollectionView(GetIncByName().ToList());

			/*var result_lev = from cs in wh.cs.Select(vl => vl.Value)
											 join lev in wh.leaving.Select(vl => vl.Value) on cs.Pk equals lev.consumer_pk
											 join g in wh.gs.Select(vl => vl.Value) on lev.goods_pk equals g.Pk
											 select new { Pk = lev.pk, NameC = cs.Name, NameG = g.Name, Count = lev.count, Price = lev.price };
*/
			ViewRecordsLeav = new ListCollectionView(GetLeavByName().ToList());

			/*var result_stk = from gs in wh.gs.Select(vl => vl.Value)
											 join stk in wh.stock.Select(vl => vl.Value) on gs.Pk equals stk.pk_gs
											 select new { NameG = gs.Name, Count = stk.count };
*/
			ViewRecordsStk = new ListCollectionView(GetStkByName().ToList());

			List<Sverka> svr = new List<Sverka>();

			foreach(var g in wh.gs)
			{
				wh.KH(g.Key, out int inc, out int stk, out int lev, out int sver);
				Sverka s = new Sverka(g.Key, inc, stk, lev, sver);
				svr.Add(s);

			}



			var result = from g in wh.gs.Select(vl => vl.Value)
									 join sv in svr on g.Pk equals sv.gs_key
									 select new { NameG = g.Name, Inc = sv.inc, Stk = sv.stk, Lev = sv.lev, Sver = sv.sver };

			ViewRecordsSver = new ListCollectionView(result.ToList());

		}

		private IEnumerable<object> GetIncByName ()
		{ 
			return from prvd in wh.prvds.Select(vl => vl.Value)//.Where(o=>o.Name[0]=='Э')
						 join inc in wh.incom.Select(vl => vl.Value) on prvd.Pk equals inc.provider_pk
						 join g in wh.gs.Select(vl => vl.Value) on inc.goods_pk equals g.Pk
						 select new { Pk = inc.pk, NameP = prvd.Name, NameG = g.Name, Count = inc.Count, Price = inc.Price };
		}

		private IEnumerable<object> GetLeavByName()
		{ 
			return from cs in wh.cs.Select(vl => vl.Value)
						 join lev in wh.leaving.Select(vl => vl.Value) on cs.Pk equals lev.consumer_pk
						 join g in wh.gs.Select(vl => vl.Value) on lev.goods_pk equals g.Pk
						 select new { Pk = lev.pk, NameC = cs.Name, NameG = g.Name, Count = lev.count, Price = lev.price };
		}

		private IEnumerable<object> GetStkByName()
		{ 
			return from gs in wh.gs.Select(vl => vl.Value)
						 join stk in wh.stock.Select(vl => vl.Value) on gs.Pk equals stk.pk_gs
						 select new { NameG = gs.Name, Count = stk.count };
		}

		public Provider f(KeyValuePair<int, Provider> vl)
		{
			if(vl.Value is null)
				return null;
			return null;

		}

		protected object _selectPrvd;

		protected object _selectGs;

		protected object _selectCs;

		public object SelectPrvd
		{
			get => _selectPrvd;
			set => Set(ref _selectPrvd, value);
		}

		public object SelectGs
		{
			get => _selectGs;
			set => Set(ref _selectGs, value);
		}

		public object SelectCs
		{
			get => _selectCs;
			set => Set(ref _selectCs, value);
		}

		private string _inpustr_name;
		private int _inpustr_count;
		private int _inpustr_price;


		//После ввода текста срабатывает проперти_ченже и введеный текст пытается установиться в свойство "InptStrName (вызывается его сеттор - set)"
		public string InptStrName
		{
			get => _inpustr_name;
			set => Set(ref _inpustr_name, value);
		}

		public int InptStrCount
		{
			get => _inpustr_count;
			set => Set(ref _inpustr_count, value);
		}

		public int InptStrPrice
		{
			get => _inpustr_price;
			set => Set(ref _inpustr_price, value);
		}

		public bool CanExAddPrvd(object p)
		{
			return !string.IsNullOrEmpty(_inpustr_name);
		}

		public bool CanExAddCs(object c)
		{
			return !string.IsNullOrEmpty(_inpustr_name);
		}

		public bool CanExAddGs(object g)
		{
			return !string.IsNullOrEmpty(_inpustr_name);
		}

		public bool CanExAddInc(object i)
		{ 
			if(_inpustr_count != 0 && _inpustr_price != 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public bool CanExAddLeav(object i)
		{ 
			if(_inpustr_count != 0 && _inpustr_price != 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		public void OnAddPrvd(object p)
		{
			wh.InsertPrvd(_inpustr_name);
			ViewRecordsPrvd = new ListCollectionView(wh.prvds.Select(vl => vl.Value).ToList());
		}

		public void OnAddCs(object c)
		{
			wh.InsertCs(_inpustr_name);
			ViewRecordsCs = new ListCollectionView(wh.cs.Select(vl => vl.Value).ToList());
		}


		public void OnAddGs(object g)
		{
			wh.InsertGoods(_inpustr_name);
			ViewRecordsGs = new ListCollectionView(wh.gs.Select(vl => vl.Value).ToList());
		}


		public void OnAddInc(object zu)
		{
			wh.AddIncom(SelectGs, SelectPrvd, _inpustr_count, _inpustr_price);
			ViewRecordsInc = new ListCollectionView(GetIncByName().ToList());
			ViewRecordsStk = new ListCollectionView(GetStkByName().ToList());
		}

		public void OnAddLeav(object zu)
		{
			wh.AddLeav(SelectGs, SelectCs, _inpustr_count, _inpustr_price);
			ViewRecordsLeav = new ListCollectionView(GetLeavByName().ToList());
			ViewRecordsStk = new ListCollectionView(GetStkByName().ToList());
		}

		#region Title

		private string _Title = "Warehouse 2.0";

		/// <summary>Заголовок окна</summary>
		public string Title
		{
			get => _Title;
			//set
			//{
			//    //if (Equals(_Title, value)) return;
			//    //_Title = value;
			//    //OnPropertyChanged();

			//    Set(ref _Title, value);
			//}
			set => Set(ref _Title, value);
		}

		#endregion Title

		private ListCollectionView _view_recordPrvd = default;
		private string _name = "Name";
		private ListCollectionView _view_recordCs;
		private ListCollectionView _view_recordGs;

		public ListCollectionView ViewRecordsPrvd
		{
			get => _view_recordPrvd;
			set => Set(ref _view_recordPrvd, value);
		}

		public ListCollectionView ViewRecordsCs
		{
			get => _view_recordCs;
			set => Set(ref _view_recordCs, value);
		}

		public ListCollectionView ViewRecordsGs
		{
			get => _view_recordGs;
			set => Set(ref _view_recordGs, value);
		}
		#region Income
		private ListCollectionView _view_recordInc;

		private ListCollectionView _view_recordLev;

		private ListCollectionView _view_recordsStk;

		private ListCollectionView _view_recordsSver;

		public ListCollectionView ViewRecordsInc
		{
			get => _view_recordInc;
			set => Set(ref _view_recordInc, value);
		}

		public ListCollectionView ViewRecordsLeav
		{
			get => _view_recordLev;
			set => Set(ref _view_recordLev, value);
		}

		public ListCollectionView ViewRecordsStk
		{
			get => _view_recordsStk;
			set => Set(ref _view_recordsStk, value);

		}

		public ListCollectionView ViewRecordsSver
		{
			get => _view_recordsSver;
			set => Set(ref _view_recordsSver, value);
		}
		#endregion

		
		public string NameColumnPrvd
		{
			get => _name;
			set => Set(ref _name, value);
		}

		public string NameColumnCs
		{
			get => _name;
			set => Set(ref _name, value);
		}

		#endregion
	}
}