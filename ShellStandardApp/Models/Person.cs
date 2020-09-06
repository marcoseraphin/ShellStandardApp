using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using ShellStandardApp.ViewModels;

namespace ShellStandardApp.Models
{
	/// <summary>
	/// Person Model class
	/// </summary>
	public class Person : INotifyPropertyChanged
	{
		public string Id { get; set; }

		private string _Name;
		public string Name
		{
			get => _Name;
			set
			{
				_Name = value;
				OnPropertyChanged(nameof(Name));
			}
		}
		public string Location { get; set; }
		public string Details { get; set; }
		public string ImageUrl { get; set; }

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

		public Person()
		{
		}
	}
}
