using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Configuration;

namespace ADODotNetDemo
{
    internal class DirectTableDemo
    {
        static void Main(string[] args)
        {
            string mycon = ConfigurationManager.ConnectionStrings["mycon2"].ConnectionString;
            OleDbConnection conn = new OleDbConnection();
            // new OleDbConnection(@"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=GN22ADMDNF001;Data Source=DESKTOP-FCE1AML");
            conn.ConnectionString = mycon;
            conn.Open();
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "tblEmployeeWithSalary"; //this is table , with the help of oledb in one go we directly access whole table without writing any query , just we required table name
            cmd.CommandType = CommandType.TableDirect;

            OleDbDataReader dr = cmd.ExecuteReader();
            int count = 1;
            Console.WriteLine("Employees details are as follows :");
            while (dr.Read())
            {
                Console.WriteLine("{0}. Employee details :", count);
                Console.WriteLine("Employee ID         : {0}", dr["EmpID"].ToString());
                Console.WriteLine("Employee Name       : {0}", dr["EmpName"].ToString());
                Console.WriteLine("Employee DeptID     : {0}", dr["DeptID"].ToString());
                Console.WriteLine("Employee Salary     : {0}", dr["Salary"].ToString());

                count++;
                Console.WriteLine();

            }
            dr.Close();
            cmd.Dispose();
            conn.Close();

        }
    }
}
