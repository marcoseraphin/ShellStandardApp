using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using ShellStandardApp.Models;
using ShellStandardApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShellStandardApp.ViewModels
{
	public class StartPageModel : BaseViewModel
	{	
		private string ItemId;
		
		/// <summary>
		/// Current person
		/// </summary>
		private Person _SelectedPerson;
		public Person SelectedPerson
		{
			get => _SelectedPerson;
			set
			{
				SetProperty(ref _SelectedPerson, value);
				OnPropertyChanged(nameof(Person));
			}
		}

		private ObservableCollection<Person> _PersonList;
		public ObservableCollection<Person> PersonList
		{
			get => _PersonList;
			set
			{
				SetProperty(ref _PersonList, value);
				OnPropertyChanged(nameof(PersonList));
			}
		}

		public ICommand EditNameCommand { get; }
		public ICommand SelectionChangedCommand { get; }
		public ICommand RefreshCommand { get; }

		/// <summary>
		/// ctor
		/// </summary>
		public StartPageModel()
		{
			MainThread.BeginInvokeOnMainThread(async () =>
			{
				this.PersonList =new ObservableCollection<Person>(await this.DataService.GetItemsAsync(true));
			});
			 
			this.SelectionChangedCommand = new Command(OnSelectedChanged);
			this.RefreshCommand = new Command(RefreshData);
		}

		private bool _IsRefreshing;
		public bool IsRefreshing
		{
			get => _IsRefreshing;
			set => SetProperty(ref _IsRefreshing, value);
		}

		public void RefreshData()
		{
			MainThread.BeginInvokeOnMainThread(async () =>
			{
				this.PersonList = new ObservableCollection<Person>(await this.DataService.GetItemsAsync(true));
			});

			this.IsRefreshing = false;
		}

		private async void OnSelectedChanged(object obj)
		{	
			await Shell.Current.GoToAsync($"{nameof(EditPage)}?{nameof(StartPageModel.ItemId)}={this.SelectedPerson.Id}");	
		}	
	}
}
