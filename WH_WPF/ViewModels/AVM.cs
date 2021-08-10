using System;
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

		//Вызывается данынй метот ему подается строка со значениме названию свойства. 
		//Далее создается новый объект со значением названия свойства (new PropertyChangedEventArgs(memberName)) и генерируется событие (PropertyChanged) с этим значением. Таким образом те кто подписан или забиндин на свойсво название которого записано в memberName оповестятся о его изменение.
		protected virtual void OnPropertyChanged(string memberName)
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(memberName)); //условная проверка на null
		}

		///InptStrName
		//Строка которая помечена данным атрибутом [CallerMemberName устанавливается (значением) назвнием свойства которое вызвало данный метод   - атрибут 
		//[CallerMemberName] - маркировка атрибутом классов, полей, свойсв и тд
		protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
		{

			if(Equals(field, value))
				return false;
			field = value;
			//Вызываем метод который отвечает за генерацию собития об изменении свойства которое обновлили
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