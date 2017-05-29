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
    public class PackageController : ApiController
    {
        private DatabaseService db;
        private PackageService packageService;

        public PackageController()
        {
            db = new DatabaseService();
            packageService = new PackageService();
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            List<Package> allPackages = (List<Package>)packageService.getAll(db.getConnection());
            return Ok(allPackages);
        }

        [HttpGet]
        public IHttpActionResult getOne(int id)
        {
            Package specificPackage = packageService.getOne(db.getConnection(), id);
            return Ok(specificPackage);
        }


        [HttpDelete]
        public IHttpActionResult Delete([FromUri]int id)
        {
            try
            {
                Package packageToDelete = packageService.Delete(db.getConnection(), id);
                return Ok(packageToDelete);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Add([FromBody] Package package)
        {
            try
            {
                Package packageToAdd = packageService.Insert(db.getConnection(), package);
                return Ok(packageToAdd);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Update([FromBody] Package package, int id)
        {
            try
            {
                Package packageToUpdate = packageService.Update(db.getConnection(), id, package);
                return Ok(packageToUpdate);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
