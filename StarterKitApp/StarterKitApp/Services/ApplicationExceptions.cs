using System;
using System.Collections.Generic;
using System.Text;

namespace StarterKitApp.Services
{
    public static class ApplicationExceptions
    {
        public static string ToString(Exception exception)
        {
            switch (exception)
            {
                case LocalizedException localizedException:
                    return localizedException.Message;
                case AggregateException aggregateException:
                    return ToString(aggregateException.InnerExceptions[0]);
                default:
                    return "Error_Unknown";
            }
        }
    }

    public class ServerException : Exception
    {
    }

    public class NetworkException : Exception
    {
    }

    public class LocalizedException : Exception
    {
        public LocalizedException(string message)
            : base(message)
        {
        }
    }
}
