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

        private List<Client> clients;

        public ClientsViewModel()
        {
            DapperConfiguration.Configure();
            DatabaseService DBService = new DatabaseService();
            ClientService clientService = new ClientService();
            clients = clientService.getAll(DBService.getConnection()).ToList<Client>();
        }

        public List<Client> Clients {
            get {
                return clients;
            }
            set {
                clients = value;
            }
        }
    }
}
