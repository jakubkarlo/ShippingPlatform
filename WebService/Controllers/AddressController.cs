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
    public class AddressController : ApiController
    {

        private DatabaseService db;
        private AddressService addressService;

        public AddressController()
        {
            db = new DatabaseService();
            addressService = new AddressService();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {        
            List<Address> allClients = (List<Address>)addressService.getAll(db.getConnection());
            return Ok(allClients);
        }

        [HttpGet]
        public IHttpActionResult getOne(int id)
        {
            Address specificAddress = addressService.getOne(db.getConnection(), id);
            return Ok(specificAddress);
        }

        //public IHttpActionResult search(string searchTerm)
        //{
        //    List<Address> searchResult = addressService.Search(searchTerm);
        //    return Ok(searchResult);
        //}

        [HttpDelete]
        public IHttpActionResult delete([FromUri]int id)
        {
            return NotFound();
        }

        [HttpPost]
        public IHttpActionResult Save([FromBody]Address address) // we want to add it from body json object
        {
            try {
                // do some stuff here
                //new AddressService.Save(address);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
    }
}
