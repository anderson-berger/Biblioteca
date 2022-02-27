using BibliotecaMVC.Models.Contracts.Repositories;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace BibliotecaMVC.Models.Contexts
{
    public class ConnectionManager : IConnectionManager
    {
        private static string _connectionName = "Biblioteca";
        private static SqlConnection connection = null;

        public ConnectionManager(IConfiguration configuration)
        {
            string connStr = configuration.GetConnectionString(_connectionName);
            if (connection == null)
            {
                connection = new SqlConnection(connStr);
            }
        }

        public SqlConnection GetConnection()
        {
            return connection;
        }
    }
}
