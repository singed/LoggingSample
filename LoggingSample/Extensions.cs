using LoggingSample.Filters;
using LoggingSample.Logger;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.ExceptionHandling;
using System.Web.Http.Filters;

namespace LoggingSample
{
    public static class Extensions
    {
        public static void RegisterFilters(this HttpConfiguration config, IUnityContainer container)
        {
            var providers = config.Services.GetFilterProviders().ToList();
            var defaultprovider = providers.Single(i => i is ActionDescriptorFilterProvider);
            config.Services.Remove(typeof(IFilterProvider), defaultprovider);
            config.Services.Add(typeof(IFilterProvider), new UnityFilterProvider(container));
        }

        public static void RegisterGlobalExceptionHandler(this HttpConfiguration config, IUnityContainer container)
        {
            config.Services.Replace(typeof(IExceptionHandler), new GlobalExceptionHandler(container.Resolve<ICoreLogger>()));
        }
    }
}