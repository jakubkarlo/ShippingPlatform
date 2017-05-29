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
            return connection.Query<Route, Address, Address, Order, Address, Address, Route>(
            @"SELECT * FROM routes 
            INNER JOIN addresses a1 ON routes.startAddressID = a1.addressID
            INNER JOIN addresses a2 ON routes.endAddressID = a2.addressID
            INNER JOIN orders ON routes.orderID = orders.orderID
            INNER JOIN addresses a3 ON orders.recipientAddressID = a3.addressID
            INNER JOIN addresses a4 ON orders.clientAddressID = a4.addressID
            WHERE routeID = @id",
           (route, startRouteAddress, endRouteAddress, order, orderRecipientAddress, orderClientAddress) => {
               route.startAddress = startRouteAddress;
               route.endAddress = endRouteAddress;
               route.order = order;
               route.order.recipientAddress = orderRecipientAddress;
               route.order.clientAddress = orderClientAddress;
               return route;
           },
            new { id = searchId }, null, false, "addressID,addressID,orderID,addressID,addressID").FirstOrDefault();
        }

        public IEnumerable<Route> GetAll(IDbConnection connection)
        {
            return connection.Query<Route, Address, Address,Order,Address,Address, Route>(
           @"SELECT * FROM routes 
            INNER JOIN addresses a1 ON routes.startAddressID = a1.addressID
            INNER JOIN addresses a2 ON routes.endAddressID = a2.addressID
            INNER JOIN orders ON routes.orderID = orders.orderID
            INNER JOIN addresses a3 ON orders.recipientAddressID = a3.addressID
            INNER JOIN addresses a4 ON orders.clientAddressID = a4.addressID",
           (route, startRouteAddress, endRouteAddress, order, orderRecipientAddress, orderClientAddress) => {
               route.startAddress = startRouteAddress;
               route.endAddress = endRouteAddress;
               route.order = order;
               route.order.recipientAddress = orderRecipientAddress;
               route.order.clientAddress = orderClientAddress;
               return route;
           },
           splitOn: "addressID,addressID,orderID,addressID,addressID").ToList();
        }

        public Route Delete(IDbConnection connection, int searchId)
        {
            return connection.Query<Route>("DELETE FROM routes WHERE routeID = @id", new { id = searchId }).FirstOrDefault();
        }

        public Route Insert(IDbConnection connection, Route newRoute)
        {
            return connection.Query<Route>("INSERT INTO routes(startAddressID, endAddressID, startTime, endTime, orderID) values(@startAddressID, @endAddressID, @startTime, @endTime, @orderID)",
                new { startAddressID = newRoute.startAddressID, endAddressID = newRoute.endAddressID, startTime = newRoute.startTime, endTime = newRoute.endTime, orderID = newRoute.orderID }).FirstOrDefault();
        }


        public Route Update(IDbConnection connection, int searchID, Route newRoute)
        {
            return connection.Query<Route>("UPDATE routes SET startAddressID=@startAddressID, endAddressID=@endAddressID, startTime=@startTime, endTime=@endTime, orderID=@orderID WHERE routeID =@id",
                new { id = searchID, startAddressID = newRoute.startAddressID, endAddressID = newRoute.endAddressID, startTime = newRoute.startTime, endTime = newRoute.endTime, orderID = newRoute.orderID }).FirstOrDefault();
        }

    }
}
