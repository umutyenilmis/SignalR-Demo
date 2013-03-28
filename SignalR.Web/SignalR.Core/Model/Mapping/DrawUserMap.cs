using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalR.Core.Model.Domain;

namespace SignalR.Core.Model.Mapping
{
    public class DrawUserMap : EntityBaseMap<DrawUser>
    {
        public DrawUserMap()
        {
            Map(x => x.CallerId);
            Map(x => x.NickName);
            Map(x => x.LastCheckAt);
        }
    }
}
