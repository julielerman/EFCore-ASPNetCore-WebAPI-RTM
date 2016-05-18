using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace EFLogging
{

    public class MyLoggerProvider2 : ILoggerProvider
    {
        public ILogger CreateLogger(string categoryName)
        {
            return new MyLogger();
        }

        public void Dispose()
        { }


        private class MyLogger : ILogger
        {

            public bool IsEnabled(LogLevel logLevel)
            {
                return true;
            }


            public void Log<TState>(
                  LogLevel logLevel,
                  EventId eventId,
                  TState state,
                  Exception exception,
                  Func<TState, Exception, string> formatter)
            {
                   Console.WriteLine("--------" + System.Environment.NewLine + formatter(state, exception));

            }


            public IDisposable BeginScope<TState>(TState state)
            {
                return null;
            }
        }
    }
}