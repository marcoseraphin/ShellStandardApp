using System;
using System.Globalization;

namespace ShellStandardApp.Localization
{
    public class CultureChangedMessage
    {
        /// <summary>
		/// NewCultureInfo
		/// </summary>
        public CultureInfo NewCultureInfo { get; private set; }

        /// <summary>
		/// ctor 1
		/// </summary>
		/// <param name="lngName"></param>
        public CultureChangedMessage(string lngName) : this(new CultureInfo(lngName)) { }

        /// <summary>
		/// ctor 2
		/// </summary>
		/// <param name="newCultureInfo"></param>
        public CultureChangedMessage(CultureInfo newCultureInfo)
        {
            NewCultureInfo = newCultureInfo;
        }
    }
}
