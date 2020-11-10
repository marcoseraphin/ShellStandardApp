using System;
using ShellStandardApp.Models;
using ShellStandardApp.Services;
using SimpleInjector;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ShellStandardApp
{
	public partial class App : Application
	{
		/// <summary>
		/// IoCContainer
		/// </summary>
		private static Container ioCContainer = new SimpleInjector.Container();
		public static Container IoCContainer
		{
			get => ioCContainer;
			set => ioCContainer = value;
		}

		public App()
		{
			InitializeComponent();

			// Register MockData Service
			ioCContainer.Register<IDataService<Person>, MockDataService>(Lifestyle.Singleton);


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
