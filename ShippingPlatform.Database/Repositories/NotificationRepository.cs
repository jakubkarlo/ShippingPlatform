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
            return connection.Query<Notification>(
               "@SELECT * FROM notifications").FirstOrDefault();
            //return connection.Query<Notification,Order,Notification>(
            //@"SELECT * FROM notifications
            //INNER JOIN orders ON notifications.orderID = orders.orderID 
            //WHERE notificationID = @id",
            //(notification, order) =>
            //{
            //    notification.order = order;
            //    return notification;
            //},
            //new { id = searchId },null,false,"orderID").FirstOrDefault();
        }

        public IEnumerable<Notification> GetAll(IDbConnection connection)
        {
            return connection.Query<Notification>(
              "@SELECT * FROM notifications").ToList();
            //return connection.Query<Notification,Order,Notification>(
            //@"SELECT * FROM notifications
            //INNER JOIN orders ON notifications.orderID = orders.orderID" ,
            //(notification, order) =>
            //{
            //    notification.order = order;
            //    return notification;
            //},
            // splitOn:"orderID").ToList();
        }

        public Notification Delete(IDbConnection connection, int searchId)
        {
            return connection.Query<Notification>("DELETE FROM notifications WHERE notificationID = @id", new { id = searchId }).FirstOrDefault();
        }

        public Notification Insert(IDbConnection connection, Notification newNotification)
        {
            return connection.Query<Notification>("INSERT INTO notifications(clientEmail, recipientEmail, message, subject, timestamp, orderID, attachmentID) values(@clientEmail, @recipientEmail, @message, @subject, @timestamp, @orderID, @attachmentID)",
                new { clientEmail = newNotification.clientEmail, recipientEmail = newNotification.recipientEmail, message = newNotification.message, subject=newNotification.subject, timestamp=newNotification.timestamp, orderID = newNotification.orderID, attachmentID = newNotification.attachmentID }).FirstOrDefault();
        }


        public Notification Update(IDbConnection connection, int searchID, Notification newNotification)
        {
            return connection.Query<Notification>("UPDATE notifications SET clientEmail=@clientEmail, recipientEmail=@recipientEmail, message=@message, subject=@subject, timestamp=@timestamp, orderID=@orderID, attachmentID=@attachmentID WHERE notificationID =@id",
                new { id = searchID, clientEmail = newNotification.clientEmail, recipientEmail = newNotification.recipientEmail, message = newNotification.message, subject = newNotification.subject, timestamp = newNotification.timestamp, orderID = newNotification.orderID, attachmentID = newNotification.attachmentID }).FirstOrDefault();
        }

    }
}
