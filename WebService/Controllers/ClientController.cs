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
    public class ClientController : ApiController
    {

        private DatabaseService db;
        private ClientService ClientService;

        public ClientController()
        {
            db = new DatabaseService();
            ClientService = new ClientService();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {        
            List<Client> allClients = (List<Client>)ClientService.getAll(db.getConnection());
            return Ok(allClients);
        }

        [HttpGet]
        public IHttpActionResult getOne(int id)
        {
            Client specificClient = ClientService.getOne(db.getConnection(), id);
            return Ok(specificClient);
        }

        //public IHttpActionResult search(string searchTerm)
        //{
        //    List<Client> searchResult = ClientService.Search(searchTerm);
        //    return Ok(searchResult);
        //}

        [HttpDelete]
        public IHttpActionResult delete([FromUri]int id)
        {
            return NotFound();
        }

        [HttpPost]
        public IHttpActionResult Save([FromBody]Client Client) // we want to add it from body json object
        {
            try {
                // do some stuff here
                //new ClientService.Save(Client);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
