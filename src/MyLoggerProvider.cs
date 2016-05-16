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

            public void Log(LogLevel logLevel, int eventId, object state, Exception exception, Func<object, Exception, string> formatter)
            {
               // File.AppendAllText(@"C:\temp\log.txt", formatter(state, exception));
                Console.WriteLine("--------"+ System.Environment.NewLine+formatter(state, exception));
            }
      public void Log<TState>(
            LogLevel logLevel,
            EventId eventId,
            TState state,
            Exception exception,
            Func<TState, Exception, string> formatter)
        {
            Log(logLevel, eventId, state, exception, formatter);
        }

            public IDisposable BeginScopeImpl(object state)
            {
                return null;
            }
              public IDisposable BeginScope<TState>(TState state)
        {
            return BeginScope(state);
        }
        } 
    }
}