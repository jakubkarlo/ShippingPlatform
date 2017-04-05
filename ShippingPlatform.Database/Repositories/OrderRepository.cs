using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Database
{
    class OrderRepository
    {
        public Order Get(IDbConnection connection, int searchId)
        {
            return connection.Query<Order,Address,Address,Order>(
            @"SELECT * FROM orders
            INNER JOIN addresses a1 ON orders.recipientAddressID = a1.addressID
            INNER JOIN addresses a2 ON orders.clientAddressID = a2.addressID
            WHERE orderID = @id",
             (order, firstAddress, secondAddress) => {
                 order.recipientAddress = firstAddress;
                 order.clientAddress = secondAddress;
                 return order;
             },
            new { id = searchId }, null, false, "addressID").FirstOrDefault();
        }

        public IEnumerable<Order> GetAll(IDbConnection connection)
        {
            return connection.Query<Order, Address, Address, Order>(
           @"SELECT * FROM orders
            INNER JOIN addresses a1 ON orders.recipientAddressID = a1.addressID
            INNER JOIN addresses a2 ON orders.clientAddressID = a2.addressID",
            (order, firstAddress, secondAddress) => {
                order.recipientAddress = firstAddress;
                order.clientAddress = secondAddress;
                return order;
            },
           splitOn: "addressID").ToList();
        }
    }
}
