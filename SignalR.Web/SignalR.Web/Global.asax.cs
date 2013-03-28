using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;
using Castle.Windsor.Installer;
using SignalR.Core.Infrastructure.IoC;
using SignalR.Hubs;

namespace SignalR.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication, IContainerAccessor
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Site", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
            _container = CreateContainer();
            ControllerBuilder.Current.SetControllerFactory(_container.Resolve<IControllerFactory>());
        }

        private static IWindsorContainer _container;

        public IWindsorContainer Container
        {
            get { return _container; }
        }

        private static IWindsorContainer CreateContainer()
        {
            _container = ServiceIoC.Container;
            return
                _container
                    .Install(FromAssembly.This());
        }
    }
}