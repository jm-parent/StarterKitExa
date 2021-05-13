using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StarterKitApp.Helpers
{
    public static class PopUpHelper
    {
        public static async Task ShowPopup(string svg, string title, string message, string confirmingText = "Ok",
            Action ifConfirmed = null, string dismissiveText = null, Action ifDismissed = null, Action ifPopupDismissed = null)
        {
            // Parameters verifications

            if (string.IsNullOrWhiteSpace(title)
                && string.IsNullOrWhiteSpace(svg)
                && string.IsNullOrWhiteSpace(message))
            {
                return;
            }

            if (ifConfirmed == null)
                ifConfirmed = EmptyAction;

            if (ifDismissed == null)
                ifDismissed = EmptyAction;

            if (ifPopupDismissed == null)
                ifPopupDismissed = EmptyAction;

            //Todo implémenter l'affichage d'une popup avec actions

            //var alertDialogConfiguration = new MaterialAlertDialogConfiguration()
            //{
            //    TitleTextColor = Color.Black,
            //    TintColor = Color.OrangeRed,
            //    CornerRadius = 15,
            //    ButtonAllCaps = false,
            //};
            //var resultat = await MaterialDialog.Instance.ShowCustomContentAsync(new PopupPictoView(title, message, svg), null,
            //        null, confirmingText, dismissiveText, alertDialogConfiguration);
            //switch (resultat)
            //{
            //    case true:
            //        ifConfirmed();
            //        break;
            //    case false:
            //        ifDismissed();
            //        break;
            //    case null:
            //        ifPopupDismissed();
            //        break;
            //}
            async void EmptyAction()
            {
            }
        }
        //public static async Task ShowWarning(string title, string message = null, string confirmingText = "Ok",
        //    Action ifConfirmed = null, string dismissiveText = null, Action ifDismissed = null, Action ifPopupDismissed = null)
        //{
        //    await ShowPopup(SvgNames.WarningCircle, title, message, confirmingText, ifConfirmed, dismissiveText, ifDismissed, ifPopupDismissed);
        //}
        //public static async Task ShowSuccess(string title, string message = null, string confirmingText = "Ok",
        //    Action ifConfirmed = null, string dismissiveText = null, Action ifDismissed = null, Action ifPopupDismissed = null)
        //{
        //    await ShowPopup(SvgNames.CheckCircle, title, message, confirmingText, ifConfirmed, dismissiveText, ifDismissed, ifPopupDismissed);
        //}
        //public static async Task ShowError(string title, string message = null, string confirmingText = "Ok",
        //    Action ifConfirmed = null, string dismissiveText = null, Action ifDismissed = null, Action ifPopupDismissed = null)
        //{
        //    await ShowPopup(SvgNames.CrossRed, title, message, confirmingText, ifConfirmed, dismissiveText, ifDismissed, ifPopupDismissed);
        //}
        //public static async Task LoadingPopup(string title, string message = null, string confirmingText = "Ok",
        //    Action ifConfirmed = null, string dismissiveText = null, Action ifDismissed = null, Action ifPopupDismissed = null)
        //{
        //    await ShowPopup(SvgNames.ClockIcon, title, message, confirmingText, ifConfirmed, dismissiveText, ifDismissed, ifPopupDismissed);
        //}
        //public static async Task ShowAgendaInitError(string svg, string title, string message, string confirmingText, Action ifConfirmed)
        //{
        //    await ShowPopup(SvgNames.CrossRed, title, message, confirmingText, ifConfirmed);
        //}
        //public static async Task DynamicFormErrorPopup(string svg, string title, string message)
        //{
        //    await ShowPopup(SvgNames.CrossRed, title, message);
        //}

    }
}
