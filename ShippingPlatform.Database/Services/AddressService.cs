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
        //public void Insert(IDbConnection connection, string country, string city, string zipcode, string street, int housenumber)
        //{
        //    addressRepository.Insert(connection,country,city,zipcode,street,housenumber);
        //}
    }
}
