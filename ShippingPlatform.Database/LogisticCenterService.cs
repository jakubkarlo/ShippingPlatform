using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Database
{
    class LogisticCenterService
    {
        private LogisticCenterRepository logisticCenterRepository = new LogisticCenterRepository();

        public LogisticCenter getOne(IDbConnection connection, int searchID)
        {
            return logisticCenterRepository.Get(connection, searchID);
        }

        public IEnumerable<LogisticCenter> getAll(IDbConnection connection)
        {
            return logisticCenterRepository.GetAll(connection);
        }
    }
}
