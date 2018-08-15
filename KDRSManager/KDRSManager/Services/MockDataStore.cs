using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using KDRSManager.Models;

[assembly: Xamarin.Forms.Dependency(typeof(KDRSManager.Services.MockDataStore))]
namespace KDRSManager.Services
{
    public class MockDataStore : IDataStore<Company>
    {
        List<Company> items;

        public MockDataStore()
        {
            items = new List<Company>();
            var mockItems = new List<Company>
            {
                new Company { Id = Guid.NewGuid().ToString(), Text = "First item", Description="This is an item description." },
                new Company { Id = Guid.NewGuid().ToString(), Text = "Second item", Description="This is an item description." },
                new Company { Id = Guid.NewGuid().ToString(), Text = "Third item", Description="This is an item description." },
                new Company { Id = Guid.NewGuid().ToString(), Text = "Fourth item", Description="This is an item description." },
                new Company { Id = Guid.NewGuid().ToString(), Text = "Fifth item", Description="This is an item description." },
                new Company { Id = Guid.NewGuid().ToString(), Text = "Sixth item", Description="This is an item description." },
            };

            foreach (var item in mockItems)
            {
                items.Add(item);
            }
        }

        public async Task<bool> AddItemAsync(Company item)
        {
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Company item)
        {
            var _item = items.Where((Company arg) => arg.Id == item.Id).FirstOrDefault();
            items.Remove(_item);
            items.Add(item);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var _item = items.Where((Company arg) => arg.Id == id).FirstOrDefault();
            items.Remove(_item);

            return await Task.FromResult(true);
        }

        public async Task<Company> GetItemAsync(string id)
        {
            return await Task.FromResult(items.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Company>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(items);
        }
    }
}