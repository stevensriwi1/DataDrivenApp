using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration; //web.config

namespace DataDrivenApp
{
    public class DBUtility
    {
        public static SqlConnection ConnectToSQLDB()
        {
            //get connection string from web config
            //string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
            string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionDD"].ConnectionString;

            //build connection 
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();

            return connection;
        }
    }
}