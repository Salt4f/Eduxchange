using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using EduxchangeApp.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace EduxchangeApp.Services
{
    class GiveDataStore : IDataStore<Give>
    {
        private readonly HttpClient _client;
        //private readonly JsonSerializer _json;

        private static readonly string queryBase = "http://edu.vgafib.org/api/Gives";

        private HashSet<Give> gives;

        public GiveDataStore()
        {
            _client = HttpClientProvider.GetHttpClient();
            //_json = JsonSerializer.CreateDefault();

            gives = new HashSet<Give>();
        }

        public async Task<bool> AddItemAsync(Give item)
        {
            //string json = JsonConvert.SerializeObject(item);
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
            json.Add("Tags", tags);

            StringContent content = new StringContent(json.ToString(), Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(queryBase, content);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteItemAsync(string id)
        {
            return (await _client.DeleteAsync(queryBase + "/" + id)).IsSuccessStatusCode;
        }

        public async Task<Give> GetItemAsync(string id)
        {
            var response = await _client.GetAsync(queryBase + "/" + id);
            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<Give>(await response.Content.ReadAsStringAsync());
        }

        public async Task<IEnumerable<Give>> GetItemsAsync(bool forceRefresh = false)
        {
            var response = await _client.GetAsync(queryBase);
            response.EnsureSuccessStatusCode();

            return JsonConvert.DeserializeObject<IEnumerable<Give>>(await response.Content.ReadAsStringAsync());
        }

        public async Task<bool> UpdateItemAsync(Give item)
        {
            string json = JsonConvert.SerializeObject(item);
            StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync(queryBase + "/" + item.Id.ToString(), content);

            return response.IsSuccessStatusCode;
        }
    }
}
