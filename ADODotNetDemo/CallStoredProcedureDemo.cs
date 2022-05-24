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

            #region CALLING NON PARAMETERIZED STORED PROCEDURE
            public void CallNonParaProcedure()
            {


                com = new SqlCommand();
                com.CommandText = "spshowemployeedetails";
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = con;
                SqlDataReader dr = com.ExecuteReader();
                int count = 1;


                Console.WriteLine("Employees details are as follows :");
                while (dr.Read())
                {
                    Console.WriteLine("{0}. Employee details :", count);
                    Console.WriteLine("Employee ID        : {0}", dr["EmpID"].ToString());
                    Console.WriteLine("Employee Name      : {0}", dr["EmpName"].ToString());
                    Console.WriteLine("Employee DeptID    : {0}", dr["DeptID"].ToString());
                    Console.WriteLine("Employee Dept Name : {0}", dr["DeptName"].ToString());
                    Console.WriteLine("Employee Dept Loc  : {0}", dr["DeptLoc"].ToString());
                    count++;
                    Console.WriteLine();
                }
                dr.Close();
            }
            #endregion

        }
        static void Main(string[] args)
        {

        }
    }
}
