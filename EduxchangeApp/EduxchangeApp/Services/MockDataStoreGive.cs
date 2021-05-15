using EduxchangeApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxchangeApp.Services
{
    public class MockDataStoreGive : IDataStore<Give>
    {
        readonly List<Give> gives;

        public MockDataStoreGive()
        {
            gives = new List<Give>()
            {
                new Give { Id = 1, Title = "First item", Description="This is an item description.", Deadline=DateTime.MinValue },
                new Give { Id = 2, Title = "Second item", Description="This is an item description.", Deadline=new DateTime(2021, 11, 20) },
                new Give { Id = 3, Title = "Third item", Description="This is an item description.", Deadline=new DateTime(2022, 5, 20) },
                new Give { Id = 4, Title = "Fourth item", Description="This is an item description.", Deadline=new DateTime(2021, 7, 5) },
                new Give { Id = 5, Title = "Fifth item", Description="This is an item description.", Deadline=new DateTime(2021, 6, 12) },
                new Give { Id = 6, Title = "Sixth item", Description="This is an item description.", Deadline=new DateTime(2019, 8, 8) }
            };
        }

        public async Task<bool> AddItemAsync(Give give)
        {
            gives.Add(give);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Give give)
        {
            var oldItem = gives.Where((Give arg) => arg.Id == give.Id).FirstOrDefault();
            gives.Remove(oldItem);
            gives.Add(give);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = gives.Where((Give arg) => arg.Id.ToString() == id).FirstOrDefault();
            gives.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Give> GetItemAsync(string id)
        {
            return await Task.FromResult(gives.FirstOrDefault(s => s.Id.ToString() == id));
        }

        public async Task<IEnumerable<Give>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(gives);
        }
    }
}