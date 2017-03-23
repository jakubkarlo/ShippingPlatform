using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper.FluentMap;
using Dapper.FluentMap.Mapping;

namespace ShippingPlatform.Database
{
    public class NotificationMapper : EntityMap<Notification>
    {
        public NotificationMapper()
        {
            Map(x => x.id).ToColumn("notificationID");
            Map(x => x.clientEmail).ToColumn("clientEmail");
            Map(x => x.recipientEmail).ToColumn("recipientEmail");
            Map(x => x.message).ToColumn("message");
            Map(x => x.subject).ToColumn("subject");
            Map(x => x.timestamp).ToColumn("timestamp");
            Map(x => x.orderID).ToColumn("orderID");
            Map(x => x.attachmentID).ToColumn("attachmentID");
        }
    }
}
