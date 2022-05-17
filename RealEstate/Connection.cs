using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace RealEstate
{
    public class Connection
    {
        public static SqlConnection con;
        public static SqlDataReader dr;

        public static SqlConnection GetCon()
        {
            
                con = new SqlConnection();
                con.ConnectionString = @"Data Source = B-A-D-A-M-I\SQLEXPRESS; database = db_RealState; integrated security = SSPI";
                con.Open();
            return con;
        }

        public static SqlConnection CloseCon()
        {
            con.Close();
            return con;
        }
    }
}