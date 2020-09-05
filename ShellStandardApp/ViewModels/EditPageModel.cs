using System;
using System.Diagnostics;
using System.Windows.Input;
using ShellStandardApp.Models;
using ShellStandardApp.Views;
using Xamarin.Forms;

namespace ShellStandardApp.ViewModels
{
	[QueryProperty(nameof(ItemId), nameof(ItemId))]
	public class EditPageModel : BaseViewModel
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
				itemId = value;
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

		private async void OnSaveName(object obj)
		{
			await this.DataService.UpdateItemAsync(this.Person);
			await Shell.Current.GoToAsync("..?" + nameof(EditPageModel.ItemId) + "=" + this.ItemId);
		}
	}
}
