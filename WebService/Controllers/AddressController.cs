

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
            List<Address> allClients = (List<Address>)addressService.getAll(db.getConnection());
            return Ok(allClients);
        }

        [HttpGet]
        public IHttpActionResult GetOne(int id)
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
        public IHttpActionResult Delete([FromUri]int id)
        {
            Address addressToDelete = addressService.Delete(db.getConnection(), id);
            return Ok(addressToDelete);
        }

        [HttpPut]
        public IHttpActionResult Add()
        {
            //ClientScriptManager.RegisterClientScriptBlock(typeof(Page), "ClientScript", "<script> alert('Inserted successfully');</script>", true);
            Address a1 = new Address();
            a1.country = "Korea";
            a1.city = "HSeoul";
            a1.zipcode = "345325";
            a1.street = "chanukunho";
            a1.housenumber = 12;
            Address addressToAdd = addressService.Insert(db.getConnection(), a1);
            return Ok(addressToAdd);
        }

        [HttpPut]
        public IHttpActionResult Update([FromUri]int id)
        {

            Address a1 = new Address();
            a1.country = "Korea";
            a1.city = "HSeoul";
            a1.zipcode = "345325";
            a1.street = "chanusfsrfsrfseunho";
            a1.housenumber = 12;
            Address addressToUpdate = addressService.Update(db.getConnection(), id, a1);
            return Ok(addressToUpdate);
        }


     
    }
}
