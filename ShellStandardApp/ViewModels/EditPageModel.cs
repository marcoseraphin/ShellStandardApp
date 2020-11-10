using System;
using System.Diagnostics;
using System.Windows.Input;
using ShellStandardApp.Models;
using ShellStandardApp.Services;
using ShellStandardApp.Views;
using Xamarin.Forms;

namespace ShellStandardApp.ViewModels
{
	[QueryProperty(nameof(ItemId), nameof(ItemId))]
	public class EditPageModel : BaseViewModel
	{
		/// <summary>
		/// ItemId for parameter Person ID
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
				itemId = value;
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
			}
		}

		public ICommand SaveNameCommand { get; }

		/// <summary>
		/// ctor
		/// </summary>
		public EditPageModel()
		{
			SaveNameCommand = new Command(OnSaveName);
		}

		/// <summary>
		/// Load person by given ID from parameter
		/// </summary>
		/// <param name="itemId"></param>
		public async void LoadPersonById(string itemId)
		{
			try
			{
				IDataService<Person> dataService = App.IoCContainer.GetInstance<IDataService<Person>>();
				var person = await dataService.GetItemAsync(itemId);

				// Copy person from parameter for breaking reference to DataService entry
				this.Person = new Person()
				{
					Id = person.Id,
					Name = person.Name,
					Details = person.Details,
					Location = person.Location,
					ImageUrl = person.ImageUrl	
				};
			}
			catch (Exception)
			{
				Debug.WriteLine("Failed to Load Person with ID = " + itemId);
			}
		}

		/// <summary>
		/// OnSaveName
		/// </summary>
		/// <param name="obj"></param>
		private async void OnSaveName(object obj)
		{
			IDataService<Person> dataService = App.IoCContainer.GetInstance<IDataService<Person>>();

			await dataService.UpdateItemAsync(this.Person);
			await Shell.Current.GoToAsync("..");


			//await Shell.Current.GoToAsync("..?" + nameof(EditPageModel.ItemId) + "=" + this.ItemId);
		}
	}
}
