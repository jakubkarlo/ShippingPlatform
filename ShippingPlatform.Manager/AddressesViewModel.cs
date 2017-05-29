using ShippingPlatform.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Manager
{
    class AddressesViewModel 
    {
        
        private ObservableCollection<Address> addresses;
        private DatabaseService databaseService;
        private AddressService addressService;


        public AddressesViewModel()
        {
            //It has to be called only once
            DapperConfiguration.Configure();

            databaseService = new DatabaseService();
            addressService = new AddressService();
            addresses = new ObservableCollection<Address>(addressService.getAll(databaseService.getConnection()).ToList());
          
        }

        public void AddAddress(Address addressToAdd)
        {
            addressService.Insert(databaseService.getConnection(), addressToAdd);
            //Because we need ID of last address!
            Address latestAddress = addressService.getOne(databaseService.getConnection(), Addresses.Last().id + 1);
            Addresses.Add(latestAddress);
        }


        public void UpdateAddress(Address addressToUpdate, int searchID)
        {

            addressService.Update(databaseService.getConnection(), searchID, addressToUpdate);
            Address addressFromDB = addressService.getOne(databaseService.getConnection(), searchID);
            Addresses[Addresses.IndexOf(Addresses.SingleOrDefault(p => p.id == addressFromDB.id))] = addressFromDB;
        }

        public void DeleteAddress(int searchID)
        {
            Address addressToRemoveFromList = addressService.getOne(databaseService.getConnection(), searchID);
            Addresses.Remove(Addresses.SingleOrDefault(p => p.id == addressToRemoveFromList.id));
            addressService.Delete(databaseService.getConnection(), searchID);
        }



        public ObservableCollection<Address> Addresses {
            get {
                return addresses;
            }
            set {
                addresses = value;
            }
        }


    }
}
