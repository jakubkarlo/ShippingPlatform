using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Database
{
    public class OrderService
    {
        private OrderRepository orderRepository = new OrderRepository();

        public Order getOne(IDbConnection connection, int searchID)
        {
            return orderRepository.Get(connection, searchID);
        }

        public IEnumerable<Order> getAll(IDbConnection connection)
        {
            return orderRepository.GetAll(connection);
        }
    }
}
