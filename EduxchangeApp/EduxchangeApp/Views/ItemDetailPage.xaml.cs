using EduxchangeApp.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace EduxchangeApp.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}