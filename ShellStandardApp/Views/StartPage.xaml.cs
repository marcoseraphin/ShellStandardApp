using System;
using System.Collections.Generic;
using ShellStandardApp.ViewModels;
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
	}
}
