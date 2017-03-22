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
            return connection.Query<Client>(
            "SELECT * FROM clients WHERE clientID = @id",
            new { id = searchId }).FirstOrDefault();
        }

        public IEnumerable<Client> GetAll(IDbConnection connection)
        {
            return connection.Query<Client>(
            "SELECT * FROM clients").ToList();
        }
    }
}
