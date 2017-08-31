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
            try
            {
                Client clientToDelete = clientService.Delete(db.getConnection(), id);
                return Ok(clientToDelete);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Add([FromBody] Client client)
        {
            try
            {
                Client clientToAdd = clientService.Insert(db.getConnection(), client);
                return Ok(clientToAdd);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Client client, int id)
        {
            try
            {
                Client clientToUpdate = clientService.Update(db.getConnection(), id, client);
                return Ok(clientToUpdate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
