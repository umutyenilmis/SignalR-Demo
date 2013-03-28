using FluentNHibernate.Mapping;
using SignalR.Core.Model.Domain;

namespace SignalR.Core.Model.Mapping
{
    public class EntityBaseMap<T> : ClassMap<T> where T : EntityBase
    {
        public EntityBaseMap()
        {
            Id(x => x.Id).GeneratedBy.GuidComb();
            Map(x => x.IsDeleted).Not.Nullable();
            Map(x => x.CreatedAt);
            ApplyFilter("DeletedFilter", "IsDeleted=0");
        }
    }
}