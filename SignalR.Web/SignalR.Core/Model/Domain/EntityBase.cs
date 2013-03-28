using System;

namespace SignalR.Core.Model.Domain
{
    public class EntityBase
    {
        public virtual Guid Id { get; set; }
        public virtual DateTime CreatedAt { get; set; }
        public virtual bool IsDeleted { get; set; }
        
    }
}