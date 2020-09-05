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
		/// <summary>
		/// ItemId for return parameter Person ID
		/// </summary>
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

		/// <summary>
		/// Current person
		/// </summary>
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

		/// <summary>
		/// Load person by given ID from parameter
		/// </summary>
		/// <param name="itemId"></param>
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

		/// <summary>
		/// Navigate to Edit Page with current Person ID as parameter which
		/// will be loaded from DataService in Edit Page
		/// </summary>
		/// <param name="obj"></param>
		private async void OnEditName(object obj)
		{
			await Shell.Current.GoToAsync($"{nameof(EditPage)}?{nameof(StartPageModel.ItemId)}={this.ItemId}");
		}

	}
}
