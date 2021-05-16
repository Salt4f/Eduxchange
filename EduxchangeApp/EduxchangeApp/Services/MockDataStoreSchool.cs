using EduxchangeApp.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxchangeApp.Services
{
    public class MockDataStoreSchool : IDataStore<Give>
    {
        private List<Give> gives;

        public MockDataStoreSchool()
        {
            Individual author = new Individual() { Name = "Pepito", Email = "mail@email.com", DateCreated = DateTime.UtcNow };

            gives = new List<Give>()
            {
                new Give { Author = author, Id = "1", Amount = 1, Title = "First item", Description="This is an item description.", Deadline=DateTime.MinValue },
                new Give { Author = author, Id = "2", Amount = 10, Title = "Second item", Description="This is an item description.", Deadline=new DateTime(2021, 11, 20) },
                new Give { Author = author, Id = "3", Amount = 5, Title = "Third item", Description="This is an item description.", Deadline=new DateTime(2022, 5, 20) },
                new Give { Author = author, Id = "4", Amount = 70, Title = "Fourth item", Description="This is an item description.", Deadline=new DateTime(2021, 7, 5) },
                new Give { Author = author, Id = "5", Amount = 15, Title = "Fifth item", Description="This is an item description.", Deadline=new DateTime(2021, 6, 12) },
                new Give { Author = author, Id = "6", Amount = 2, Title = "Sixth item", Description="This is an item description.", Deadline=new DateTime(2019, 8, 8) }
            };
        }

        public async Task<bool> AddItemAsync(Give item)
        {
            gives.Add(item);

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