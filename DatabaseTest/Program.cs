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
            DatabaseService service = new DatabaseService();

            //service.openConnection(service.getConnection()); why? 

            AddressService addressService = new AddressService();

 
            Console.WriteLine(addressService.getOne(service.getConnection(), 2).city);


          
          
        }
    }
}
