﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform
{
    public class Notification
    {
        public string clientEmail { get; set; }
        public string recipientEmail { get; set; }
        public string message { get; set; }
        public string subject { get; set; }
        public DateTime timestamp { get; set; }
        public Order order { get; set; }
        public List<string> attachments { get; set; }
    }
}