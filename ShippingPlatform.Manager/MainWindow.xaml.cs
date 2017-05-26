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

        public MainWindow()
        {
            InitializeComponent();

            addresses.DataContext = new AddressesViewModel();
            //clients.DataContext = new ClientsViewModel();

        }

        private void AddAddressBtn_Click(object sender, RoutedEventArgs e)
        {

            try {
                if (ad_country.Text == null || ad_city.Text == null|| ad_street.Text == null || ad_housenumber.Text == null || ad_zipcode.Text == null)
                {
                    throw new Exception();
                }
                Address addressToAdd = new Address();
                addressToAdd.country = ad_country.Text;
                addressToAdd.city = ad_city.Text;
                addressToAdd.street = ad_street.Text;
                addressToAdd.housenumber = Int32.Parse(ad_housenumber.Text);
                addressToAdd.zipcode = ad_zipcode.Text;
                DatabaseService databaseService = new DatabaseService();
                AddressService addressService = new AddressService();
                addressService.Insert(databaseService.getConnection(), addressToAdd);
                MessageBoxResult messageBox = MessageBox.Show("New address inserted successfully!", "Success!");
            }
            catch(Exception)
            {
                MessageBoxResult messageBox = MessageBox.Show("Hola Hola! I don't like empty addresses! Fill all of the data fields and try again!", "Empty field alert");

            }


        }


    }
}
