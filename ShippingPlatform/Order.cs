using System;
using System.Collections.Generic;

namespace ShippingPlatform
{
    public class Order
    {
        public Address recipientAddress { get; set; }
        public Address clientAddress { get; set; }
        public string referenceNumber { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime pickupDate { get; set; }
        public DateTime deliveryDate { get; set; }
        public string status { get; set; }
        public List<Route> routes { get; set; }
        public List<Package> packages { get; set; }
    }
}
