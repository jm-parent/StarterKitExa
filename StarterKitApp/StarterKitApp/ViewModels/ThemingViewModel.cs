using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace StarterKitApp.ViewModels
{
    public class ThemingViewModel : ObservableObject
    {
        public ThemingViewModel()
        {
            switch (Application.Current.UserAppTheme)
            {
                case OSAppTheme.Unspecified:
                    isToggled = true;
                    ThemeLabel = "Dark";
                    break;
                case OSAppTheme.Light:
                    isToggled = false;
                    ThemeLabel = "Light";
                    break;
                case OSAppTheme.Dark:
                    isToggled = true;
                    ThemeLabel = "Dark";
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private bool isToggled = false;
        public string ThemeLabel { get; set; }
        public Command ToggleIsOwnedCommand => new Command(() =>
        {
            isToggled = !isToggled;
            Application.Current.UserAppTheme = isToggled ? OSAppTheme.Dark : OSAppTheme.Light;
            ThemeLabel = isToggled ? "Dark" : "Light" ;
        });

        public string ThemingMd { get; set; } = $"# Modification dy Theme" +
                                                $"\n";

    }
}
