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
    public class LogisticCenterController : ApiController
    {

        private DatabaseService db;
        private LogisticCenterService LogisticCenterService;

        public LogisticCenterController()
        {
            db = new DatabaseService();
            LogisticCenterService = new LogisticCenterService();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<LogisticCenter> allCenters = (List<LogisticCenter>)LogisticCenterService.getAll(db.getConnection());
            return Ok(allCenters);
        }

        [HttpGet]
        public IHttpActionResult getOne(int id)
        {
            LogisticCenter specificLogisticCenter = LogisticCenterService.getOne(db.getConnection(), id);
            return Ok(specificLogisticCenter);
        }

        //public IHttpActionResult search(string searchTerm)
        //{
        //    List<LogisticCenter> searchResult = LogisticCenterService.Search(searchTerm);
        //    return Ok(searchResult);
        //}

        [HttpDelete]
        public IHttpActionResult delete([FromUri]int id)
        {
            return NotFound();
        }

        [HttpPost]
        public IHttpActionResult Save([FromBody]LogisticCenter LogisticCenter) // we want to add it from body json object
        {
            try
            {
                // do some stuff here
                //new LogisticCenterService.Save(LogisticCenter);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
