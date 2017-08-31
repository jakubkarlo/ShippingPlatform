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
        private LogisticCenterService logisticCenterService;

        public LogisticCenterController()
        {
            db = new DatabaseService();
            logisticCenterService = new LogisticCenterService();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<LogisticCenter> allCenters = (List<LogisticCenter>)logisticCenterService.getAll(db.getConnection());
            return Ok(allCenters);
        }

        [HttpGet]
        public IHttpActionResult getOne(int id)
        {
            LogisticCenter specificLogisticCenter = logisticCenterService.getOne(db.getConnection(), id);
            return Ok(specificLogisticCenter);
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromUri]int id)
        {
            try
            {
                LogisticCenter logisticCenterToDelete = logisticCenterService.Delete(db.getConnection(), id);
                return Ok(logisticCenterToDelete);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Add([FromBody] LogisticCenter logisticCenter)
        {
            try
            {
                LogisticCenter logisticCenterToAdd = logisticCenterService.Insert(db.getConnection(), logisticCenter);
                return Ok(logisticCenterToAdd);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] LogisticCenter logisticCenter, int id)
        {
            try
            {
                LogisticCenter logisticCenterToUpdate = logisticCenterService.Update(db.getConnection(), id, logisticCenter);
                return Ok(logisticCenterToUpdate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        
        }
    }
}
