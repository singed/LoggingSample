using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using log4net;

namespace LoggingSample.Logger
{
    public class CoreLogger : ICoreLogger
    {
        private static readonly ILog Log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        public void Debug(object message)
        {
            Log.Debug(message);
        }

        public void Debug(object message, Exception exception)
        {
            Log.Debug(message, exception);
        }

        public void Info(object message)
        {
            Log.Info(message);
        }

        public void Info(object message, Exception exception)
        {
            Log.Info(message, exception);
        }

        public void Warn(object message)
        {
            Log.Warn(message);
        }

        public void Warn(object message, Exception exception)
        {
            Log.Warn(message, exception);
        }

        public void Error(object message)
        {
            Log.Error(message);
        }

        public void Error(object message, Exception exception)
        {
            Log.Error(message, exception);
        }

        public void Fatal(object message)
        {
            Log.Fatal(message);
        }

        public void Fatal(object message, Exception exception)
        {
            Log.Fatal(message, exception);
        }
    }
}