using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Core.Model.Domain
{
    public class DrawUser : EntityBase
    {
        public virtual string CallerId { get; set; }
        public virtual string NickName { get; set; }
        public virtual DateTime LastCheckAt { get; set; }
    }
}
