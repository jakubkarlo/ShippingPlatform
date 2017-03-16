using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;



namespace ShippingPlatform.Database
{
    public class DatabaseService
    {
        public Address Get(IDbConnection connection, int searchId)
        {
            return connection.Query<Address>(
            "SELECT * FROM addresses ",
            new { id = searchId }).FirstOrDefault();
        }

        public IEnumerable<Address> GetAll(IDbConnection connection)
        {
            return connection.Query<Address>(
            "SELECT * FROM addresses").ToList();
        }

        public IDbConnection getConnection()
        {
            MySqlConnectionStringBuilder connectionBuilder = new MySqlConnectionStringBuilder();

            ShippingPlatform.Database.Properties.Settings properties = Properties.Settings.Default;

            connectionBuilder.Server = properties.Server;
            connectionBuilder.UserID = properties.Username;
            connectionBuilder.Password = properties.Password;
            connectionBuilder.Database = properties.Database;

            string connectionString = connectionBuilder.GetConnectionString(true);

            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                return connection;
            }
            
            
        }

        public void openConnection(IDbConnection connection)
        {
            using (connection)
            {
                connection.Open();
            }
        }
      

    }
}
