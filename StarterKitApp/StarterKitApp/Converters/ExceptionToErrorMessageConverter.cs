using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using StarterKitApp.Services;
using Xamarin.Forms;

namespace StarterKitApp.Converters
{
    public class ExceptionToErrorMessageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var exception = value as Exception;

            return value == null ? null : ApplicationExceptions.ToString(exception);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // One-Way converter only
            throw new NotImplementedException();
        }
    }
}
