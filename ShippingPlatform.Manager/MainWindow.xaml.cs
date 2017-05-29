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
            PackagesViewModel packagesViewModel = new PackagesViewModel();
            OrdersViewModel ordersViewModel = new OrdersViewModel();
            comboViewModel = new CombiningViewModel(addrViewModel, clientsViewModel, packagesViewModel, ordersViewModel);

            addresses.DataContext = comboViewModel.addressesViewModel;
            clients.DataContext = comboViewModel.clientsViewModel;
            packages.DataContext = comboViewModel.packagesViewModel;
            orders.DataContext = comboViewModel.ordersViewModel;


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

        private void AddClientBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (client_email.Text == null || client_login.Text == null || client_password == null || client_addressID == null || client_orderID == null)
                {
                    throw new Exception();
                }

                Client clientToUpdate = new Client();
                clientToUpdate.emailAddress = client_email.Text;
                clientToUpdate.login = client_login.Text;
                clientToUpdate.password = client_password.Text;
                clientToUpdate.clientAddressID = Int32.Parse(client_addressID.Text);
                clientToUpdate.orderID = Int32.Parse(client_orderID.Text);
                comboViewModel.clientsViewModel.AddClient(clientToUpdate);
                MessageBoxResult messageBox = MessageBox.Show("New client inserted successfully!", "Success!");

            }
            catch (Exception)
            {
                MessageBoxResult messageBox = MessageBox.Show("Are your sure you filled everything properly? Does the address or order exist? What about leaving fields empty? Ensure yourself if it's ok!", "Error alert");
            }
        }

        private void UpdateClientBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (client_email.Text == null || client_login.Text == null || client_password == null || client_addressID == null || client_orderID == null)
                {
                    throw new Exception();
                }

                Client clientToUpdate = new Client();
                clientToUpdate.emailAddress = client_email.Text;
                clientToUpdate.login = client_login.Text;
                clientToUpdate.password = client_password.Text;
                clientToUpdate.clientAddressID = Int32.Parse(client_addressID.Text);
                clientToUpdate.orderID = Int32.Parse(client_orderID.Text);
                comboViewModel.clientsViewModel.UpdateClient(clientToUpdate, Int32.Parse(client_id.Text));
                MessageBoxResult messageBox = MessageBox.Show("New client updated successfully!", "Success!");

            }
            catch (Exception)
            {
                MessageBoxResult messageBox = MessageBox.Show("Are you sure you filled everything properly? Does the address or order exist? What about leaving fields empty? Ensure yourself if it's ok!", "Error alert");
            }
        }


        private void RemoveClientBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (client_id.Text == null)
                {
                    throw new Exception();
                }

                comboViewModel.clientsViewModel.RemoveClient(Int32.Parse(client_id.Text));
                MessageBoxResult messageBox = MessageBox.Show("Client removed successfully!", "Success!");

            }
            catch (Exception)
            {
                MessageBoxResult messageBox = MessageBox.Show("Please choose the client!", "Cannot delete");
            }
        }


        private void AddPackageBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (package_content == null || package_depth == null || package_height == null || package_orderID == null || package_weight == null || package_width == null)
                {
                    throw new Exception();
                }
                Package packageToUpdate = new Package();
                packageToUpdate.content = package_content.Text;
                packageToUpdate.depth = Int32.Parse(package_depth.Text);
                packageToUpdate.height = Int32.Parse(package_height.Text);
                packageToUpdate.orderID = Int32.Parse(package_orderID.Text);
                packageToUpdate.weight = Int32.Parse(package_weight.Text);
                packageToUpdate.width = Int32.Parse(package_width.Text);

                comboViewModel.packagesViewModel.AddPackage(packageToUpdate);


                MessageBoxResult messageBox = MessageBox.Show("New package added successfully!", "Success!");

            }
            catch (Exception)
            {
                MessageBoxResult messageBox = MessageBox.Show("Really? Package without all sufficient data? Fill all of the fields properly and try again", "Empty field alert");

            }
        }

        private void UpdatePackageBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (package_content == null || package_depth == null || package_height == null || package_orderID == null || package_weight == null || package_width == null)
                {
                    throw new Exception();
                }
                Package packageToUpdate = new Package();
                packageToUpdate.content = package_content.Text;
                packageToUpdate.depth = Int32.Parse(package_depth.Text);
                packageToUpdate.height = Int32.Parse(package_height.Text);
                packageToUpdate.orderID = Int32.Parse(package_orderID.Text);
                packageToUpdate.weight = Int32.Parse(package_weight.Text);
                packageToUpdate.width = Int32.Parse(package_width.Text);

                comboViewModel.packagesViewModel.UpdatePackage(packageToUpdate, Int32.Parse(package_id.Text));


                MessageBoxResult messageBox = MessageBox.Show("Package updated successfully!", "Success!");

            }
            catch (Exception)
            {
                MessageBoxResult messageBox = MessageBox.Show("You didn't fill the data properly! Maybe you put the characters instead of numbers in package dimensions? Fill all of the fields properly and try again", "Wrong data");

            }
        }


        private void RemovePackageBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (package_id.Text == null)
                {
                    throw new Exception();
                }

                comboViewModel.packagesViewModel.RemovePackage(Int32.Parse(package_id.Text));
                MessageBoxResult messageBox = MessageBox.Show("Package removed successfully!", "Success!");

            }
            catch (Exception)
            {
                MessageBoxResult messageBox = MessageBox.Show("Please choose the package", "Cannot delete");
            }
        }

        private void AddOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (order_clientAddressID.Text == null || order_created.Text == null || order_delivery.Text == null || order_pickup.Text == null || order_recipientAddressID.Text == null || order_ref.Text == null || order_status.Text == null)
                {
                    throw new Exception();
                }
                Order orderToUpdate = new Order();
                orderToUpdate.clientAddressID = Int32.Parse(order_clientAddressID.Text);
                orderToUpdate.createdDate = DateTime.ParseExact(order_created.Text, "M/d/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                orderToUpdate.deliveryDate = DateTime.ParseExact(order_delivery.Text, "M/d/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                orderToUpdate.pickupDate = DateTime.ParseExact(order_pickup.Text, "M/d/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                orderToUpdate.recipientAddressID = Int32.Parse(order_recipientAddressID.Text);
                orderToUpdate.referenceNumber = order_ref.Text;
                orderToUpdate.status = order_status.Text;
                comboViewModel.ordersViewModel.AddOrder(orderToUpdate);


                MessageBoxResult messageBox = MessageBox.Show("New order added successfully!", "Success!");

            }
            catch (Exception)
            {
                MessageBoxResult messageBox = MessageBox.Show("Fill all of the data properly. Focus on date formats", "Invalid data");

            }
        }

        private void UpdateOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (order_clientAddressID.Text == null || order_created.Text == null || order_delivery.Text == null || order_pickup.Text == null || order_recipientAddressID.Text == null || order_ref.Text == null || order_status.Text == null)
                {
                    throw new Exception();
                }
                Order orderToUpdate = new Order();
                orderToUpdate.clientAddressID = Int32.Parse(order_clientAddressID.Text);
                orderToUpdate.createdDate = DateTime.ParseExact(order_created.Text, "M/d/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                orderToUpdate.deliveryDate = DateTime.ParseExact(order_delivery.Text, "M/d/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                orderToUpdate.pickupDate = DateTime.ParseExact(order_pickup.Text, "M/d/yyyy h:mm:ss tt", System.Globalization.CultureInfo.InvariantCulture);
                orderToUpdate.recipientAddressID = Int32.Parse(order_recipientAddressID.Text);
                orderToUpdate.referenceNumber = order_ref.Text;
                orderToUpdate.status = order_status.Text;
                comboViewModel.ordersViewModel.UpdateOrder(orderToUpdate, Int32.Parse(order_id.Text));


                MessageBoxResult messageBox = MessageBox.Show("Order updated successfully!", "Success!");

            }
            catch (Exception)
            {
                MessageBoxResult messageBox = MessageBox.Show("Fill all of the data properly. Focus on date formats", "Invalid data");

            }
        }


        private void RemoveOrderBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (order_id.Text == null)
                {
                    throw new Exception();
                }

                comboViewModel.ordersViewModel.RemoveOrder(Int32.Parse(order_id.Text));
                MessageBoxResult messageBox = MessageBox.Show("Order removed successfully!", "Success!");

            }
            catch (Exception)
            {
                MessageBoxResult messageBox = MessageBox.Show("Please choose the order", "Cannot delete");
            }
        }



        private void FindOrderBtn_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
