using System;
using System.Collections.Generic;
using System.Globalization;
using ShellStandardApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShellStandardApp.Views
{
	public partial class AboutPage : ContentPage
	{
		public AboutPage()
		{
			InitializeComponent();
			this.BindingContext = new AboutPageModel();
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();

			AboutPageModel aboutPageModel = (AboutPageModel)this.BindingContext;
			MainThread.BeginInvokeOnMainThread(() =>
			{
				string savedLanguage = Preferences.Get("Language", "en-GB");
				CultureInfo ci = new CultureInfo(savedLanguage);
				App.SetResourceLanguage(ci);

				KeyValuePair<CultureInfo, string> keyValuePair = new KeyValuePair<CultureInfo, string>(ci, ci.DisplayName);
				aboutPageModel.SelectedItem = keyValuePair;
				aboutPageModel.OrigLanguage = savedLanguage;
			});
		}
	}
}
