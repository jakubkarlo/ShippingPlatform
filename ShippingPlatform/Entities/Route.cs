using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform
{
    public class Route : BaseObject
    {

        public int startAddressID { get; set; }
        public int endAddressID { get; set; }
        public int orderID { get; set; }
        public Address startAddress { get; set; }
        public Address endAddress { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public Order order { get; set; }

        public override string ToString()
        {

            return "RouteID: " + id +
                "\nStart Address: " + startAddress +
                "\nStart Time: " + startTime +
                "\nEnd Address: " + endAddress +
                "\nEnd Time: " + endTime +
                "\nOrder: " + order + "\n"; 
        }


    }
}
