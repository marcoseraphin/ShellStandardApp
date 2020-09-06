using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using ShellStandardApp.Models;
using ShellStandardApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShellStandardApp.Views
{
	public partial class StartPage : ContentPage
	{
		public StartPage()
		{
			InitializeComponent();
			this.BindingContext = new StartPageModel();
		}
		 
		protected override void OnAppearing()
		{
			base.OnAppearing();

			//StartPageModel startPageModel = (StartPageModel)this.BindingContext;
			//MainThread.BeginInvokeOnMainThread(async () =>
			//{
			//	//startPageModel.SelectedPerson = null;
			//	//startPageModel.PersonList = new ObservableCollection<Person>(await startPageModel.DataService.GetItemsAsync(true));
			//	startPageModel.RefreshData();
			//});	
		}
	}
}
