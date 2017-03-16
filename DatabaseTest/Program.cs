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
            service.Get(service.getConnection(),1);
        }
    }
}
