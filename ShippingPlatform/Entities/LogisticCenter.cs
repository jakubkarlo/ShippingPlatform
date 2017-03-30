using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform
{
    public class LogisticCenter : BaseObject
    {
        public int logisticCenterAddressID { get; set; }
        public int shippingRouteID { get; set; }
        public string name { get; set; }
        public Address logisticCenterAddress { get; set; }
        public Route shippingRoute { get; set; }


        public override string ToString()
        {
            return "Logistic Centre ID: " + id +
                "\nName: " + name +
                "\nAddress: " + logisticCenterAddress +
                "\nRoute: " + shippingRoute + "\n";
        }

    }
}
