using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform
{
    public class Client : BaseObject
    {
        public int clientAddressID { get; set; }
        public int orderID { get; set; }
        public Address clientAddress { get; set; }
        public Order order { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string emailAddress { get; set; }

        public override string ToString()
        {
            return "ClientID: " + id +
                "\nLogin: " + login +
                "\nPassword: " + password +
                "\nEmail Address: " + emailAddress +
                "\nAddress: " + clientAddress +
                "\nOrder: " + order + "\n";
        }

    }
}
