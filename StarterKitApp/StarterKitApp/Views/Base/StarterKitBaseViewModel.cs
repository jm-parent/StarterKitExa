using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Ioc;
using MvvmHelpers;
using PropertyChanged;
using StarterKitApp.Helpers;
using StarterKitApp.Services.Interfaces;
using Xamarin.CommunityToolkit.ObjectModel;
using Xamarin.Forms;

namespace StarterKitApp.Views.Base
{
    [AddINotifyPropertyChangedInterface]
    public class StarterKitBaseViewModel : BaseViewModel
    {
    
        public ICommand NavBackCmd => new SafeCommand().Async(async () =>
        {
            await Shell.Current.GoToAsync("..", true);
        });

        public ICommand NavBackTwiceCmd => new SafeCommand().Async(async () =>
        {
            await Shell.Current.GoToAsync("../..", true);
        });

        public ICommand PopModelCmd => new SafeCommand().Async(async () =>
        {
            App.Current.MainPage.Navigation.PopModalAsync();
        });

        #region Gestion des MDs
 
        private IReadOnlyDictionary<string, string> texts;
        public IReadOnlyDictionary<string, string> Texts
        {
            get => texts;
            set => SetProperty(ref texts, value);
        }
        private string fullTexts;
        public string FullTexts
        {
            get => fullTexts;
            set => SetProperty(ref fullTexts, value);
        }
        private readonly IFilesService FilesServices = SimpleIoc.Default.GetInstance<IFilesService>();
        public string GetParagraph(string key)
        {
            return Texts != null && Texts.TryGetValue(key, out var value) ? value : string.Empty;
        }
        public ICommand LoadDocsCommand => new SafeCommand().Async(async (object name) =>
        {
            var filename = (string) name;
            var path = Path.Combine("Core", "Docs", $"{filename}.md");
            using var stream = await FilesServices.OpenForReadAsync(path);
            using var reader = new StreamReader(stream);
            var text = await reader.ReadToEndAsync();
            FullTexts = text;
            Texts = MarkdownHelper.GetParagraphs(text);
        });

        #endregion
    }
}
