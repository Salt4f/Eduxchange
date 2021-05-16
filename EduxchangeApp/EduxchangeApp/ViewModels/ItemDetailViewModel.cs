using EduxchangeApp.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace EduxchangeApp.ViewModels
{
    [QueryProperty(nameof(PublicationId), nameof(PublicationId))]
    public class ItemDetailViewModel : BaseViewModel
    {
        private string publicationId;
        private string text;
        private string description;
        public string Id { get; set; }
        public string PublicationType { get; set; }
        public string Name { get; set; }

        public string Text
        {
            get => text;
            set => SetProperty(ref text, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string PublicationId
        {
            get
            {
                return publicationId;
            }
            set
            {
                publicationId = value;
                LoadPublicationId(value);
            }
        }

        public async void LoadPublicationId(string publicationId)
        {
            try
            {
                var item = await DataStorePublication.GetItemAsync(publicationId);
                Id = item.Id;
                Title = item.Title;
                Description = item.Description;
                PublicationType = item.GetType() == typeof(Give) ? "Give" : "Need";
                Name = item.GetType() == typeof(Give) ? ((Give)item).Author.Name : ((Need)item).Author.Name;
                Name = "By " + Name;
            }
            catch (Exception)
            {
                Debug.WriteLine("Failed to Load Publication");
            }
            
        }
    }
}
