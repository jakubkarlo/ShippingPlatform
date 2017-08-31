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

        public IDbConnection getConnection()
        {
            MySqlConnectionStringBuilder connectionBuilder = new MySqlConnectionStringBuilder();

            connectionBuilder.Server = "localhost";
            connectionBuilder.UserID = "root";
            connectionBuilder.Password = "root";
            connectionBuilder.Database = "shippingplatform";


            string connectionString = connectionBuilder.GetConnectionString(true);

            IDbConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            return connection;



        }
      

    }
}
