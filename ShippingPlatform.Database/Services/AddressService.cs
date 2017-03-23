using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Database
{
    public class AddressService
    {
        private AddressRepository addressRepository = new AddressRepository();

        public Address getOne(IDbConnection connection, int searchID)
        {
            return addressRepository.Get(connection, searchID);
        }

        public IEnumerable<Address> getAll(IDbConnection connection)
        {
            return addressRepository.GetAll(connection);
        }

    }
}
