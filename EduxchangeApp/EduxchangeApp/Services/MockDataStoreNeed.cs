using EduxchangeApp.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxchangeApp.Services
{
    public class MockDataStoreNeed : IDataStore<Need>
    {
        private List<Need> needs;

        public MockDataStoreNeed()
        {
            School author = new School() { Name = "IES SEI", Email = "ies@email.com", DateCreated = DateTime.UtcNow };

            needs = new List<Need>()
            {
                new Need { Author = author, Id = 1, AmountNeeded = 1, Title = "First item", Description="This is an item description.", Deadline=DateTime.MinValue },
                new Need { Author = author, Id = 2, AmountNeeded = 10, Title = "Second item", Description="This is an item description.", Deadline=new DateTime(2021, 11, 20) },
                new Need { Author = author, Id = 3, AmountNeeded = 5, Title = "Third item", Description="This is an item description.", Deadline=new DateTime(2022, 5, 20) },
                new Need { Author = author, Id = 4, AmountNeeded = 70, Title = "Fourth item", Description="This is an item description.", Deadline=new DateTime(2021, 7, 5) },
                new Need { Author = author, Id = 5, AmountNeeded = 15, Title = "Fifth item", Description="This is an item description.", Deadline=new DateTime(2021, 6, 12) },
                new Need { Author = author, Id = 6, AmountNeeded = 2, Title = "Sixth item", Description="This is an item description.", Deadline=new DateTime(2019, 8, 8) }
            };
        }

        public async Task<bool> AddItemAsync(Need item)
        {
            needs.Add(item);

            /*
            var json = new JObject();
            json.Add("Title", item.Title);
            json.Add("Description", item.Description);
            json.Add("Amount", item.Amount);
            json.Add("Author", item.Author.Email);
            json.Add("Beneficiary", item.Beneficiary.Email);
            json.Add("Deadline", item.Deadline);
            json.Add("Fulfilled", item.Fulfilled);
            json.Add("Photo", item.Photo);
            var tags = new JArray();
            foreach (var tag in item.Tags)
            {
                tags.Add(tag);
            }
            json.Add("Tags", tags);*/

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(Need give)
        {
            var oldItem = needs.Where((Need arg) => arg.Id == give.Id).FirstOrDefault();
            needs.Remove(oldItem);
            needs.Add(give);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = needs.Where((Need arg) => arg.Id.ToString() == id).FirstOrDefault();
            needs.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Need> GetItemAsync(string id)
        {
            return await Task.FromResult(needs.FirstOrDefault(s => s.Id.ToString() == id));
        }

        public async Task<IEnumerable<Need>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(needs);
        }
    }
}