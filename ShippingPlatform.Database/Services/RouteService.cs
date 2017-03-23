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
    }
}
