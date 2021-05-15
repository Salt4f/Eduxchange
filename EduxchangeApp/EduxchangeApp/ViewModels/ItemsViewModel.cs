using EduxchangeApp.Models;
using EduxchangeApp.Views;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace EduxchangeApp.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private Publication _selectedPublication;

        public ObservableCollection<Publication> Publications { get; }
        public Command LoadNeedsCommand { get; }
        public Command LoadGivesCommand { get; }
        public Command AddPublicationCommand { get; }
        public Command<Publication> PublicationTapped { get; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Publications = new ObservableCollection<Publication>();

            PublicationTapped = new Command<Publication>(OnPublicationSelected);

            AddPublicationCommand = new Command(OnAddPublication);

            var u = new Individual()
            {
                Name="Sergio", Email="sergio.camps@gmail.com"
            };
            var g = new Give { Author=u, Title = "Libro Ot el bruixot", Description = "This is an item description.", Deadline = new DateTime(2021, 11, 20) };

            Task.Run(async() => await DataStoreGive.AddItemAsync(g));
        }

        async Task ExecuteLoadNeedsCommand()
        {
            IsBusy = true;

            try
            {
                Publications.Clear();
                var publications = await DataStoreNeed.GetItemsAsync(true);
                foreach (var publication in publications)
                {
                    Publications.Add(publication);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        async Task ExecuteLoadGivesCommand()
        {
            IsBusy = true;

            try
            {
                Publications.Clear();
                var publications = await DataStoreGive.GetItemsAsync(true);
                foreach (var publication in publications)
                {
                    Publications.Add(publication);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
            SelectedPublication = null;
        }

        public Publication SelectedPublication
        {
            get => _selectedPublication;
            set
            {
                SetProperty(ref _selectedPublication, value);
                OnPublicationSelected(value);
            }
        }

        private async void OnAddPublication(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewItemPage));
        }

        async void OnPublicationSelected(Publication publication)
        {
            if (publication == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={publication.Id}");
        }

        //public ICommand LoadGivePublications { get; }

        public ICommand LoadGivePublications => new Command(async () => await ExecuteLoadGivesCommand());

        public ICommand LoadNeedPublications => new Command(async () => await ExecuteLoadNeedsCommand());
    }
}