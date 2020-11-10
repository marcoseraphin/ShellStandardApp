using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ShellStandardApp.ViewModels
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		/// <summary>
		/// SetProperty 
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="backingStore"></param>
		/// <param name="value"></param>
		/// <param name="propertyName"></param>
		/// <param name="onChanged"></param>
		/// <returns></returns>
		protected bool SetProperty<T>(ref T backingStore, T value,
			[CallerMemberName] string propertyName = "",
			Action onChanged = null)
		{
			if (EqualityComparer<T>.Default.Equals(backingStore, value))
				return false;

			backingStore = value;
			onChanged?.Invoke();
			OnPropertyChanged(propertyName);
			return true;
		}

		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;
		protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
		{
			var changed = PropertyChanged;
			if (changed == null)
				return;

			changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
		}
		#endregion

		protected BaseViewModel()
		{
		}
	}
}
