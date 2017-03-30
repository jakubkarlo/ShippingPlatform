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
            return connection.Query<Order>(
            "SELECT * FROM orders WHERE orderID = @id",
            new { id = searchId }).FirstOrDefault();
        }

        public IEnumerable<Order> GetAll(IDbConnection connection)
        {
            return connection.Query<Order>(
            "SELECT * FROM orders").ToList();
        }
    }
}
