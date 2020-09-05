using System;
using System.Collections.Generic;
using ShellStandardApp.Views;
using Xamarin.Forms;

namespace ShellStandardApp
{
	public partial class AppShell : Xamarin.Forms.Shell
	{
		public AppShell()
		{
			InitializeComponent();

			Routing.RegisterRoute(nameof(EditPage), typeof(EditPage));
		}
	}
}
