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

        public Package Delete(IDbConnection connection, int searchId)
        {
            return connection.Query<Package>("DELETE FROM packages WHERE packageID = @id", new { id = searchId }).FirstOrDefault();
        }

        public Package Insert(IDbConnection connection, Package newPackage)
        {
            return connection.Query<Package>("INSERT INTO packages(height, width, depth, weight, content, orderID) values(@height, @width, @depth, @weight, @content, @orderID)",
                new { height = newPackage.height, width = newPackage.width, depth = newPackage.depth, weight = newPackage.weight, content = newPackage.content, orderID = newPackage.orderID }).FirstOrDefault();
        }


        public Package Update(IDbConnection connection, int searchID, Package newPackage)
        {
            return connection.Query<Package>("UPDATE packages SET height=@height, width=@width, depth=@depth, weight=@weight, content=@content, orderID=@orderID WHERE packageID =@id",
                new { id = searchID, height = newPackage.height, width = newPackage.width, depth = newPackage.depth, weight = newPackage.weight, content = newPackage.content, orderID = newPackage.orderID }).FirstOrDefault();
        }
    }
}
