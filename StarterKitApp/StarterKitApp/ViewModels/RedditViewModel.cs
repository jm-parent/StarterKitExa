using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using StarterKitApp.Helpers;
using StarterKitApp.Services;
using StarterKitApp.Services.Interfaces;
using StarterKitApp.Views.Base;
using Xamarin.CommunityToolkit.ObjectModel;

namespace StarterKitApp.ViewModels
{
    public class RedditViewModel : MyBaseViewModel
    {
        private readonly ISettingsService _service;

        public RedditViewModel(ISettingsService service)
        {
            _service = service;
            _service.SetValue("Test","Saved Value");
            var e = _service.GetValue<string>("Test");
        }
        private string _title;

        public string Title
        {
            get => _title;
            set => _title = value;
        }
      
    }
}
