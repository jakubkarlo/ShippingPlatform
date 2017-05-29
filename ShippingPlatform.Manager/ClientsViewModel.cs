using ShippingPlatform.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Manager
{
    class ClientsViewModel
    {

        private ObservableCollection<Client> clients;
        private DatabaseService databaseService;
        private ClientService clientService;

        public ClientsViewModel()
        {

            databaseService = new DatabaseService();
            clientService = new ClientService();
            clients = new ObservableCollection<Client>(clientService.getAll(databaseService.getConnection()).ToList<Client>());
        }

        public void AddClient(Client clientToAdd)
        {
            clientService.Insert(databaseService.getConnection(), clientToAdd);
            Client latestClient = clientService.getOne(databaseService.getConnection(), Clients.Last().id + 1);
            Clients.Add(latestClient);
        }

        public void UpdateClient(Client clientToUpdate, int searchID)
        {
            clientService.Update(databaseService.getConnection(), searchID, clientToUpdate);
            Client clientFromDB = clientService.getOne(databaseService.getConnection(), searchID);
            Clients[Clients.IndexOf(Clients.SingleOrDefault(p => p.id == clientFromDB.id))] = clientFromDB;

        }


        public void RemoveClient(int searchID)
        {
            Client clientToRemoveFromList = clientService.getOne(databaseService.getConnection(), searchID);
            Clients.Remove(Clients.SingleOrDefault(p => p.id == clientToRemoveFromList.id));
            clientService.Delete(databaseService.getConnection(), searchID);
        }



        public ObservableCollection<Client> Clients {
            get {
                return clients;
            }
            set {
                clients = value;
            }
        }
    }
}
