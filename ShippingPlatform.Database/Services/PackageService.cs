using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Database
{
    public class PackageService
    {
        private PackageRepository packageRepository = new PackageRepository();

        public Package getOne(IDbConnection connection, int searchID)
        {
            return packageRepository.Get(connection, searchID);
        }

        public IEnumerable<Package> getAll(IDbConnection connection)
        {
            return packageRepository.GetAll(connection);
        }

        public Package Delete(IDbConnection connection, int searchID)
        {
            return packageRepository.Delete(connection, searchID);
        }

        public Package Insert(IDbConnection connection, Package newPackage)
        {
            return packageRepository.Insert(connection, newPackage);
        }

        public Package Update(IDbConnection connection, int searchID, Package newPackage)
        {
            return packageRepository.Update(connection, searchID, newPackage);
        }

    }
}
