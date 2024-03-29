﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ViewModels
{
	internal abstract class AVM: INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string memberName = null)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName));
		}

		protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
		{
			if(Equals(field, value))
				return false;
			field = value;
			OnPropertyChanged(PropertyName);
			return true;
		}

		//~ViewModel()
		//{
		//    Dispose(false);
		//}

		public void Dispose()
		{
			Dispose(true);
		}

		private bool _Disposed;

		protected virtual void Dispose(bool Disposing)
		{
			if(!Disposing || _Disposed)
				return;
			_Disposed = true;
			// Освобождение управляемых ресурсов
		}
	}
}