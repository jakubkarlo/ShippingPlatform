using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform
{
    public class Notification : BaseObject
    {
        public string clientEmail { get; set; }
        public string recipientEmail { get; set; }
        public string message { get; set; }
        public string subject { get; set; }
        public DateTime timestamp { get; set; }
        public Order order { get; set; }
        public int attachmentID { get; set; } // because user will just have like a "link", "reference" to attachment, we don't want they to download everything at once
    }
}
