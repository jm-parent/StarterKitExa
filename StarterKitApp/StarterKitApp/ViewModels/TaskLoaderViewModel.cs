using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Sharpnado.Presentation.Forms;
using StarterKitApp.Services;
using StarterKitApp.Views.Base;
using Xamarin.Forms;

namespace StarterKitApp.ViewModels
{

    public class TaskLoaderViewModel : StarterKitBaseViewModel
    {
        public CompositeTaskLoaderNotifier CompositeNotifier { get; }
        public TaskLoaderViewModel()
        {
            Loader = new TaskLoaderNotifier();

            BuyGameCommand = new TaskLoaderCommand(BuyGame);
            PlayTheGameCommand = new TaskLoaderCommand(PlayTheGame);

            CompositeNotifier = new CompositeTaskLoaderNotifier(
                BuyGameCommand.Notifier,
                PlayTheGameCommand.Notifier);
            Loader.PropertyChanged += Loader_PropertyChanged;
        }

        private void Loader_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            var r = (TaskLoaderNotifier) sender;
        }

        public string LoadingText { get; set; }
        public TaskLoaderNotifier Loader { get; }
        public TaskLoaderCommand BuyGameCommand { get; }

        public TaskLoaderCommand PlayTheGameCommand { get; }

        private async Task BuyGame()
        {
            LoadingText = "Proceeding to payment";

            await Task.Delay(2000);
            throw new LocalizedException($"Sorry, we only accept DogeCoin...{Environment.NewLine}BTW GameStop are still opened");
        }

        private async Task PlayTheGame()
        {
            LoadingText = "Loading the game...";

            await Task.Delay(2000);
            throw new LocalizedException("AHAHAHA! Yeah right...");
        }
    }
}
