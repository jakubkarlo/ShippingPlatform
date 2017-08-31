using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform
{
    public class Package : BaseObject 
    {
        public int orderID { get; set; }
        public Order order { get; set; }

        public double height { get; set; }
        public double width { get; set; }
        public double depth { get; set; }
        public double weight { get; set; }
        public string content { get; set; }

        public override string ToString()
        {
            return "Package ID: " + id +
                "\nHeight: " + height +
                "\nWidth: " + width +
                "\nDepth: " + depth +
                "\nWeight: " + weight +
                "\nContent: " + content +
                "\nOrder: " + order + "\n";
        }
    }
}
