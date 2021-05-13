using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StarterKitApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RedditView : ContentPage
    {
        public RedditView()
        {
            InitializeComponent();
            BindingContext = App.Locator.Reddit;
        }
    }
}