using System;
using System.Collections.Generic;
using System.Text;
using GalaSoft.MvvmLight.Ioc;
using StarterKitApp.Services;
using StarterKitApp.Services.Interfaces;
using StarterKitApp.ViewModels;

namespace StarterKitApp.ModelLocator
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            //Viewmodels
            SimpleIoc.Default.Register<RedditViewModel>();
            SimpleIoc.Default.Register<PopupsViewModel>();
            SimpleIoc.Default.Register<TutoCreateANewPageViewModel>();

            //Services
            SimpleIoc.Default.Register<ISettingsService, SettingsService>();
            SimpleIoc.Default.Register<IFilesService, FileService>();
        }

        /// <summary>
        /// GetInstance
        /// or
        /// GetInstanceWithoutCaching
        /// </summary>

        public object Reddit => SimpleIoc.Default.GetInstance<RedditViewModel>();
        public object Popups => SimpleIoc.Default.GetInstance<PopupsViewModel>();
        public object TutoCreatePage => SimpleIoc.Default.GetInstance<TutoCreateANewPageViewModel>();
    }

}
