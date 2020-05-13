using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace MessManagementSystemWebApp.Gateway
{
    public class Base
    {
        //public string ConnectionString { get; set; }
        public SqlConnection Connection { get; set; }
        public SqlDataReader Reader { get; set; }
        public SqlCommand Command { get; set; }

        public Base()
        {
            string ConnectionString = WebConfigurationManager.ConnectionStrings["MainConnectionString"].ConnectionString;

            Connection = new SqlConnection(ConnectionString);

           

        }
        
    }
}