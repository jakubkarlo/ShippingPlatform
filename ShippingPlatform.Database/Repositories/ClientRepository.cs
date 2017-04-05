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
            return connection.Query<Client,Address,Order,Client>(
            @"SELECT * FROM clients 
            INNER JOIN addresses ON clients.clientAddressID = addresses.addressID
            INNER JOIN orders ON clients.orderID = orders.orderID
            WHERE clientID = @id",
            (client, address, order)=>{
                client.clientAddress = address;
                client.order = order;
                return client;
            },
            new { id = searchId }, splitOn: "addressID,orderID").FirstOrDefault();
        }

        public IEnumerable<Client> GetAll(IDbConnection connection)
        {
            return connection.Query<Client,Address,Order,Client>(
             @"SELECT * FROM clients 
            INNER JOIN addresses ON clients.clientAddressID = addresses.addressID
            INNER JOIN orders ON clients.orderID = orders.orderID",
            (client, address, order) => {
                client.clientAddress = address;
                client.order = order;
                return client;
            },
             splitOn: "addressID,orderID").ToList();
        }
    }
}
