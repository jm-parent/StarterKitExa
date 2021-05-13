using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using StarterKitApp.Helpers;
using StarterKitApp.Views.Base;
using StarterKitApp.Views.Popup;
using Xamarin.CommunityToolkit.Extensions;
using Xamarin.Forms;

namespace StarterKitApp.ViewModels
{
    public class PopupsViewModel : StarterKitBaseViewModel
    {
        public ICommand OpenResultPopup => new SafeCommand().Async(async () =>
        {
            GenericResultPopup.Result result = await Application.Current.MainPage.Navigation.ShowPopupAsync(new GenericResultPopup());
            await Application.Current.MainPage.DisplayAlert($"{result.Title}", $"{result.Message}", "OK");
        });
        public ICommand OpenAlert => new SafeCommand().Async(async () =>
        {
            await Application.Current.MainPage.DisplayAlert("Open Alert Title", "Open Alert Message","Ok");
        });
        public ICommand OpenSimplePopup => new SafeCommand().Async(async () =>
        {
            Application.Current.MainPage.Navigation.ShowPopup(new SimplePopup());
        });
    }
}
