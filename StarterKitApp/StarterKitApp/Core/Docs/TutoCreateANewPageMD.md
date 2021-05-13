# TutoCreateNewPage

Un tutoriel de création d'une nouvelle page dans le starterkit

# Etape 1 : Création d'une ContentPage

Dans un premier temps , créez une nouvelle ContentPage dans le 📂 **Views .**

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://xamarin.com/schemas/2014/forms"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             x:Class="StarterKitApp.Views.TutoCreateANewPageView">
    <ContentPage.Content>
        <StackLayout>
            <Label Text="Bienvenue sur TutoCreateNewPage"
                VerticalOptions="CenterAndExpand" 
                HorizontalOptions="CenterAndExpand" />
        </StackLayout>
    </ContentPage.Content>
</ContentPage>
```

# Etape 2 : Création du ViewModel

Après la View , il faut créer le fichier ViewModel dans le 📂 **ViewModels .**

```csharp
using StarterKitApp.Views.Base;

namespace StarterKitApp.ViewModels
{
    public class TutoCreateANewPageViewModel : MyBaseViewModel
    {
    }
}
```

---

# Etape 3 : Créer la liaison entre View & ViewModel

Dans cette étape il y a plusieurs sous étapes à faire 

- Enregistrement du ViewModel sur l'IoC
- Binding du ViewModel sur la View

### a. Enregistrement du ViewModel

Dans le fichier **ViewModelLocator.cs :**

- Ajouter la ligne d'enregistrement :

```csharp
SimpleIoc.Default.Register<TutoCreateANewPageViewModel>();
```

- Créer le propriété de création/d'appel de l'instance

```csharp
public object TutoCreatePage => SimpleIoc.Default.GetInstance<TutoCreateANewPageViewModel>();
```

### b. Liaison du ViewModel avec la View

Dans le code behind de la View , on ajoute dans le constructeur la ligne d'affectation du BindingContext.

```csharp
public partial class TutoCreateANewPageView : ContentPage
    {
        public TutoCreateANewPageView()
        {
            InitializeComponent();
            **BindingContext = App.Locator.TutoCreatePage;**
        }
    }
```

# Etape 4 : On ajoute la page au Shell

Après avoir créé les différents fichiers et créé les liaisons nécessaires au bon fonctionnement.

Il ne reste plus qu'à ajouter cette page à notre Flyout

Dans le fichier **AppShell.xaml** 

```xml
<ShellContent Title="Create a new Page"
                  ContentTemplate="{DataTemplate views:TutoCreateANewPageView}">
        <ShellContent.Icon>
            <FontImageSource FontFamily="MaterialIconsFont" Glyph="{x:Static IconsFontHelper:IconsFontHelpers.Creation}" />
        </ShellContent.Icon>
</ShellContent>
```

# Félicitation