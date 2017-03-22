using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Database
{
    class RouteRepository
    {
        public Route Get(IDbConnection connection, int searchId)
        {
            return connection.Query<Route>(
            "SELECT * FROM routes WHERE routeID = @id",
            new { id = searchId }).FirstOrDefault();
        }

        public IEnumerable<Route> GetAll(IDbConnection connection)
        {
            return connection.Query<Route>(
            "SELECT * FROM routes").ToList();
        }
    }
}
