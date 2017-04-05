using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Database
{
    class NotificationRepository
    {
        public Notification Get(IDbConnection connection, int searchId)
        {
            return connection.Query<Notification,Order,Notification>(
            @"SELECT * FROM notifications
            INNER JOIN orders ON notifications.orderID = orders.orderID 
            WHERE notificationID = @id",
            (notification, order) =>
            {
                notification.order = order;
                return notification;
            },
            new { id = searchId },null,false,"orderID").FirstOrDefault();
        }

        public IEnumerable<Notification> GetAll(IDbConnection connection)
        {
            return connection.Query<Notification,Order,Notification>(
            @"SELECT * FROM notifications
            INNER JOIN orders ON notifications.orderID = orders.orderID" ,
            (notification, order) =>
            {
                notification.order = order;
                return notification;
            },
             splitOn:"orderID").ToList();
        }
    }
}
