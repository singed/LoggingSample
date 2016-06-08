using LoggingSample.Logger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Microsoft.Practices.Unity;

namespace LoggingSample.Filters
{
public class LogFilterAttribute : ActionFilterAttribute
{
    private string _elapsed;

    [Microsoft.Practices.Unity.Dependency]
    public ICoreLogger Logger { get; set; }

    public override void OnActionExecuting(HttpActionContext actionContext)
    {
        var timer = Stopwatch.StartNew();
        actionContext.Request.Properties["logtimer"] = timer;
    }

    /// <summary>
    ///     Occurs after the action method is invoked.
    /// </summary>
    /// <param name="actionExecutedContext">The action executed context.</param>
    public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
    {
        if (actionExecutedContext.Response != null)
        {
            var timer = ((Stopwatch)actionExecutedContext.Request.Properties["logtimer"]);
            timer.Stop();
            _elapsed = timer.ElapsedMilliseconds.ToString();
            var message = GetMessage(actionExecutedContext);
            Logger.Info(message);
        }
    }

    private string GetMessage(HttpActionExecutedContext actionExecutedContext)
    {
        return new LogMessage
        {
            StatusCode = (int)actionExecutedContext.Response.StatusCode,
            RequestMethod = actionExecutedContext.Request.Method.Method,
            RequestUri = actionExecutedContext.Request.RequestUri.LocalPath,
            Message = actionExecutedContext.Response.StatusCode.ToString(),
            ElapsedMls = _elapsed
        }.ToString();
    }
}
}