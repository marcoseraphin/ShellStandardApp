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

		/// <summary>
		/// OnAppearing
		/// </summary>
		protected override void OnAppearing()
		{
			base.OnAppearing();

			// Refresh person list and deselect last selected person
			StartPageModel startPageModel = (StartPageModel)this.BindingContext;
			MainThread.BeginInvokeOnMainThread(() =>
			{
				startPageModel.RefreshData();
				startPageModel.SelectedPerson = null;
			});
		}
	}
}
