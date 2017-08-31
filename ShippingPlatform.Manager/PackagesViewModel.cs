using ShippingPlatform.Database;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingPlatform.Manager
{
    class PackagesViewModel
    {

        private ObservableCollection<Package> packages;
        private DatabaseService databaseService;
        private PackageService packageService;

        public PackagesViewModel()
        {
            databaseService = new DatabaseService();
            packageService = new PackageService();
            packages = new ObservableCollection<Package>(packageService.getAll(databaseService.getConnection()).ToList<Package>());
        }

        public void AddPackage(Package packageToAdd)
        {
            packageService.Insert(databaseService.getConnection(), packageToAdd);
            Package latestPackage = packageService.getOne(databaseService.getConnection(), Packages.Last().id + 1);
            Packages.Add(latestPackage);
        }

        public void UpdatePackage(Package packageToUpdate, int searchID)
        {
            packageService.Update(databaseService.getConnection(), searchID, packageToUpdate);
            Package packageFromDB = packageService.getOne(databaseService.getConnection(), searchID);
            Packages[Packages.IndexOf(Packages.SingleOrDefault(p => p.id == packageFromDB.id))] = packageFromDB;
        }

        public void RemovePackage(int searchID)
        {
            Package packageToRemoveFromList = packageService.getOne(databaseService.getConnection(), searchID);
            Packages.Remove(Packages.SingleOrDefault(p => p.id == packageToRemoveFromList.id));
            packageService.Delete(databaseService.getConnection(), searchID);
        }


        public ObservableCollection<Package> Packages
        {
            get
            {
                return packages;
            }
            set
            {
                packages = value;
            }
        }

    }
}
