using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Database
{
    public class LogisticCenterService
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

        public LogisticCenter Delete(IDbConnection connection, int searchID)
        {
            return logisticCenterRepository.Delete(connection, searchID);
        }

        public LogisticCenter Insert(IDbConnection connection, LogisticCenter newLogisticCenter)
        {
            return logisticCenterRepository.Insert(connection, newLogisticCenter);
        }

        public LogisticCenter Update(IDbConnection connection, int searchID, LogisticCenter newLogisticCenter)
        {
            return logisticCenterRepository.Update(connection, searchID, newLogisticCenter);
        }
    }
}
