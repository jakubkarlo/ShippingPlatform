

using ShippingPlatform;
using ShippingPlatform.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.UI;

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
            try {
                List<Address> allClients = (List<Address>)addressService.getAll(db.getConnection());
                return Ok(allClients);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IHttpActionResult GetOne(int id)
        {
            try
            {
                Address specificAddress = addressService.getOne(db.getConnection(), id);
                return Ok(specificAddress);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        [HttpDelete]
        public IHttpActionResult Delete([FromUri]int id)
        {
            try
            {
                Address addressToDelete = addressService.Delete(db.getConnection(), id);
                return Ok(addressToDelete);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Add([FromBody] Address address)
        {
            try
            {
                Address addressToAdd = addressService.Insert(db.getConnection(), address);
                return Ok(addressToAdd);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Address address, int id)
        {
            try {
                Address addressToUpdate = addressService.Update(db.getConnection(), id, address);
                return Ok(addressToUpdate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


     
    }
}
