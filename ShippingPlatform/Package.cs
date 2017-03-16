using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform
{
    public class Package : BaseObject 
    {
        public double height { get; set; }
        public double width { get; set; }
        public double depth { get; set; }
        public double weight { get; set; }
        public string content { get; set; }
    }
}
