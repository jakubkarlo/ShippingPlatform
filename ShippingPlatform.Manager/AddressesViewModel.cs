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

        private List<Address> addresses;

        ObservableCollection<Address> addr;


        public AddressesViewModel()
        {
            addr = new ObservableCollection<Address>();
            DapperConfiguration.Configure();
            DatabaseService DBService = new DatabaseService();
            AddressService addressService = new AddressService();
            addresses = addressService.getAll(DBService.getConnection()).ToList<Address>();
            foreach (var address in addresses)
            {
                Addresses.Add(address);
                
            }
          
        }

        public ObservableCollection<Address> Addresses {
            get {
                return addr;
            }
            set {
                addr = value;
                NotifyPropertyChanged("Addresses");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String info)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(info));
            }
        }


    }
}
