using NHibernate;

namespace SignalR.Core.Infrastructure.Facilities
{
    public class EnableFiltersInterceptor : EmptyInterceptor
    {
        public override void SetSession(ISession session)
        {
            session.EnableFilter("DeletedFilter").SetParameter("IsDeleted", false);
        }

    }
}