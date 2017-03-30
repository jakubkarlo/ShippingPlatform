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

        //public void Insert(IDbConnection connection, string country, string city, string zipcode, string street, int housenumber)
        //{
        //    using (SqlCommand cmd = new SqlCommand(@"INSERT INTO `shippingplatform`.`addresses` (`country`, `city`, `zipcode`, `street`, `housenumber`) 
        //        VALUES(country, city, zipcode, street, housenumber)"))
        //    {
        //        cmd.Parameters.AddWithValue("@country", country);
        //        cmd.Parameters.AddWithValue("@city", city);
        //        cmd.Parameters.AddWithValue("@zipcode", zipcode);
        //        cmd.Parameters.AddWithValue("@street", street);
        //        cmd.Parameters.AddWithValue("@housenumber", housenumber);
        //        cmd.ExecuteNonQuery();

        //    }
        //   ;

        //}

    }
}
