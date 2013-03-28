using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace SignalR.Core.Infrastructure.Installers
{
    public class LoggerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            //TODO:log4net.config oluþurulacak
            ////container.AddFacility<LoggingFacility>(l => l.LogUsing(LoggerImplementation.Log4net )
            //                                                .WithConfig("Config/log4net.config")); 

        }
    }
}