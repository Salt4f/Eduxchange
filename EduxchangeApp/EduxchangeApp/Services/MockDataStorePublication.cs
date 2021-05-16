using EduxchangeApp.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduxchangeApp.Services
{
    public class MockDataStorePublication : IDataStore<Publication>
    {
        private List<Publication> gives;

        public MockDataStorePublication()
        {
            Individual author = new Individual() { Name = "Pepito", Email = "mail@email.com", DateCreated = DateTime.UtcNow };

            gives = new List<Publication>()
            {
                new Give { Author = new School() { Name = "Maragall", Email = "maragall@exemple.cat"}, Id = "1", Amount = 1, Title = "Projector", Description="Proporciona suport audiovisual.", Deadline=new DateTime(2022, 1, 20)  },
                new Give { Author = new School() { Name = "Maragall", Email = "maragall@exemple.cat"}, Id = "2", Amount = 10, Title = "Llibres matemàtics", Description="Suport matemàtic de nivell escolar.", Deadline=new DateTime(2021, 11, 2) },
                new Give { Author = new Individual() { Name = "Pere", Email = "pere@exemple.cat"}, Id = "4", Amount = 70, Title = "Guixos", Description="Guixos per escriure a la pissarra(diferents colors).", Deadline=new DateTime(2021, 7, 5) },
                new Give { Author = new Individual() { Name = "Martí", Email = "marti@exemple.cat"}, Id = "5", Amount = 15, Title = "Esborradors", Description="Per esborrar el que hi hagi escrit a la pissarra.", Deadline=new DateTime(2021, 6, 12) },
                new Give { Author = new School() { Name = "Maragall", Email = "maragall@exemple.cat"}, Id = "6", Amount = 2, Title = "Altaveus", Description="Suport d'audio per fer ús docent.", Deadline=new DateTime(2019, 8, 8) },
                new Need {Id = "7", Title = "Bolígrafs", Description="Bolígrafs blaus per escriute.", Deadline=new DateTime(2023, 7, 25), Fulfilled = true, AmountNeeded = 100 , AmountProduct = 50 , AmountCash = 80 , Author = new School() { Name = "Maragall", Email = "maragall@exemple.cat"}},
                new Need {Id = "8", Title = "Llibres de català", Description="Suport de Català.", Deadline=new DateTime(2021, 4, 5), Fulfilled = true, AmountNeeded = 20 , AmountProduct = 14 , AmountCash = 45 , Author = new School() { Name = "Maragall", Email = "maragall@exemple.cat"}},
                new Need {Id = "9",  Title = "DinA4", Description="Fulls en blanc per escriure.", Deadline=new DateTime(2022, 9, 8), Fulfilled = false, AmountNeeded = 400 , AmountProduct = 100 , AmountCash = 70 , Author = new School() { Name = "Escola Pia", Email = "pia@exemple.cat"}},
                new Need {Id = "10",  Title = "Atlas", Description="Material docent.", Deadline=new DateTime(2020, 6, 5), Fulfilled = true, AmountNeeded = 20 , AmountProduct = 20 , AmountCash = 60 , Author = new School() { Name = "Escola Pia", Email = "pia@exemple.cat"}}
            };


        }

        public async Task<bool> AddItemAsync(Publication item)
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

        public async Task<bool> UpdateItemAsync(Publication give)
        {
            var oldItem = gives.Where((Publication arg) => arg.Id == give.Id).FirstOrDefault();
            gives.Remove(oldItem);
            gives.Add(give);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            var oldItem = gives.Where((Publication arg) => arg.Id == id).FirstOrDefault();
            gives.Remove(oldItem);

            return await Task.FromResult(true);
        }

        public async Task<Publication> GetItemAsync(string id)
        {
            return await Task.FromResult(gives.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<Publication>> GetItemsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(gives);
        }
    }
}