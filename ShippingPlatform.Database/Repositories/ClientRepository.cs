using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Database
{
    class ClientRepository
    {
        public Client Get(IDbConnection connection, int searchId)
        {
            return connection.Query<Client,Address,Order,Address,Address,Client>(
            @"SELECT  * FROM clients
            INNER JOIN addresses a1 ON clients.clientAddressID = a1.addressID
            INNER JOIN orders ON clients.orderID = orders.orderID
            INNER JOIN addresses a2 ON orders.recipientAddressID = a2.addressID
            INNER JOIN addresses a3 ON orders.clientAddressID = a3.addressID
            WHERE clientID = @id",
            (client, clientAddress, order, orderClientAddress, orderRecipientAddress)=>{
                client.clientAddress = clientAddress;
                client.order = order;
                client.order.clientAddress = orderClientAddress;
                client.order.recipientAddress = orderRecipientAddress;
                return client;
            },
            new { id = searchId }, splitOn: "addressID,orderID,addressID,addressID").FirstOrDefault();
        }

        public IEnumerable<Client> GetAll(IDbConnection connection)
        {
            return connection.Query<Client, Address, Order, Address, Address, Client>(
             @"SELECT * FROM clients 
            INNER JOIN addresses a1 ON clients.clientAddressID = a1.addressID
            INNER JOIN orders ON clients.orderID = orders.orderID
            INNER JOIN addresses a2 ON orders.recipientAddressID = a2.addressID
            INNER JOIN addresses a3 ON orders.clientAddressID = a3.addressID",
            (client, clientAddress, order, orderClientAddress, orderRecipientAddress) => {
                client.clientAddress = clientAddress;
                client.order = order;
                client.order.clientAddress = orderClientAddress;
                client.order.recipientAddress = orderRecipientAddress;
                return client;
            },
             splitOn: "addressID,orderID,addressID,addressID").ToList();
        }
    }
}
