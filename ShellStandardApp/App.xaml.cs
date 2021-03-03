using System;
using System.Globalization;
using ShellStandardApp.Localization;
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

		/// <summary>
		/// DataService
		/// </summary>
		public static IDataService<Person> DataService = null;

		public App()
		{
			InitializeComponent();

			// Register MockData Service
			ioCContainer.Register<IDataService<Person>, MockDataService>(Lifestyle.Singleton);
			DataService = IoCContainer.GetInstance<IDataService<Person>>();

			// Set UI Resource language
			var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
			SetResourceLanguage(ci);

			// MainPage is AppShell page
			MainPage = new AppShell();
		}

		/// <summary>
		/// SetResourceLanguage
		/// </summary>
		public static void SetResourceLanguage(CultureInfo ci)
		{
			if (ci.TwoLetterISOLanguageName.StartsWith("de"))
				ShellStandardApp.Resources.Resources.Culture = new CultureInfo("de");
			else if (ci.TwoLetterISOLanguageName.StartsWith("es"))
				ShellStandardApp.Resources.Resources.Culture = new CultureInfo("es");
			else if (ci.TwoLetterISOLanguageName.StartsWith("fr"))
				ShellStandardApp.Resources.Resources.Culture = new CultureInfo("fr");
			else if (ci.TwoLetterISOLanguageName.StartsWith("pl"))
				ShellStandardApp.Resources.Resources.Culture = new CultureInfo("pl");
			else if (ci.TwoLetterISOLanguageName.StartsWith("pt"))
				ShellStandardApp.Resources.Resources.Culture = new CultureInfo("pt-PT");
			else
				ShellStandardApp.Resources.Resources.Culture = new CultureInfo("en-GB");

			DependencyService.Get<ILocalize>().SetLocale(ShellStandardApp.Resources.Resources.Culture);

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
