using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ShellStandardApp.Services
{
	public interface IDataService<T>
	{
		Task<bool> AddItemAsync(T item);
		Task<bool> UpdateItemAsync(T item);
		Task<bool> DeleteItemAsync(string id);
		Task<T> GetItemAsync(string id);
		Task<IEnumerable<T>> GetItemsAsync(bool forceRefresh = false);
	}
}
