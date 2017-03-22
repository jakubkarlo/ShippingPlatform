using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Database
{
    class NotificationService
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
    }
}
