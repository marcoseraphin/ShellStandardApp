using System;
using System.ComponentModel;
using System.Globalization;
using System.Resources;
using Xamarin.Forms;

namespace ShellStandardApp.Localization
{
    public class LocalizedResources : INotifyPropertyChanged
    {
        const string DEFAULT_LANGUAGE = "en";

        private readonly ResourceManager ResourceManager;
        private CultureInfo CurrentCultureInfo;

        /// <summary>
		/// PropertyChanged event
		/// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
		/// Get binding key from XAML resource element
		/// ==> <Button Text="{Binding LocalizedResources[BTN_OK]}" />
		/// </summary>
		/// <param name="key"></param>
		/// <returns></returns>
        public string this[string key]
        {
            get
            {
                return ResourceManager.GetString(key, CurrentCultureInfo);
            }
        }

        /// <summary>
		/// ctor 1
		/// </summary>
		/// <param name="resource"></param>
		/// <param name="language"></param>
        public LocalizedResources(Type resource, string language = null) : this(resource, new CultureInfo(language ?? DEFAULT_LANGUAGE))
        {
        }

        /// <summary>
		/// ctor 2
		/// </summary>
		/// <param name="resource"></param>
		/// <param name="cultureInfo"></param>
        public LocalizedResources(Type resource, CultureInfo cultureInfo)
        {
            CurrentCultureInfo = cultureInfo;
            ResourceManager = new ResourceManager(resource);

            MessagingCenter.Subscribe<object, CultureChangedMessage>(this, string.Empty, OnCultureChanged);
        }

        /// <summary>
		/// OnCultureChanged
		/// </summary>
		/// <param name="s"></param>
		/// <param name="ccm"></param>
        private void OnCultureChanged(object s, CultureChangedMessage ccm)
        {
            CurrentCultureInfo = ccm.NewCultureInfo;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Item"));
        }


    }
}
