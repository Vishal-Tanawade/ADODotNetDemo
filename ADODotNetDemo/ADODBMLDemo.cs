using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;  //API
namespace ADODotNetDemo
{
    interface IEmployeeDatabaseML
    {
        void AllEmployeeDetails();
        void AddEmployee(ClsEmployee Employee);
        void UpdateEmployee();
        void DeleteEmployee();
    }
    class EmployeeDatabaseML : IEmployeeDatabaseML
    {

        SqlConnection con;
        SqlCommand com;
        SqlDataReader dr;
        public EmployeeDatabaseML()
        {
            con = new SqlConnection(@"Data Source=DESKTOP-FCE1AML;Initial Catalog=GN22ADMDNF001;Integrated Security = true");

            con.Open();
        }

        public void AddEmployee(ClsEmployee Employee)
        {
            throw new NotImplementedException();
        }

        public void AllEmployeeDetails()
        {
            //com = new SqlCommand("select * from tblEmployee", con);
            //Or
            com = new SqlCommand();
            com.CommandText = "select * from tblEmployee";
            com.Connection = con;

            dr = com.ExecuteReader();
            int counter = 1;
            Console.WriteLine("EMPLOYEE DETAILS ARE AS FOLLOWS:");
            while (dr.Read())
            {
                Console.WriteLine();
                Console.WriteLine("{0} Employee details :", counter);
                Console.WriteLine("EmpID   : {0}", dr[0].ToString());
                Console.WriteLine("EmpName : {0}", dr["EmpName"].ToString());
                Console.WriteLine("DeptID  : {0}", dr["DeptID"].ToString());
                Console.WriteLine();
                counter++;

            }
            dr.Close();
            com.Dispose(); // it will close connection after closing application
            // as we can close connection using con.close() but what if other function wants to use the connection
        }

        public void DeleteEmployee()
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee()
        {
            throw new NotImplementedException();
        }
    }
    internal class ADODBMLDemo
    {

        static void Main(string[] args)
        {


        }
    }
}
