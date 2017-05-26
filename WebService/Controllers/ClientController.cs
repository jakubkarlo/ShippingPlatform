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
        private ClientService clientService;

        public ClientController()
        {
            db = new DatabaseService();
            clientService = new ClientService();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {        
            List<Client> allClients = (List<Client>)clientService.getAll(db.getConnection());
            return Ok(allClients);
        }

        [HttpGet]
        public IHttpActionResult getOne(int id)
        {
            Client specificClient = clientService.getOne(db.getConnection(), id);
            return Ok(specificClient);
        }


        [HttpDelete]
        public IHttpActionResult Delete([FromUri]int id)
        {
           Client clientToDelete = clientService.Delete(db.getConnection(), id);
            return Ok(clientToDelete);
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
