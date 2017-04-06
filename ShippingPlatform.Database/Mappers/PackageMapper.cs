using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FluentMap.Mapping;

namespace ShippingPlatform.Database
{
    public class PackageMapper : EntityMap<Package>
    {
        public PackageMapper()
        {
            Map(x => x.id).ToColumn("packageID");
            Map(x => x.height).ToColumn("height");
            Map(x => x.width).ToColumn("width");
            Map(x => x.depth).ToColumn("depth");
            Map(x => x.weight).ToColumn("weight");
            Map(x => x.content).ToColumn("content");
            Map(x => x.orderID).ToColumn("orderID");
        }
    }
}
