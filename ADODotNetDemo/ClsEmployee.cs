using System;
using System.Collections.Generic;
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


    internal class ClsEmployee
    {
        public int EmpID { get; set; }
        public string EmpName { get; set; }
        public int DeptID { get; set; }

    }
}
