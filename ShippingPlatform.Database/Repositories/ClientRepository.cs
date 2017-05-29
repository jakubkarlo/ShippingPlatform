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

        public Client Delete(IDbConnection connection, int searchId)
        {
            return connection.Query<Client>("DELETE FROM clients WHERE clientID = @id", new { id = searchId }).FirstOrDefault();
        }



        public Client Insert(IDbConnection connection, Client newClient)
        {
            return connection.Query<Client>("INSERT INTO clients(clientAddressID, orderID, login, password, emailAddress) values(@clientAddressID, @orderID, @login, @password, @emailAddress)",
                new { clientAddressID = newClient.clientAddressID, orderID = newClient.orderID, login = newClient.login, password =newClient.password, emailAddress = newClient.emailAddress}).FirstOrDefault();

        }


        public Client Update(IDbConnection connection, int searchID, Client newClient)
        {
            return connection.Query<Client>("UPDATE clients SET clientAddressID=@clientAddressID, orderID=@orderID, login=@login, password=@password, emailAddress=@emailAddress WHERE clientID = @id",
                new { id = searchID, clientAddressID = newClient.clientAddressID, orderID = newClient.orderID, login = newClient.login, password = newClient.password, emailAddress = newClient.emailAddress }).FirstOrDefault();

        }

    }
}
