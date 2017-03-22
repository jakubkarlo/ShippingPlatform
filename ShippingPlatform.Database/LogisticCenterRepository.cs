using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Database
{
    class LogisticCenterRepository
    {
        public LogisticCenter Get(IDbConnection connection, int searchId)
        {
            return connection.Query<LogisticCenter>(
            "SELECT * FROM logistic_centers WHERE logisticCenterID = @id",
            new { id = searchId }).FirstOrDefault();
        }

        public IEnumerable<LogisticCenter> GetAll(IDbConnection connection)
        {
            return connection.Query<LogisticCenter>(
            "SELECT * FROM logistic_centers").ToList();
        }
    }
}
