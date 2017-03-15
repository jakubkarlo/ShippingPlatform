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
    public class DatabaseService
    {
        public Address Get(IDbConnection connection, int searchId)
        {
            return connection.Query<Address>(
            "SELECT * FROM product WHERE id = @id",
            new { id = searchId }).FirstOrDefault();
        }

        public IEnumerable<Address> GetAll(IDbConnection connection)
        {
            return connection.Query<Address>(
            "SELECT * FROM product").ToList();
        }
    }
}
