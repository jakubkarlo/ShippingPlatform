using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.FluentMap;
using Dapper.FluentMap.Mapping;

namespace ShippingPlatform.Database
{
    class LogisticCenterMapper : EntityMap<LogisticCenter>
    {
        public LogisticCenterMapper()
        {
            Map(x => x.id).ToColumn("logisticCenterID");
            Map(x => x.name).ToColumn("name");
            Map(x => x.logisticCenterAddressID).ToColumn("addressID");
            Map(x => x.shippingRouteID).ToColumn("shippingRouteID");
        }
    }
}
