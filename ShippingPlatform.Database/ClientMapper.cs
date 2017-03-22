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
    public class ClientMapper :EntityMap<Client>
    {
        public ClientMapper()
        {
            Map(x => x.id).ToColumn("clientID");
            Map(x => x.clientAddress).ToColumn("clientAddressID");
            Map(x => x.order).ToColumn("orderID");
            Map(x => x.login).ToColumn("login");
            Map(x => x.password).ToColumn("password");
            Map(x => x.emailAddress).ToColumn("emailAddress");
        }
    }
}
