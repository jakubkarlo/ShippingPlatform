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
            return connection.Query<LogisticCenter,Address,Route,Address,Address, LogisticCenter>(
            @"SELECT * FROM logistic_centers 
            INNER JOIN addresses a1  ON logistic_centers.addressID = a1.addressID
            INNER JOIN routes  ON logistic_centers.shippingRouteID = routes.routeID
            INNER JOIN addresses a2 ON routes.startAddressID = a2.addressID
            INNER JOIN addresses a3 ON routes.endAddressID = a3.addressID
            WHERE logisticCenterID = @id",
            (center, centerAddress, route, routeStartAddress, routeEndAddress) =>{
                center.logisticCenterAddress = centerAddress;
                center.shippingRoute = route;
                center.shippingRoute.startAddress = routeStartAddress;
                center.shippingRoute.endAddress = routeEndAddress;
                return center;
            },
            new { id = searchId },null,false, "addressID, routeID,addressID,addressID").FirstOrDefault();
        }


        public IEnumerable<LogisticCenter> GetAll(IDbConnection connection)
        {
            return connection.Query<LogisticCenter,Address,Route,Address,Address,LogisticCenter>(
            @"SELECT * FROM logistic_centers 
            INNER JOIN addresses a1  ON logistic_centers.addressID = a1.addressID
            INNER JOIN routes  ON logistic_centers.shippingRouteID = routes.routeID
            INNER JOIN addresses a2 ON routes.startAddressID = a2.addressID
            INNER JOIN addresses a3 ON routes.endAddressID = a3.addressID",
             (center, centerAddress, route, routeStartAddress, routeEndAddress) => {
                 center.logisticCenterAddress = centerAddress;
                 center.shippingRoute = route;
                 center.shippingRoute.startAddress = routeStartAddress;
                 center.shippingRoute.endAddress = routeEndAddress;
                 return center;
             },
             splitOn:"addressID, routeID,addressID,addressID").ToList();
        }
    }
}
