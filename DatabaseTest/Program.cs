using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShippingPlatform.Database;


namespace DatabaseTest
{
    class Program
    {
        static void Main(string[] args)
        {

            DapperConfiguration.Configure();
            DatabaseService service = new DatabaseService();

            AddressService addressService = new AddressService();
            ClientService client = new ClientService();
            LogisticCenterService center = new LogisticCenterService();
            NotificationService notify = new NotificationService();
            OrderService order = new OrderService();
            PackageService package = new PackageService();
            RouteService route = new RouteService();

            foreach(var a in client.getAll(service.getConnection())) 
            {
                Console.WriteLine(a.ToString() + "\n");
            }
   
            
            Console.WriteLine(addressService.getOne(service.getConnection(), 1)+"\n");
            Console.WriteLine(client.getOne(service.getConnection(), 1)+"\n");
            Console.WriteLine(center.getOne(service.getConnection(), 1) + "\n");
            Console.WriteLine(notify.getOne(service.getConnection(), 1) + "\n");
            Console.WriteLine(order.getOne(service.getConnection(), 1) + "\n");
            Console.WriteLine(package.getOne(service.getConnection(), 1) + "\n");
            Console.WriteLine(route.getOne(service.getConnection(), 1) + "\n");
            Console.ReadKey();

        }
    }
}
