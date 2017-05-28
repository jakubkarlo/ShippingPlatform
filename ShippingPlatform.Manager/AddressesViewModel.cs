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
    class AddressesViewModel : INotifyPropertyChanged
    {

        private List<Address> addr;
        private DatabaseService databaseService;
        AddressService addressService;


        public AddressesViewModel()
        {
            DapperConfiguration.Configure();
            databaseService = new DatabaseService();
            addressService = new AddressService();
            addr = new List<Address>(addressService.getAll(databaseService.getConnection()).ToList());
          
        }

        public void AddAddress(Address addressToAdd)
        {
            addressService.Insert(databaseService.getConnection(), addressToAdd);
            //TODO update the view
        }


        public void UpdateAddress(Address addressToUpdate, int searchID)
        {
            addressService.Update(databaseService.getConnection(), searchID, addressToUpdate);
            //TODO update the view
        }

        public void DeleteAddress(int searchID)
        {
            addressService.Delete(databaseService.getConnection(), searchID);
            //TODO update the view
        }



        public List<Address> Addresses {
            get {
                return addr;
            }
            set {
                addr = value;
                RaisePropertyChanged("Addresses");
            }
        }




        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }


    }
}
