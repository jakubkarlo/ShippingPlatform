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
    class OrderMapper : EntityMap<Order>
    {
        public OrderMapper()
        {
            Map(x => x.id).ToColumn("orderID");
            Map(x => x.recipientAddress).ToColumn("recipientAddressID");
            Map(x => x.clientAddress).ToColumn("clientAddressID");
            Map(x => x.referenceNumber).ToColumn("referenceNumber");
            Map(x => x.createdDate).ToColumn("createdDate");
            Map(x => x.pickupDate).ToColumn("pickupDate");
            Map(x => x.deliveryDate).ToColumn("deliveryDate");
            Map(x => x.status).ToColumn("status");
        }
    }
}
