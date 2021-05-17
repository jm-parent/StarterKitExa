using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StarterKitApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NukeImagesView : ContentPage
    {
        public NukeImagesView()
        {
            InitializeComponent();
            BindingContext = GetImageUrls(100).ToArray();
        }
        readonly Random random = new Random();
        IEnumerable<ImageSource> GetImageUrls(int count)
        {
            var width = (int)(DeviceDisplay.MainDisplayInfo.Width / DeviceDisplay.MainDisplayInfo.Density);
            var url = $"https://picsum.photos/{width}/200";

            for (int i = 0; i < count; i++)
            {
                yield return ImageSource.FromUri(new Uri($"{url}?{random.Next()}"));
            }
        }
    }
}