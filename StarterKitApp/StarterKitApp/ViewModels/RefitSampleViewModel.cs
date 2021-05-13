using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Windows.Input;
using Newtonsoft.Json;
using StarterKitApp.Helpers;
using StarterKitApp.Models;
using StarterKitApp.Services;
using StarterKitApp.Services.Interfaces;
using StarterKitApp.Views.Base;
using Xamarin.CommunityToolkit.ObjectModel;

namespace StarterKitApp.ViewModels
{
    public class RefitSampleViewModel : StarterKitBaseViewModel
    {
        private string _baseApiUrl = "https://jsonplaceholder.typicode.com";
        private readonly JsonPlaceholderClient _restClient;

        public RefitSampleViewModel()
        {
            _restClient = new JsonPlaceholderClient();
        }

        public ICommand CallApiGetStringPost => new SafeCommand().Async(async () =>
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_baseApiUrl);

                var fooString = await client.GetStringAsync("posts");
                var fooCollection = JsonConvert.DeserializeObject<Foo[]>(fooString);

                ResultLabel = $"{fooCollection[0].id} - {fooCollection[0].title}";
            }
        });

        public string ResultLabel { get; set; }
       
    }
}
