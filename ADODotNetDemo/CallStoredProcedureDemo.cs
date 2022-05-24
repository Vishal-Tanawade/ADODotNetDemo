using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
namespace ADODotNetDemo
{
    internal class CallStoredProcedureDemo
    {
        class Employee
        {
            public int EmpID { get; set; }
            public string EmpName { get; set; }
            public string EmpLoc { get; set; }
        }

        class ClsProcedureCall
        {
            SqlConnection con;
            SqlCommand com;
            public ClsProcedureCall()
            {
                string mycon = ConfigurationManager.ConnectionStrings["myconstr"].ConnectionString;

                //con = new SqlConnection(@"Data Source=DESKTOP-BLC9DN3\MSSQLSERVER1;Initial Catalog=CTSDBADM21DF010;Integrated Security=true");
                con = new SqlConnection();
                con.ConnectionString = mycon;
                con.Open();
            }

        }
            static void Main(string[] args)
        {

        }
    }
}
