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
    public class RouteController : ApiController
    {
        private DatabaseService db;
        private RouteService routeService;

        public RouteController()
        {
            db = new DatabaseService();
            routeService = new RouteService();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<Route> allRoutes = (List<Route>)routeService.getAll(db.getConnection());
            return Ok(allRoutes);
        }

        [HttpGet]
        public IHttpActionResult getOne(int id)
        {
            Route specificRoute = routeService.getOne(db.getConnection(), id);
            return Ok(specificRoute);
        }


        [HttpDelete]
        public IHttpActionResult Delete([FromUri]int id)
        {
            try
            {
                Route routeToDelete = routeService.Delete(db.getConnection(), id);
                return Ok(routeToDelete);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Add([FromBody] Route route)
        {
            try
            {
                Route routeToAdd = routeService.Insert(db.getConnection(), route);
                return Ok(routeToAdd);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Route route, int id)
        {
            try
            {
                Route routeToUpdate = routeService.Update(db.getConnection(), id, route);
                return Ok(routeToUpdate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
