using ShippingPlatform.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Manager
{
    class ClientsViewModel
    {

        private List<Address> clients;

        public ClientsViewModel()
        {

            DatabaseService DBService = new DatabaseService();
            AddressService addressService = new AddressService();
            clients = addressService.getAll(DBService.getConnection()).ToList<Address>();
        }

        public List<Address> Clients {
            get {
                return clients;
            }
            set {
                clients = value;
            }
        }
    }
}
