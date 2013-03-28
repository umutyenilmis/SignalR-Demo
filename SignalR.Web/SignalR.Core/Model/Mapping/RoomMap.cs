using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.Core.Model.Domain;

namespace SignalR.Core.Model.Mapping
{
    public class RoomMap : EntityBaseMap<Room>
    {
        public RoomMap()
        {
            References(x => x.FirstUser).Column("DrawUser");
            References(x => x.SecondUser).Column("DrawUser");
        }
    }
}
