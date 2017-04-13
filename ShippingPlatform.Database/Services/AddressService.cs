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
   
        public Address Insert (IDbConnection connection, Address newAddress)
        {
            return addressRepository.Insert(connection, newAddress);
        }

        public Address Update(IDbConnection connection, int searchID, Address newAddress)
        {
            return addressRepository.Update(connection, searchID, newAddress);
        }

        public Address Delete(IDbConnection connection, int searchID)
        {
            return addressRepository.Delete(connection, searchID);
        }
    }
}
