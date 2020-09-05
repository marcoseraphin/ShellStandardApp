using System;
using System.Collections.Generic;
using ShellStandardApp.ViewModels;
using Xamarin.Forms;

namespace ShellStandardApp.Views
{
	public partial class EditPage : ContentPage
	{
		public EditPage()
		{
			InitializeComponent();
			this.BindingContext = new EditPageModel();
		}
	}
}
