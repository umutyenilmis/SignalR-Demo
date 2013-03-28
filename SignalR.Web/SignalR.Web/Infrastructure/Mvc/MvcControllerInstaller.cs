using System.Web.Mvc;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace SignalR.Web.Infrastructure.Mvc
{
    public class MvcControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterControllers(container);
            RegisterControllerFactory(container);
        }

        private static void RegisterControllers(IWindsorContainer container)
        {
            var controllers = AllTypes
                .FromThisAssembly()
                .BasedOn<IController>()
                .Configure(x => x.LifeStyle.Transient.Named(x.Implementation.Name.ToLowerInvariant()));

            container.Register(controllers);

        }

        private static void RegisterControllerFactory(IWindsorContainer container)
        {
            var mvcControllerFactory = Component
                .For<IControllerFactory>()
                .ImplementedBy<WindsorControllerFactory>()
                .LifeStyle.Singleton;

            container.Register(mvcControllerFactory);
        }
    }
}