using System;

namespace ShellStandardApp.Models
{
	/// <summary>
	/// Person Model class
	/// </summary>
	public class Person
	{
		public string Id { get; set; }
		public string Name { get; set; }
		public string Location { get; set; }
		public string Details { get; set; }
		public string ImageUrl { get; set; }

		public Person()
		{
		}
	}
}
