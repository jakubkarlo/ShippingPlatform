using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform
{
    public class Address
    {
        public int id { get; set; }
        public string country { get; set; }
        public string city{ get; set; }
        public string zipcode{ get; set; }
        public string street{ get; set; }
        public int housenumber{ get; set; }
    }
}
