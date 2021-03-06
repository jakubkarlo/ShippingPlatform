﻿using Dapper;
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
            return connection.Query<Order>(@"SELECT * FROM orders
            WHERE orderID = @id", new { id = searchId }).FirstOrDefault();
            //return connection.Query<Order,Address,Address,Order>(
            //@"SELECT * FROM orders
            //INNER JOIN addresses a1 ON orders.recipientAddressID = a1.addressID
            //INNER JOIN addresses a2 ON orders.clientAddressID = a2.addressID
            //WHERE orderID = @id",
            // (order, firstAddress, secondAddress) => {
            //     order.recipientAddress = firstAddress;
            //     order.clientAddress = secondAddress;
            //     return order;
            // },
            //new { id = searchId }, null, false, "addressID").FirstOrDefault();
        }

        public IEnumerable<Order> GetAll(IDbConnection connection)
        {
            return connection.Query<Order>(
           @"SELECT * FROM orders");

           // return connection.Query<Order, Address, Address, Order>(
           //@"SELECT * FROM orders
           // INNER JOIN addresses a1 ON orders.recipientAddressID = a1.addressID
           // INNER JOIN addresses a2 ON orders.clientAddressID = a2.addressID",
           // (order, firstAddress, secondAddress) => {
           //     order.recipientAddress = firstAddress;
           //     order.clientAddress = secondAddress;
           //     return order;
           // },
           //splitOn: "addressID").ToList();
        }

        public Order Delete(IDbConnection connection, int searchId)
        {
            return connection.Query<Order>("DELETE FROM orders WHERE orderID = @id", new { id = searchId }).FirstOrDefault();
        }

        public Order Insert(IDbConnection connection, Order newOrder)
        {
            return  connection.Query<Order>("INSERT INTO orders(recipientAddressID, clientAddressID, referenceNumber, createdDate, pickupDate, deliveryDate, status) values(@recipientAddressID, @clientAddressID, @referenceNumber, @createdDate, @pickupDate, @deliveryDate, @status)",
                new { recipientAddressID = newOrder.recipientAddressID, clientAddressID = newOrder.clientAddressID, referenceNumber = newOrder.referenceNumber, createdDate = newOrder.createdDate, pickupDate = newOrder.pickupDate, deliveryDate = newOrder.deliveryDate, status = newOrder.status }).FirstOrDefault();
        }


        public Order Update(IDbConnection connection, int searchID, Order newOrder)
        {
            return connection.Query<Order>("UPDATE orders SET recipientAddressID=@recipientAddressID, clientAddressID=@clientAddressID, referenceNumber=@referenceNumber, createdDate=@createdDate, pickupDate=@pickupDate, deliveryDate=@deliveryDate, status=@status WHERE orderID =@id",
                new { id = searchID, recipientAddressID = newOrder.recipientAddressID, clientAddressID = newOrder.clientAddressID, referenceNumber = newOrder.referenceNumber, createdDate = newOrder.createdDate, pickupDate = newOrder.pickupDate, deliveryDate = newOrder.deliveryDate, status = newOrder.status }).FirstOrDefault();
        }

    }
}
