using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Database
{
    class LogisticCenterRepository
    {
        public LogisticCenter Get(IDbConnection connection, int searchId)
        {
            return connection.Query<LogisticCenter,Address,Route, LogisticCenter>(
            @"SELECT * FROM logistic_centers 
            INNER JOIN addresses  ON logistic_centers.addressID = addresses.addressID
            INNER JOIN routes  ON logistic_centers.shippingRouteID = routes.routeID
            WHERE logisticCenterID = @id",
            (center, address, route) =>{
                center.logisticCenterAddress = address;
                center.shippingRoute = route;
                return center;
            },
            new { id = searchId },null,false, "addressID, routeID").FirstOrDefault();
        }


        public IEnumerable<LogisticCenter> GetAll(IDbConnection connection)
        {
            return connection.Query<LogisticCenter>(
            "SELECT * FROM logistic_centers").ToList();
        }
    }
}
