using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using log4net;
using log4net.Config;
using Microsoft.Owin;
using Microsoft.Practices.Unity;
using Owin;
using LoggingSample;

[assembly: OwinStartup(typeof(LoggingSample.Startup))]

namespace LoggingSample
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            // register log4net
            XmlConfigurator.Configure();



            // register routes 
            WebApiConfig.Register(config);

            // registering container 
            IUnityContainer container = UnityConfig.GetConfiguredContainer();
            config.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);

            // register filters
            config.RegisterFilters(container);

            // register global exception hanlder
            config.RegisterGlobalExceptionHandler(container);

            // configure log4net variables
            GlobalContext.Properties["processId"] = "LoggerSample";

            app.UseWebApi(config);

        }
    }
}
