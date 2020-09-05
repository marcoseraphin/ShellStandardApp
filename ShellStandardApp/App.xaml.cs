using System;
using ShellStandardApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellStandardApp
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			// Register DataService here with MockDataService
			DependencyService.Register<MockDataService>();

			// MainPage is AppShell page
			MainPage = new AppShell();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
