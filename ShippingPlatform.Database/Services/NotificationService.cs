using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Database
{
    public class NotificationService
    {
        private NotificationRepository notificationRepository = new NotificationRepository();

        public Notification getOne(IDbConnection connection, int searchID)
        {
            return notificationRepository.Get(connection, searchID);
        }

        public IEnumerable<Notification> getAll(IDbConnection connection)
        {
            return notificationRepository.GetAll(connection);
        }

        public Notification Delete(IDbConnection connection, int searchID)
        {
            return notificationRepository.Delete(connection, searchID);
        }

        public Notification Insert(IDbConnection connection, Notification newNotification)
        {
            return notificationRepository.Insert(connection, newNotification);
        }

        public Notification Update(IDbConnection connection, int searchID, Notification newNotification)
        {
            return notificationRepository.Update(connection, searchID, newNotification);
        }

    }
}
