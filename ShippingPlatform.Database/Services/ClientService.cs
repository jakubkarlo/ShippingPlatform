﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Database
{
    public class ClientService
    {
        private ClientRepository clientRepository = new ClientRepository();

        public Client getOne(IDbConnection connection, int searchID)
        {
            return clientRepository.Get(connection, searchID);
        }

        public IEnumerable<Client> getAll(IDbConnection connection)
        {
            return clientRepository.GetAll(connection);
        }

        public Client Delete(IDbConnection connection, int searchID)
        {
            return clientRepository.Delete(connection, searchID);
        }

        public Client Insert(IDbConnection connection, Client newClient)
        {
            return clientRepository.Insert(connection, newClient);
        }

        public Client Update(IDbConnection connection, int searchID, Client newClient)
        {
            return clientRepository.Update(connection, searchID, newClient);
        }
    }
}
