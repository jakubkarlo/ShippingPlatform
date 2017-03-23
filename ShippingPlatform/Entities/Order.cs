using System;
using System.Collections.Generic;

namespace ShippingPlatform
{
    public class Order : BaseObject
    {
        public int recipientAddressID { get; set; }
        public int clientAddressID { get; set; }
        public Address recipientAddress { get; set; }
        public Address clientAddress { get; set; }
        public string referenceNumber { get; set; }
        public DateTime createdDate { get; set; }
        public DateTime pickupDate { get; set; }
        public DateTime deliveryDate { get; set; }
        public string status { get; set; }
        public List<Route> routes { get; set; }
        public List<Package> packages { get; set; }

        public override string ToString()
        {
            return "Order ID: " + id +
                    "\nSender Address: " + clientAddress +
                    "\nRecipient Address: " + recipientAddress +
                    "\nReference number: " + referenceNumber +
                    "\nDate of creation: " + createdDate +
                    "\nPickup Date: " + pickupDate +
                    "\nDelivery Date: " + deliveryDate +
                    "\nstatus: " + status + "\n";
                ;
         }

    }
}
