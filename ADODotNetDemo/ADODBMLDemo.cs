using System;
using System.Collections.Generic;
using System.Data;
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
            com = new SqlCommand();
            com.CommandText = "insert into tblEmployee values (@EmpName1,@DeptID1)"; 
            //com.CommandText = "insert into tblEmployee values ("+ Employee.EmpName+","+Employee.DeptID+")";

            com.Connection = con;

            com.Parameters.Add("@EmpName1", SqlDbType.VarChar).Value = Employee.EmpName;//"Abhishek's"
            com.Parameters.Add("@DeptID1", SqlDbType.Int).Value = Employee.DeptID;


            int i = com.ExecuteNonQuery();
            Console.WriteLine($" {i} Record inserted successfully:");
            com.Dispose();
        }
            public void AllEmployeeDetails()
        {

            //com = new SqlCommand("select * from tblEmployee", con);
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
            com.Dispose();
        }

        public void DeleteEmployee()
        {
            Console.Write("Enter Employee ID , whom you want to delete : ");
            int EmpId22 = Convert.ToInt32(Console.ReadLine());
            //com = new SqlCommand();
            //com.CommandText = "delete from tblEmployee where EmpId = @EmpId";
            //com.Connection = con;

            com = new SqlCommand("delete from tblEmployee where EmpId = @EmpId1", con);
            com.Parameters.Add("@EmpId1", SqlDbType.Int).Value = EmpId22;
            int i = com.ExecuteNonQuery();
            Console.WriteLine($" {i} Record deleted successfully:");
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
            EmployeeDatabaseML databaseML = new EmployeeDatabaseML();
            int ch;
            char yn;



            do
            {
                Console.WriteLine("---WELCOME EMPLOYEE MANAGEMENT PORTAL :");
                Console.WriteLine("1. DISPLAY ALL EMPLOYEE :");
                Console.WriteLine("2. ADD NEW EMPLOYEE :");
                Console.WriteLine("3. UPDATE EMPLOYEE :");
                Console.WriteLine("4. DELETE EMPLOYEE :");
                Console.WriteLine("5. EXIT PORTAL :");
                Console.Write("Enter your choice : ");
                ch = Convert.ToInt32(Console.ReadLine());
                switch (ch)
                {
                    case 1:
                        databaseML.AllEmployeeDetails();
                        break;
                    case 2:
                        Console.WriteLine("ENTER NEW EMPLOYEE DETAILS :");
                        ClsEmployee Employee = new ClsEmployee();
                        Console.Write("Enter Employee Name :");
                        Employee.EmpName = Console.ReadLine();
                        Console.Write("Enter Employee Dept ID :");
                        Employee.DeptID = Convert.ToInt32(Console.ReadLine());
                        databaseML.AddEmployee(Employee);
                        break;
                    case 3:
                        databaseML.UpdateEmployee();
                        break;
                    case 4:
                        databaseML.DeleteEmployee();
                        break;
                    case 5:
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Invalid Choice :");
                        break;
                }
                Console.Write("Do you want to continue..[Y/N] : ");
                yn = Convert.ToChar(Console.ReadLine().ToLower());
            } while (yn == 'y');

        }
    }
}
