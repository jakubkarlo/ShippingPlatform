using ShippingPlatform;
using ShippingPlatform.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebService.Controllers
{
    public class NotificationController : ApiController
    {
        private DatabaseService db;
        private NotificationService notificationService;

        public NotificationController()
        {
            db = new DatabaseService();
            notificationService = new NotificationService();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<Notification> allNotifications = (List<Notification>)notificationService.getAll(db.getConnection());
            return Ok(allNotifications);
        }

        [HttpGet]
        public IHttpActionResult getOne(int id)
        {
            Notification specificNotification = notificationService.getOne(db.getConnection(), id);
            return Ok(specificNotification);
        }


        [HttpDelete]
        public IHttpActionResult Delete([FromUri]int id)
        {
            try
            {
                Notification NotificationToDelete = notificationService.Delete(db.getConnection(), id);
                return Ok(NotificationToDelete);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Add([FromBody] Notification notification)
        {
            try
            {
                Notification notificationToAdd = notificationService.Insert(db.getConnection(), notification);
                return Ok(notificationToAdd);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Notification notification, int id)
        {
            try
            {
                Notification notificationToUpdate = notificationService.Update(db.getConnection(), id, notification);
                return Ok(notificationToUpdate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
