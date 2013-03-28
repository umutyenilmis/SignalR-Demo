using Castle.Windsor;
using Castle.Windsor.Installer;

namespace SignalR.Core.Infrastructure.IoC
{
    public class ServiceIoC
    {
        private static IWindsorContainer _container;

        public static IWindsorContainer Container
        {
            get
            {
                if (_container == null)
                {
                    _container = new WindsorContainer();
                    _container.Install(FromAssembly.This());
                }

                return _container;
            }
        }


    }
}
