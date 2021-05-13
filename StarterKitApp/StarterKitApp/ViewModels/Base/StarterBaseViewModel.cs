using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.CommunityToolkit.ObjectModel;

namespace StarterKitApp.ViewModels.Base
{
    public class StarterBaseViewModel : ObservableObject
    {
            public StarterBaseViewModel()
            {
            }

            public string IntroductionMd { get; set; } = $"# Bienvenue sur l'application StarterKit" +
                                                         $"\n" +
                                                         $"\n" +
                                                         $"Vous retrouverez sur cette application un ensemble d'écran pour démarrer une application Xamarin.Forms chez Exakis Nelite" +
                                                         $"\n" +
                                                         $"- **Présentation des Nugets de l'application**" +
                                                         $"\n" +
                                                         $"- **Exemples d'implémentations** - 🚀" +
                                                         $"\n";

            public string WhyWeAreHere { get; set; } = $"# Liste des fonctionnalités présentées" +
                                                         $"\n" +
                                                         $"\n" + $"\n" +
                                                         $"### Xamarin.Forms" + $"\n" +
                                                         $"- **ObservableObject**" + $"\n" +
                                                         $"- **Commands**" + $"\n" +
                                                         $"- **Messenger**" + $"\n" +
                                                         $"- **Inversion of Control**" + $"\n" +
                                                         $"### UI" + $"\n" +
                                                         $"- **Common Controls**" + $"\n" +
                                                         $"- **Theming**" + $"\n" +
                                                         $"- **Sharpnado**" + $"\n" +
                                                         $"\n";
            private string name;

            /// <summary>
            /// Gets or sets the name to display.
            /// </summary>
            public string Name
            {
                get => name;
                set => SetProperty(ref name, value);
            }
    }
}
