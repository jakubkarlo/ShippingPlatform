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

        //public Address Insert(IDbConnection connection, Address newAddress)
        //{
        //    return connection.Query<Address>("INSERT INTO addresses(country, city, zipcode, street, housenumber) values(@country, @city, @zipcode, @street, @housenumber)",
        //        new { country = newAddress.country, city = newAddress.city, zipcode = newAddress.zipcode, street = newAddress.street, housenumber = newAddress.housenumber }).FirstOrDefault();

        //}


        //public Address Update(IDbConnection connection, int searchID, Address newAddress)
        //{

        //    return connection.Query<Address>("UPDATE addresses SET country=@country, city=@city,zipcode=@zipcode,street=@street,housenumber=@housenumber WHERE addressID=@id",
        //        new { id = searchID, country = newAddress.country, city = newAddress.city, zipcode = newAddress.zipcode, street = newAddress.street, housenumber = newAddress.housenumber }).FirstOrDefault();

        //}
    }
}
