using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
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


    internal class ClsEmployee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public int DeptID { get; set; }

    }
}
