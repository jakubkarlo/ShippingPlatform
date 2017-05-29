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
    public class OrderController : ApiController
    {

        private DatabaseService db;
        private OrderService orderService;

        public OrderController()
        {
            db = new DatabaseService();
            orderService = new OrderService();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<Order> allOrders = (List<Order>)orderService.getAll(db.getConnection());
            return Ok(allOrders);
        }

        [HttpGet]
        public IHttpActionResult getOne(int id)
        {
            Order specificOrder = orderService.getOne(db.getConnection(), id);
            return Ok(specificOrder);
        }


        [HttpDelete]
        public IHttpActionResult Delete([FromUri]int id)
        {
            try
            {
                Order orderToDelete = orderService.Delete(db.getConnection(), id);
                return Ok(orderToDelete);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Add([FromBody] Order order)
        {
            try
            {
                Order orderToAdd = orderService.Insert(db.getConnection(), order);
                return Ok(orderToAdd);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Order order, int id)
        {
            try
            {
                Order orderToUpdate = orderService.Update(db.getConnection(), id, order);
                return Ok(orderToUpdate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
