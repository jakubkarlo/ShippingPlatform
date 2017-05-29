using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Manager
{
    class CombiningViewModel
    {

        public CombiningViewModel(AddressesViewModel AVM, ClientsViewModel CVM, PackagesViewModel PVM, OrdersViewModel OVM)
        {
            addressesViewModel = AVM;
            clientsViewModel = CVM;
            packagesViewModel = PVM;
            ordersViewModel = OVM;
        }


        public AddressesViewModel addressesViewModel { get; set; }
        public ClientsViewModel clientsViewModel { get; set; }
        public PackagesViewModel packagesViewModel { get; set; }
        public OrdersViewModel ordersViewModel { get; set; }

}
}
