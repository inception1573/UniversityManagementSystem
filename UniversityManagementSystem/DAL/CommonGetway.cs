using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
namespace UniversityManagementSystem.DAL
{
    public class CommonGetway
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        public  SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public string Quary { get; set; }
        public CommonGetway()
        {
            Connection = new SqlConnection(connectionString);
        }
    }
}