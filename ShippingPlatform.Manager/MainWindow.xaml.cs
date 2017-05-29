using ShippingPlatform.Database;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
using System.ComponentModel;

namespace ShippingPlatform.Manager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private CombiningViewModel comboViewModel;

        public MainWindow()
        {
            InitializeComponent();

            AddressesViewModel addrViewModel = new AddressesViewModel();
            ClientsViewModel clientsViewModel = new ClientsViewModel();
            comboViewModel = new CombiningViewModel(addrViewModel, clientsViewModel);

            addresses.DataContext = comboViewModel.addressesViewModel;
            clients.DataContext = comboViewModel.clientsViewModel;


        }

        private void AddAddressBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (ad_country.Text == null || ad_city.Text == null || ad_street.Text == null || ad_housenumber.Text == null || ad_zipcode.Text == null)
                {
                    throw new Exception();
                }
                Address addressToAdd = new Address();
                addressToAdd.country = ad_country.Text;
                addressToAdd.city = ad_city.Text;
                addressToAdd.street = ad_street.Text;
                addressToAdd.housenumber = Int32.Parse(ad_housenumber.Text);
                addressToAdd.zipcode = ad_zipcode.Text;
                comboViewModel.addressesViewModel.AddAddress(addressToAdd);
               

                MessageBoxResult messageBox = MessageBox.Show("New address inserted successfully!", "Success!");
                addresses.DataContext = comboViewModel.addressesViewModel;
            }
            catch (Exception)
            {
                MessageBoxResult messageBox = MessageBox.Show("Hola Hola! I don't like empty addresses! Fill all of the data fields and try again!", "Empty field alert");

            }


        }

        private void UpdateAddressBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (ad_country.Text == null || ad_city.Text == null || ad_street.Text == null || ad_housenumber.Text == null || ad_zipcode.Text == null)
                {
                    throw new Exception();
                }
                Address addressToUpdate = new Address();
                addressToUpdate.country = ad_country.Text;
                addressToUpdate.city = ad_city.Text;
                addressToUpdate.street = ad_street.Text;
                addressToUpdate.housenumber = Int32.Parse(ad_housenumber.Text);
                addressToUpdate.zipcode = ad_zipcode.Text;
                comboViewModel.addressesViewModel.UpdateAddress(addressToUpdate, Int32.Parse(ad_id.Text));
               
                


                MessageBoxResult messageBox = MessageBox.Show("Address updated successfully!", "Success!");
            }
            catch (Exception)
            {
                MessageBoxResult messageBox = MessageBox.Show("Cannot update! Check if all textboxes are filled and if housenumber doesn't contain letters instead of numbers! Or maybe you tried to update non-existing address?", "Cannot update");

            }
        }

        private void RemoveAddressBtn_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (ad_id.Text == null)
                {
                    throw new Exception();
                }

                comboViewModel.addressesViewModel.DeleteAddress(Int32.Parse(ad_id.Text));
                MessageBoxResult messageBox = MessageBox.Show("Address removed successfully!", "Success!");
            }
            catch (Exception)
            {
                MessageBoxResult messageBox = MessageBox.Show("Please choose the address!", "Cannot delete");

            }

        }
    }
}
