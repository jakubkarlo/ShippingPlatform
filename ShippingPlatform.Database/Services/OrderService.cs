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

        public Order Delete(IDbConnection connection, int searchID)
        {
            return orderRepository.Delete(connection, searchID);
        }

        public Order Insert(IDbConnection connection, Order newOrder)
        {
            return orderRepository.Insert(connection, newOrder);
        }

        public Order Update(IDbConnection connection, int searchID, Order newOrder)
        {
            return orderRepository.Update(connection, searchID, newOrder);
        }

    }
}
