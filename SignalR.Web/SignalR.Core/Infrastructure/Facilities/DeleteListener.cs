using NHibernate.Engine;
using NHibernate.Event;
using NHibernate.Event.Default;
using SignalR.Core.Model.Domain;

namespace SignalR.Core.Infrastructure.Facilities
{
    internal class DeleteListener : DefaultDeleteEventListener
    {
        protected override void DeleteEntity(IEventSource session, object entity, EntityEntry entityEntry, bool isCascadeDeleteEnabled, NHibernate.Persister.Entity.IEntityPersister persister, Iesi.Collections.ISet transientEntities)
        {
            var entityBase = entity as EntityBase;
            if (entityBase != null)
                entityBase.IsDeleted = true;
        }
    }
}