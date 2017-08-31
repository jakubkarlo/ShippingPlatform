using ShippingPlatform.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Manager
{
    class OrdersViewModel
    {

        private ObservableCollection<Order> orders;
        private DatabaseService databaseService;
        private OrderService orderService;

        public OrdersViewModel()
        {
            databaseService = new DatabaseService();
            orderService = new OrderService();
            orders = new ObservableCollection<Order>(orderService.getAll(databaseService.getConnection()).ToList<Order>());
        }


        public void AddOrder(Order orderToAdd)
        {
            orderService.Insert(databaseService.getConnection(), orderToAdd);
            Order latestOrder = orderService.getOne(databaseService.getConnection(), Orders.Last().id + 1);
            Orders.Add(latestOrder);
        }

        public void UpdateOrder(Order orderToUpdate, int searchID)
        {
            orderService.Update(databaseService.getConnection(), searchID, orderToUpdate);
            Order orderFromDB = orderService.getOne(databaseService.getConnection(), searchID);
            Orders[Orders.IndexOf(Orders.SingleOrDefault(p => p.id == orderFromDB.id))] = orderFromDB;

        }


        public void RemoveOrder(int searchID)
        {
            Order orderToRemoveFromList = orderService.getOne(databaseService.getConnection(), searchID);
            Orders.Remove(Orders.SingleOrDefault(p => p.id == orderToRemoveFromList.id));
            orderService.Delete(databaseService.getConnection(), searchID);
        }

        public ObservableCollection<Order> Orders
        {
            get
            {
                return orders;
            }
            set
            {
                orders = value;
            }
        }

    }
}
