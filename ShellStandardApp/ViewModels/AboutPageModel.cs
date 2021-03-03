using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using ShellStandardApp.Localization;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShellStandardApp.ViewModels
{
	public class AboutPageModel : BaseViewModel
	{
		/// <summary>
		/// LanguagePickerItems
		/// </summary>
		private Dictionary<CultureInfo, string> LanguagePickerItems = new Dictionary<CultureInfo, string>();

		/// <summary>
		/// PickerItemList
		/// </summary>
		public List<KeyValuePair<CultureInfo, string>> PickerItemList
		{
			get => LanguagePickerItems.ToList();
		}

		public string OrigLanguage = String.Empty;

		/// <summary>
		/// SelectedItem
		/// </summary>
		private KeyValuePair<CultureInfo, string> _selectedItem;
		public KeyValuePair<CultureInfo, string> SelectedItem
		{
			get => _selectedItem;
			set
			{
				SetProperty(ref _selectedItem, value);

				if (this.SelectedItem.Key != null)
				{
					MessagingCenter.Send<object, CultureChangedMessage>(this, string.Empty, new CultureChangedMessage(this.SelectedItem.Key.Name));
				}
			}
		}

		/// <summary>
		/// OkButtonCommand
		/// </summary>
		public Command OkButtonCommand
		{
			get
			{
				return new Command(async () =>
				{
					try
					{
						
						App.SetResourceLanguage(this.SelectedItem.Key);
						Preferences.Set("Language", this.SelectedItem.Key.Name);

						MessagingCenter.Send<object, CultureChangedMessage>(this, string.Empty, new CultureChangedMessage(this.SelectedItem.Key.Name));

						// Return to ListPage
						await Shell.Current.GoToAsync("//StartPage");
					}
					catch (Exception ex)
					{
						Debug.WriteLine("Error in OkButtonCommand: " + ex.Message);
					}
				}
				);
			}
		}

		/// <summary>
		/// Available languages
		/// </summary>
		private CultureInfo ci_GB = new CultureInfo("en-GB");
		private CultureInfo ci_DE = new CultureInfo("de-DE");
		private CultureInfo ci_FR = new CultureInfo("fr-FR");
		private CultureInfo ci_ES = new CultureInfo("es-ES");
		private CultureInfo ci_PL = new CultureInfo("pl-PL");
		private CultureInfo ci_PT = new CultureInfo("pt-PT");

		public AboutPageModel()
		{
			this.LanguagePickerItems = new Dictionary<CultureInfo, string>()
			{
				{
					ci_GB,
					ci_GB.DisplayName
				},
				{
					ci_DE,
					ci_DE.DisplayName
				},
				{
					ci_FR,
					ci_FR.DisplayName
				},
				{
					ci_ES,
					ci_ES.DisplayName
				},
				{
					ci_PL,
					ci_PL.DisplayName
				},
				{
					ci_PT,
					ci_PT.DisplayName
				}
			};
		}
	}
}
