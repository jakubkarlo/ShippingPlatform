using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform
{
    public class Address : BaseObject
    {
        public string country { get; set; }
        public string city{ get; set; }
        public string zipcode{ get; set; }
        public string street{ get; set; }
        public int housenumber{ get; set; }

        public override string ToString()
        {
            return "ID: " + id + ", " + street + " " + housenumber + ", " + zipcode + " " + city + ", " + country;
            
            //optional
            //return "AddressID: " + id +
            //    "\nCountry: " + country + 
            //    "\nCity: " + city + 
            //    "\nZipcode: " + zipcode + 
            //    "\nStreet: " + street + 
            //    "\nHousenumber: " + housenumber + "\n"; 
        }

    }

}
