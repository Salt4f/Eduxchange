using EduxchangeApp.Services;
using EduxchangeApp.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EduxchangeApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStoreGive>();
            DependencyService.Register<MockDataStoreNeed>();
            DependencyService.Register<MockDataStorePublication>();
            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
