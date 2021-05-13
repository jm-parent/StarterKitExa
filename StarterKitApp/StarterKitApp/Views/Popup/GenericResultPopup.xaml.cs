﻿using Xamarin.Forms.Xaml;
using Xamarin.CommunityToolkit.UI.Views;

namespace StarterKitApp.Views.Popup
{
    public partial class GenericResultPopup : Popup<GenericResultPopup.Result>
    {
        public GenericResultPopup()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, System.EventArgs e)
        {
            var result = new Result
            {
                Title = "Type Constraint Popup Response",
                Message = "Hello from a typed popup!",
                Ok = "OK"
            };
            Dismiss(result);
        }
        protected override Result GetLightDismissResult()
        {
            return new Result
            {
                Title = "Type Constraint Popup Response",
                Message = "Popup was light dismissed!",
                Ok = "OK"
            };
        }

        public class Result
        {
            public string Title { get; set; }
            public string Message { get; set; }
            public string Ok { get; set; }
        }
    }
}