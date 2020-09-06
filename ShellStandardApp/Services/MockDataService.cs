﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShellStandardApp.Models;

namespace ShellStandardApp.Services
{
	/// <summary>
	/// Sample Mock DataService
	/// </summary>
	public class MockDataService : IDataService<Person>
	{
		readonly List<Person> items;

		public MockDataService()
		{
			items = new List<Person>()
			{
				new Person { Id = Guid.NewGuid().ToString(), Name = "Marco Seraphin", ImageUrl = "gender.png", Location = "Bad Münstereifel", Details = "Admin" },
				new Person { Id = Guid.NewGuid().ToString(), Name = "Peter Wald", ImageUrl = "gender.png", Location = "Köln", Details = "Benutzter"  },
				new Person { Id = Guid.NewGuid().ToString(), Name = "Stefanie Gerdes", ImageUrl = "gender.png", Location = "Dortmund", Details = "Benutzer"  }
			};
		}

		public async Task<bool> AddItemAsync(Person item)
		{
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> UpdateItemAsync(Person item)
		{
			var oldItem = items.Where((Person arg) => arg.Id == item.Id).FirstOrDefault();
			items.Remove(oldItem);
			items.Add(item);

			return await Task.FromResult(true);
		}

		public async Task<bool> DeleteItemAsync(string id)
		{
			var oldItem = items.Where((Person arg) => arg.Id == id).FirstOrDefault();
			items.Remove(oldItem);

			return await Task.FromResult(true);
		}

		public async Task<Person> GetItemAsync(string id)
		{
			return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
		}

		public async Task<IEnumerable<Person>> GetItemsAsync(bool forceRefresh = false)
		{
			return await Task.FromResult(items);
		}
	}
}
