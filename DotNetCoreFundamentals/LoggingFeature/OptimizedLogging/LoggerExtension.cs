using Microsoft.Extensions.Logging;
using System;

namespace LoggingFeature.OptimizedLogging
{
    internal static class Events
    {
        public static readonly EventId Started = new EventId(2000, "Started");
        public static readonly EventId Ended = new EventId(2001, "Ended");
    }
    public static class LoggerExtension
    {

        private static readonly Action<ILogger, string, Exception> _pageRequestStarted = LoggerMessage.Define<string>(
            LogLevel.Critical,
            Events.Started,
            "High Performance Logger.Page Request Started.{Param1}");

        private static readonly Action<ILogger, string, Exception> _pageRequestEnded = LoggerMessage.Define<string>(
            LogLevel.Critical,
            Events.Ended,
            "High Performance Logger.Page Request Ended.{Param1}");



        public static void LogIndexPageRequestStarted(this ILogger logger, string param1)
        {
            _pageRequestStarted.Invoke(logger, param1, null);
        }

        public static void LogIndexPageRequestEnded(this ILogger logger, string param1)
        {
            _pageRequestEnded(logger, param1, null);
        }
    }
}
