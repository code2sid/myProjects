using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using Dapper.Extensions;


namespace Dapper
{
    public static class DBManager
    {
        public static IDbConnection GetDBConnection()
        {
            return new SqlConnection(WebConfigurationManager.ConnectionStrings["DefaultConnection"].ToString());
        }

        public static IDbConnection GetOpenConnection()
        {
            var connection = GetDBConnection();
            connection.Open();
            return connection;
        }
    }
}