using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StarterKitApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StarterKitApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TutoCreateANewPageView : ContentPage
    {
        public TutoCreateANewPageView()
        {
            InitializeComponent();
            BindingContext = App.Locator.TutoCreatePage;
        }

        protected override void OnAppearing()
        {
            var vm = (TutoCreateANewPageViewModel) BindingContext;
            vm.LoadDocsCommand.Execute("TutoCreateANewPageMD");
            base.OnAppearing();
        }
    }
}