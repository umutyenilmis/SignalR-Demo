using Castle.Core;
using Castle.DynamicProxy;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using SignalR.Core.Infrastructure.Extenstions;
using SignalR.Core.Infrastructure.Interceptors;
using SignalR.Core.Service.DefaultServices.Interfaces;

namespace SignalR.Core.Infrastructure.Installers
{
    public class ServiceInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container
                .Register(AllTypes.FromAssemblyContaining<IService>()
                              .BasedOn<IService>()
                              .WithService.FirstInterfaceOnClass()
                              .Configure(c => c.LifeStyle.Singleton)
                              .Configure(c => c.Interceptors(InterceptorReference.ForType<ServiceInterceptor>()).First),
                          AllTypes.FromAssemblyContaining<IService>().BasedOn<IInterceptor>()
                );
        }
    }
}