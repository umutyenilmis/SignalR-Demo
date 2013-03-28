using NHibernate;
using SignalR.Core.Infrastructure.IoC;

namespace SignalR.Core.Infrastructure.UoW
{
    public class UnitOfWork
    {
        internal static ISession CurrentSession
        {
            get
            {
                var container = ServiceIoC.Container;
                return container.Resolve<ISession>();
            }
        }

    }
}