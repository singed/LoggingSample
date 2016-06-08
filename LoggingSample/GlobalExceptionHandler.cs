using LoggingSample.Logger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http.ExceptionHandling;

namespace LoggingSample
{
    public class GlobalExceptionHandler : ExceptionHandler
    {
        private readonly ICoreLogger _logger;

        public GlobalExceptionHandler(ICoreLogger logger)
        {
            _logger = logger;
        }

        public override void Handle(ExceptionHandlerContext context)
        {
            var timer = ((Stopwatch)context.Request.Properties["logtimer"]);
            timer.Stop();

            var exception = context.Exception;
            var httpException = exception as HttpException;
            var logMessage = new LogMessage
            {
                RequestUri = context.Request.RequestUri.LocalPath,
                RequestMethod = context.Request.Method.Method,
                ElapsedMls = timer.ElapsedMilliseconds.ToString()
            };
            if (httpException != null)
            {
                context.Result = new ErrorResultMessage(context.Request,
                (HttpStatusCode)httpException.GetHttpCode(), httpException.Message);
                return;
            }

            logMessage.Message = exception.StackTrace;
            logMessage.StatusCode = (int)HttpStatusCode.InternalServerError;
            _logger.Error(logMessage.ToString());

            context.Result = new ErrorResultMessage(context.Request, HttpStatusCode.InternalServerError,
            exception.Message);
        }
    }
}