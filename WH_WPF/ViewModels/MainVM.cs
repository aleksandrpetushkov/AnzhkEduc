using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using WH_WPF.Cmd;
using WhLib;

namespace ViewModels
{
	internal class MainVM: AVM
	{
		#region Заголовок окна

		public ICommand AddPrvd { get; }
		protected WH wh;

		public ICommand AddCs { get; }

		public ICommand AddGs { get; }
		public MainVM() //Constructor 
		{
			wh = new WH("h.petushkov.com", "ang", "ang", "warehouse", "tst_wh");

			ViewRecordsPrvd = new ListCollectionView(wh.prvds.Select(vl => vl.Value).ToList());
			NameColumnPrvd = "Providers";
			AddPrvd = new CmdCommon(OnAddPrvd, CanExAddPrvd);

			ViewRecordsCs = new ListCollectionView(wh.cs.Select(vl => vl.Value).ToList());
			NameColumnCs = "Consumers";
			AddCs = new CmdCommon(OnAddCs, CanExAddCs);

			ViewRecordsGs = new ListCollectionView(wh.gs.Select(vl => vl.Value).ToList());
			AddGs = new CmdCommon(OnAddGs, CanExAddGs);
		}



		private string _inpustr;

		public string InptStr
		{
			get => _inpustr;
			set => Set(ref _inpustr, value);
		}

		public bool CanExAddPrvd(object p)
		{
			return !string.IsNullOrEmpty(_inpustr);
		}

		public bool CanExAddCs(object c)
		{
			return !string.IsNullOrEmpty(_inpustr);
		}

		public bool CanExAddGs(object g)
		{
			return !string.IsNullOrEmpty(_inpustr);
		}

		public void OnAddPrvd(object p)
		{
			wh.InsertPrvd(_inpustr);
			ViewRecordsPrvd = new ListCollectionView(wh.prvds.Select(vl => vl.Value).ToList());
		}

		public void OnAddCs(object c)
		{
			wh.InsertCs(_inpustr);
			ViewRecordsCs = new ListCollectionView(wh.cs.Select(vl => vl.Value).ToList());
		}

		public void OnAddGs(object g)
		{
			wh.InsertGoods(_inpustr);
			ViewRecordsGs = new ListCollectionView(wh.gs.Select(vl => vl.Value).ToList());
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