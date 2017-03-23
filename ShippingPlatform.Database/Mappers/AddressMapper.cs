using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Dapper.FluentMap;
using Dapper.FluentMap.Mapping;

namespace ShippingPlatform.Database
  
{
    public class AddressMapper : EntityMap<Address>
    {
        public AddressMapper()
        {
            Map(x => x.id).ToColumn("addressID");
            Map(x => x.country).ToColumn("country");
            Map(x => x.city).ToColumn("city");
            Map(x => x.zipcode).ToColumn("zipcode");
            Map(x => x.street).ToColumn("street");
            Map(x => x.housenumber).ToColumn("housenumber");
        }
    }
}
