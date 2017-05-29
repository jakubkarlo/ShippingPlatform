using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Database
{
    public class RouteService
    {
        private RouteRepository routeRepository = new RouteRepository();

        public Route getOne(IDbConnection connection, int searchID)
        {
            return routeRepository.Get(connection, searchID);
        }

        public IEnumerable<Route> getAll(IDbConnection connection)
        {
            return routeRepository.GetAll(connection);
        }

        public Route Delete(IDbConnection connection, int searchID)
        {
            return routeRepository.Delete(connection, searchID);
        }

        public Route Insert(IDbConnection connection, Route newRoute)
        {
            return routeRepository.Insert(connection, newRoute);
        }

        public Route Update(IDbConnection connection, int searchID, Route newRoute)
        {
            return routeRepository.Update(connection, searchID, newRoute);
        }

    }
}
