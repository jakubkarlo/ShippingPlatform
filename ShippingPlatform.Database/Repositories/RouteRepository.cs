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
            //probably problem is with aliases - indexes 0
            return connection.Query<Route, Address, Address, Route>(
            @"SELECT * FROM routes 
            INNER JOIN addresses a1 ON routes.startAddressID = a1.addressID
            INNER JOIN addresses a2 ON routes.endAddressID = a2.addressID
            WHERE routeID = @id",
            (route, firstAddress, secondAddress) => {
                route.startAddress = firstAddress;
                route.endAddress = secondAddress;
                return route;
            },
            new { id = searchId }, null, false, "addressID").FirstOrDefault();
        }

        public IEnumerable<Route> GetAll(IDbConnection connection)
        {
            return connection.Query<Route>(
            "SELECT * FROM routes").ToList();
        }
    }
}
