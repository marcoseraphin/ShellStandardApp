using System;
using System.Globalization;
using System.Threading;
using Foundation;
using ShellStandardApp.Droid.DependencyServices;
using ShellStandardApp.Localization;
using Xamarin.Forms;

[assembly: Dependency(typeof(Locale_iOS))]
namespace ShellStandardApp.Droid.DependencyServices
{
    public class Locale_iOS : ILocalize
    {
        public void SetLocale(CultureInfo ci)
        {

            Thread.CurrentThread.CurrentCulture = ci;
            Thread.CurrentThread.CurrentUICulture = ci;

            //var iosLocaleAuto = NSLocale.AutoUpdatingCurrentLocale.LocaleIdentifier;
            //var netLocale = iosLocaleAuto.Replace("_", "-");
            //var ci = new System.Globalization.CultureInfo(netLocale);
            //Thread.CurrentThread.CurrentCulture = ci;
            //Thread.CurrentThread.CurrentUICulture = ci;
        }

        /// <remarks>
        /// Not sure if we can cache this info rather than querying every time
        /// </remarks>
        public CultureInfo GetCurrentCultureInfo()
        {
            try
            {
                var iosLocaleAuto = NSLocale.AutoUpdatingCurrentLocale.LocaleIdentifier;
                var iosLanguageAuto = NSLocale.AutoUpdatingCurrentLocale.LanguageCode;
                var netLocale = iosLocaleAuto.Replace("_", "-");
                var netLanguage = iosLanguageAuto.Replace("_", "-");

                #region Debugging Info
                // prefer *Auto updating properties
                //          var iosLocale = NSLocale.CurrentLocale.LocaleIdentifier;
                //          var iosLanguage = NSLocale.CurrentLocale.LanguageCode;
                //          var netLocale = iosLocale.Replace ("_", "-");
                //          var netLanguage = iosLanguage.Replace ("_", "-");

                Console.WriteLine("nslocaleid:" + iosLocaleAuto);
                Console.WriteLine("nslanguage:" + iosLanguageAuto);
                Console.WriteLine("ios:" + iosLanguageAuto + " " + iosLocaleAuto);
                Console.WriteLine("net:" + netLanguage + " " + netLocale);

                //var ci = new System.Globalization.CultureInfo(netLocale);
                //Thread.CurrentThread.CurrentCulture = ci;
                //Thread.CurrentThread.CurrentUICulture = ci;

                //Console.WriteLine("thread:  " + Thread.CurrentThread.CurrentCulture);
                //Console.WriteLine("threadui:" + Thread.CurrentThread.CurrentUICulture);
                #endregion

                if (NSLocale.PreferredLanguages.Length > 0)
                {
                    var pref = NSLocale.PreferredLanguages[0];
                    netLanguage = pref.Replace("_", "-");
                    Console.WriteLine("preferred:" + netLanguage);
                }
                else
                {
                    netLanguage = "en-US"; // default, shouldn't really happen :)
                }

                CultureInfo ci = new CultureInfo(netLanguage);

                return ci;

            }
            catch (Exception)
            {
                CultureInfo ci = new CultureInfo("en-US");
                return ci;
            }

        }
    }
}
