using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.Core.Model.Domain
{
    public class Room : EntityBase
    {
        public virtual DrawUser FirstUser { get; set; }
        public virtual DrawUser SecondUser { get; set; }
    }
}
