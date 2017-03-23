using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Database
{
    class PackageRepository
    {
        public Package Get(IDbConnection connection, int searchId)
        {
            return connection.Query<Package>(
            "SELECT * FROM packages WHERE packageID = @id",
            new { id = searchId }).FirstOrDefault();
        }

        public IEnumerable<Package> GetAll(IDbConnection connection)
        {
            return connection.Query<Package>(
            "SELECT * FROM packages").ToList();
        }
    }
}
