using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShellStandardApp.Models;
using ShellStandardApp.Services;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ShellStandardApp.Controls.SearchHandlers
{

    public class PersonSearchHandler : SearchHandler
    {
        public Type SelectedItemNavigationTarget { get; set; }
        private IList<Person> PersonQueryList;
        private IDataService<Person> dataService = null;

        protected override async void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                this.PersonQueryList = new List<Person>(await dataService.GetItemsAsync(true));

                ItemsSource = this.PersonQueryList
                                  .Where(person => person.Name.ToLower().Contains(newValue.ToLower()))
                                  .ToList<Person>();
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            // work around for bug 5713
            // https://github.com/xamarin/Xamarin.Forms/issues/5713
            await Task.Delay(400);

            ShellNavigationState state = (App.Current.MainPage as Shell).CurrentState;

            await Shell.Current.GoToAsync($"{GetNavigationTarget()}?ItemId={((Person)item).Id}");
        }

        private string GetNavigationTarget()
        {
            return (Shell.Current as AppShell).Routes.FirstOrDefault(route => route.Value.Equals(SelectedItemNavigationTarget)).Key;
        }

        public PersonSearchHandler()
		{
            // Get search item source data
            MainThread.BeginInvokeOnMainThread(async () =>
            {
                //var dataService = DependencyService.Resolve<IDataService<Person>>();
                this.dataService = App.IoCContainer.GetInstance<IDataService<Person>>();
                this.PersonQueryList = new List<Person>(await dataService.GetItemsAsync(true)); 
            });
           
		}
    }
}
