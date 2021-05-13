using System;
using Refit;
using StarterKitApp.ModelLocator;
using StarterKitApp.Services;
using StarterKitApp.Services.Interfaces;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: ExportFont("materialdesignicons-webfont.ttf", Alias = "MaterialIconsFont")]
namespace StarterKitApp
{

    public partial class App : Application
    {
        private bool _initialized;
        #region ViewModelLocator
        private static ViewModelLocator _locator;
        public static ViewModelLocator Locator => _locator ??= new ViewModelLocator();
        #endregion
        public App()
        {
            InitializeComponent();
            // Register services
            if (!_initialized)
            {
                _initialized = true;

            }


            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
            //Si premier lancement on supprime toutes les données qui pourraient être présentes dans les storages.
            if (VersionTracking.IsFirstLaunchEver)
            {
                SecureStorage.RemoveAll();
            }
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
