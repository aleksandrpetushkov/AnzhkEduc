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

		public ICommand AddPrvd{ get; }
		protected WH wh;

		public MainVM()
		{
			wh = new("h.petushkov.com", "ang", "ang", "warehouse", "tst_wh");
			ViewRecordsPrvd = new(wh.prvds.Select(vl => vl.Value).ToList());
			NameColumn = "Providers";
			AddPrvd = new CmdCommon(OnAddPrvd, CanExAddPrvd);
		}

		string _inpustr;

		public string InptStr
		{
			get => _inpustr;
			set
			{
				Set(ref _inpustr, value);
			}
		}

		public bool CanExAddPrvd(object p)
		{
			return !string.IsNullOrEmpty(_inpustr);
		}

		public void OnAddPrvd(object p)
		{
			wh.InsertPrvd(_inpustr);
			ViewRecordsPrvd = new(wh.prvds.Select(vl => vl.Value).ToList());
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

		public ListCollectionView ViewRecordsPrvd
		{
			get => _view_record;
			set => Set(ref _view_record, value);
		}

		private ListCollectionView _view_record = default(ListCollectionView);
		private string _name = "Name";

		public string NameColumn
		{
			get => _name;
			set => Set(ref _name, value);
		}

		#endregion
	}
}