using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Windows.Input;
using ShellStandardApp.Models;
using ShellStandardApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShellStandardApp.ViewModels
{
	[QueryProperty(nameof(ItemId), nameof(ItemId))]
	public class StartPageModel : BaseViewModel
	{
		private string itemId;
		public string ItemId
		{
			get
			{
				return this.Person.Id;
			}
			set
			{
				itemId = Uri.UnescapeDataString(value); 
				LoadPersonById(value);
			}
		}

		private Person _Person;
		public Person Person
		{
			get => _Person;
			set
			{
				SetProperty(ref _Person, value);
				OnPropertyChanged(nameof(Person));
			}
		}

		public ICommand EditNameCommand { get; }

		/// <summary>
		/// ctor
		/// </summary>
		public StartPageModel()
		{
			MainThread.BeginInvokeOnMainThread(async() =>
			{
				IEnumerable<Person> personList = await this.DataService.GetItemsAsync(true);
				this.Person = personList.First();
			});
	
			EditNameCommand = new Command(OnEditName);
		}

		public async void LoadPersonById(string itemId)
		{
			try
			{
				var person = await this.DataService.GetItemAsync(itemId);
				this.Person = person;
			}
			catch (Exception)
			{
				Debug.WriteLine("Failed to Load Person with ID = " + itemId);
			}
		}
		
		private async void OnEditName(object obj)
		{
			await Shell.Current.GoToAsync($"{nameof(EditPage)}?{nameof(StartPageModel.ItemId)}={this.ItemId}");

			//await Shell.Current.GoToAsync($"{nameof(EditPage)}?{nameof(StartPageModel.Name)}={this.Name}");
		}

	}
}
