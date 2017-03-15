using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform
{
    public class Route
    {
        public Address startAddress { get; set; }
        public Address endAddress { get; set; }
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
    }
}
