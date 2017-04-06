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
            return connection.Query<Package, Order, Address, Address, Package>(
           @"SELECT * FROM packages
            INNER JOIN orders ON packages.orderID = orders.orderID
            INNER JOIN addresses a1 ON orders.recipientAddressID = a1.addressID
            INNER JOIN addresses a2 ON orders.clientAddressID = a2.addressID
            WHERE packageID = @id",
           (package, order, firstAddress, secondAddress) => {
               package.order = order;
               package.order.recipientAddress = firstAddress;
               package.order.clientAddress = secondAddress;
               return package;
           },
           new { id = searchId }, null, false, "orderID,addressID,addressID").FirstOrDefault();
        }

        public IEnumerable<Package> GetAll(IDbConnection connection)
        {
            return connection.Query<Package, Order,Address,Address,Package>(
            @"SELECT * FROM packages
            INNER JOIN orders ON packages.orderID = orders.orderID
            INNER JOIN addresses a1 ON orders.recipientAddressID = a1.addressID
            INNER JOIN addresses a2 ON orders.clientAddressID = a2.addressID",
            (package, order, firstAddress, secondAddress) => {
                package.order = order;
                package.order.recipientAddress = firstAddress;
                package.order.clientAddress = secondAddress;
                return package;
            },
           splitOn: "orderID,addressID,addressID").ToList();
        }
    }
}
