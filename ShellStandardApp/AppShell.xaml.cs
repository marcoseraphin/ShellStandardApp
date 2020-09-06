﻿using System;
using System.Collections.Generic;
using ShellStandardApp.Views;
using Xamarin.Forms;

namespace ShellStandardApp
{
	public partial class AppShell : Xamarin.Forms.Shell
	{
		private readonly Dictionary<string, Type> routes = new Dictionary<string, Type>();
		public Dictionary<string, Type> Routes { get { return routes; } }

		public AppShell()
		{
			InitializeComponent();

			// Register Route for search handler
			routes.Add(nameof(EditPage), typeof(EditPage));

			// Register Route to Edit Page
			Routing.RegisterRoute(nameof(EditPage), typeof(EditPage));
		}
	}
}
