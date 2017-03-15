using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform
{
    public class LogisticCenter
    {
        public string name { get; set; }
        public Address logisticCenterAddress { get; set; }
        public Route shippingRoute { get; set; }
    }
}
