using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Database
{
    public class AddressRepository
    {
        public Address Get(IDbConnection connection, int searchId)
        {
            return connection.Query<Address>(
            "SELECT * FROM addresses WHERE addressID = @id",
            new { id = searchId }).FirstOrDefault();
        }

        public IEnumerable<Address> GetAll(IDbConnection connection)
        {
            return connection.Query<Address>(
            "SELECT * FROM addresses").ToList();
        }

        public Address Delete(IDbConnection connection, int searchId)
        {
            return connection.Query<Address>("DELETE FROM addresses WHERE addressID = @id", new { id = searchId }).FirstOrDefault(); 
        }

        public Address Insert(IDbConnection connection, Address newAddress)
        {
            return connection.Query<Address>("INSERT INTO addresses(country, city, zipcode, street, housenumber) values(@country, @city, @zipcode, @street, @housenumber)",
                new { country = newAddress.country, city = newAddress.city, zipcode = newAddress.zipcode, street = newAddress.street, housenumber = newAddress.housenumber }).FirstOrDefault();

        }


        public Address Update(IDbConnection connection, int searchID, Address newAddress) {

            return connection.Query<Address>("UPDATE addresses SET country=@country, city=@city,zipcode=@zipcode,street=@street,housenumber=@housenumber WHERE addressID=@id",
                new { id = searchID, country = newAddress.country, city = newAddress.city, zipcode = newAddress.zipcode, street = newAddress.street, housenumber = newAddress.housenumber }).FirstOrDefault();

        }


    }
}
