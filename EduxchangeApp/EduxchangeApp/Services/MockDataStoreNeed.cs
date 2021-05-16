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
                new Need {Id = "7", Title = "Bolígrafs", Description="Bolígrafs blaus per escriute.", Deadline=new DateTime(2023, 7, 25), Fulfilled = true, AmountNeeded = 100 , AmountProduct = 50 , AmountCash = 80 , Author = new School() { Name = "Maragall", Email = "maragall@exemple.cat"}},
                new Need {Id = "8", Title = "Llibres de català", Description="Suport de Català.", Deadline=new DateTime(2021, 4, 5), Fulfilled = true, AmountNeeded = 20 , AmountProduct = 14 , AmountCash = 45 , Author = new School() { Name = "Maragall", Email = "maragall@exemple.cat"}},
                new Need {Id = "9",  Title = "DinA4", Description="Fulls en blanc per escriure.", Deadline=new DateTime(2022, 9, 8), Fulfilled = false, AmountNeeded = 400 , AmountProduct = 100 , AmountCash = 70 , Author = new School() { Name = "Escola Pia", Email = "pia@exemple.cat"}},
                new Need {Id = "10",  Title = "Atlas", Description="Material docent.", Deadline=new DateTime(2020, 6, 5), Fulfilled = true, AmountNeeded = 20 , AmountProduct = 20 , AmountCash = 60 , Author = new School() { Name = "Escola Pia", Email = "pia@exemple.cat"}}
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
            var oldItem = needs.Where((Need arg) => arg.Id == id).FirstOrDefault();
            needs.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Need> GetItemAsync(string id)
        {
            return await Task.FromResult(needs.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Need>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(needs);
        }
    }
}