using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShippingPlatform.Database;
using ShippingPlatform;

namespace DatabaseTest
{
    class Program
    {
        static void Main(string[] args)
        {
            // maybe you'll need constructor with parameters?
            Address a1 = new Address();
            a1.country = "Korea";
            a1.city = "Seoul";
            a1.zipcode = "345325";
            a1.street = "Gunho";
            a1.housenumber = 12;


            DapperConfiguration.Configure();
            DatabaseService service = new DatabaseService();
            AddressService addressService = new AddressService();
            ClientService client = new ClientService();
            LogisticCenterService center = new LogisticCenterService();
            NotificationService notify = new NotificationService();
            OrderService order = new OrderService();
            PackageService package = new PackageService();
            RouteService route = new RouteService();

            addressService.Delete(service.getConnection(), 7);
            addressService.Insert(service.getConnection(), a1);
            a1.city = "NotSeoul";
            addressService.Update(service.getConnection(), 8, a1);

            foreach (var a in client.getAll(service.getConnection()))
            {
                Console.WriteLine(a.ToString() + "\n");
            }
            foreach (var a in center.getAll(service.getConnection()))
            {
                Console.WriteLine(a.ToString() + "\n");
            }
            foreach (var a in order.getAll(service.getConnection()))
            {
                Console.WriteLine(a.ToString() + "\n");
            }
            foreach (var a in notify.getAll(service.getConnection()))
            {
                Console.WriteLine(a.ToString() + "\n");
            }
            foreach (var a in route.getAll(service.getConnection()))
            {
                Console.WriteLine(a.ToString() + "\n");
            }
            foreach (var a in package.getAll(service.getConnection()))
            {
                Console.WriteLine(a.ToString() + "\n");
            }


            //Console.WriteLine(addressService.getOne(service.getConnection(), 1)+"\n");
            //Console.WriteLine(client.getOne(service.getConnection(), 1)+"\n");
            Console.WriteLine(center.getOne(service.getConnection(), 1) + "\n");
            //Console.WriteLine(notify.getOne(service.getConnection(), 1) + "\n");
            //Console.WriteLine(order.getOne(service.getConnection(), 1) + "\n");
            //Console.WriteLine(package.getOne(service.getConnection(), 1) + "\n");
            //Console.WriteLine(route.getOne(service.getConnection(), 1) + "\n");
            Console.ReadKey();

        }
    }
}
