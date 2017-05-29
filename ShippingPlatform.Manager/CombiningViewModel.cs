using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Manager
{
    class CombiningViewModel
    {

        public CombiningViewModel(AddressesViewModel AVM, ClientsViewModel CVM)
        {
            addressesViewModel = AVM;
            clientsViewModel = CVM;
        }


        public AddressesViewModel addressesViewModel { get; set; }
        public ClientsViewModel clientsViewModel { get; set; }

}
}
