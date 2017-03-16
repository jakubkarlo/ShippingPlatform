﻿using Dapper.FluentMap.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Database
{
    public class RouteMapper : EntityMap<Route>
    {
        public RouteMapper()
        {
            Map(x => x.id).ToColumn("routeID");
            //int or Address?
            Map(x => x.startAddress).ToColumn("startAddressID");
            Map(x => x.endAddress).ToColumn("endAddressID");

            Map(x => x.startTime).ToColumn("startTime");
            Map(x => x.endTime).ToColumn("endTime");
        }
    }
}
