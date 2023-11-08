using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class StockDAO
    {
        private static string connectionString;
        private static SqlCommand command;
        private static SqlConnection connection;

        static StockDAO()
        {
            connectionString = @"Data Source=.;Initial Catalog=Factory_IO;Integrated Security=True";
            command = new SqlCommand();
            connection = new SqlConnection(connectionString);
            command.CommandType = System.Data.CommandType.Text;
            command.Connection = connection;
        }
    }
}
