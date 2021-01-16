using System.Collections.ObjectModel;
using System.Windows.Input;
using ShellStandardApp.Models;
using ShellStandardApp.Views;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShellStandardApp.ViewModels
{
	public class StartPageModel : BaseViewModel
	{
		/// <summary>
		/// For routing reasons only
		/// </summary>
		private string ItemId;
		
		/// <summary>
		/// Selected person
		/// </summary>
		private Person _SelectedPerson;
		public Person SelectedPerson
		{
			get => _SelectedPerson;
			set
			{
				SetProperty(ref _SelectedPerson, value);
			}
		}

		/// <summary>
		/// CollectionView person item source
		/// </summary>
		private ObservableCollection<Person> _PersonList;
		public ObservableCollection<Person> PersonList
		{
			get => _PersonList;
			set
			{
				SetProperty(ref _PersonList, value);
			}
		}

		/// <summary>
		/// Commands
		/// </summary>
		public ICommand EditNameCommand { get; }
		public ICommand SelectionChangedCommand { get; }
		public ICommand RefreshCommand { get; }

		/// <summary>
		/// IsRefreshing
		/// </summary>
		private bool _IsRefreshing;
		public bool IsRefreshing
		{
			get => _IsRefreshing;
			set => SetProperty(ref _IsRefreshing, value);
		}

		/// <summary>
		/// RefreshData
		/// </summary>
		public void RefreshData()
		{
			MainThread.BeginInvokeOnMainThread(async () =>
			{
				this.PersonList.Clear();
				this.PersonList = new ObservableCollection<Person>(await App.DataService.GetItemsAsync(true));
			});

			this.IsRefreshing = false;
		}

		/// <summary>
		/// Navigate using route to Edit Page
		/// </summary>
		/// <param name="obj"></param>
		private async void OnSelectedChanged(object obj)
		{
			if (this.SelectedPerson != null)
			{
				await Shell.Current.GoToAsync($"{nameof(EditPage)}?{nameof(StartPageModel.ItemId)}={this.SelectedPerson.Id}");
			}
		}

		/// <summary>
		/// ctor
		/// </summary>
		public StartPageModel()
		{
			//this.dataService = App.IoCContainer.GetInstance<IDataService<Person>>();

			MainThread.BeginInvokeOnMainThread(async () =>
			{
				this.PersonList = new ObservableCollection<Person>(await App.DataService.GetItemsAsync(true));
				//this.PersonList = new ObservableCollection<Person>(await this.DataService.GetItemsAsync(true));
			});

			this.SelectionChangedCommand = new Command(OnSelectedChanged);
			this.RefreshCommand = new Command(RefreshData);
		}
	}
}
