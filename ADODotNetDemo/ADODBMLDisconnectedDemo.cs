using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADODotNetDemo
{
     class EmployeeDatabaseMLDisconnected
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder cmb;
        DataSet ds;
        DataTable dt;
        DataRow drow;
        public EmployeeDatabaseMLDisconnected()
        {
            string mycon = ConfigurationManager.ConnectionStrings["mycon1"].ConnectionString;
            con = new SqlConnection(mycon);
            //con.ConnectionString = mycon;
            da = new SqlDataAdapter("select * from tblEmployee", con);
            cmb = new SqlCommandBuilder(da);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            ds = new DataSet();
            da.Fill(ds, "JustEmployee");
        }

        public void AddEmployee(ClsEmployee Employee)
        {



            DataRow drow = ds.Tables["JustEmployee"].NewRow();
            drow[1] = Employee.EmpName;
            drow[2] = Employee.DeptID;

            ds.Tables["JustEmployee"].Rows.Add(drow);
            da.Update(ds, "JustEmployee");

            Console.WriteLine("Record inserted successfully:");


        }
        public void UpdateEmployee()
        {

            Console.Write("Enter your Employee ID : ");
            int EmpId = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter your choice 1: Update Name & 2: Update Department: ");
            int ch = Convert.ToInt32(Console.ReadLine());


            int i;
            switch (ch)
            {
                case 1:
                    Console.Write("Enter updated Name : ");
                    string EmpName = Console.ReadLine();

                    drow = ds.Tables["JustEmployee"].Rows.Find(EmpId);
                    if (drow != null)
                    {
                        drow[1] = EmpName;
                        da.Update(ds, "JustEmployee");
                        Console.WriteLine("Record update successfully:");
                    }
                    else
                    {
                        Console.WriteLine("Record not found:");
                    }

                    break;
                case 2:

                    Console.Write("Enter your new Department ID : ");
                    int DeptID = Convert.ToInt32(Console.ReadLine());
                    drow = ds.Tables["JustEmployee"].Rows.Find(EmpId);
                    if (drow != null)
                    {
                        drow[2] = DeptID;
                        da.Update(ds, "JustEmployee");
                        Console.WriteLine("Record update successfully:");
                    }
                    else
                    {
                        Console.WriteLine("Record not found:");
                    }
                    break;

                default:
                    Console.WriteLine("Invalid Choice:");
                    break;
            }

        }
        public void DeleteEmployee()
        {
            Console.Write("Enter Employee ID , whom you want to delete : ");
            int EmpId = Convert.ToInt32(Console.ReadLine());

            ds.Tables["JustEmployee"].Rows.Find(EmpId).Delete();
            da.Update(ds, "JustEmployee");
            Console.WriteLine("Record deleted successfully:");

        }
        public void AllEmployeeDetails()
        {
            ds.Tables["JustEmployee"].WriteXml("Employee.xml");
            int counter = 1;
            Console.WriteLine("EMPLOYEE DETAILS ARE AS FOLLOWS:");
            DataView Dview = ds.Tables["JustEmployee"].DefaultView;//new DataView(ds.Tables["JustEmployee"]);
            Dview.Sort = "EmpName";
            DataTable Dtable = new DataTable();
            Dtable = (DataTable)Dview.Table;

            //foreach (DataRow drow in ds.Tables["JustEmployee"].Rows)

            foreach (DataRow drow in Dtable.Rows)
            {

                Console.WriteLine();
                Console.WriteLine("{0} Employee details :", counter);
                Console.WriteLine("EmpID   : {0}", drow[0].ToString());
                Console.WriteLine("EmpName : {0}", drow["EmpName"].ToString());
                Console.WriteLine("DeptID  : {0}", drow["DeptID"].ToString());
                Console.WriteLine();
                counter++;

            }
        }

        ~EmployeeDatabaseMLDisconnected()
        {

        }

    }
    internal class ADODBMLDisconnectedDemo
    {
      
        


        static void Main(string[] args)
        {
            EmployeeDatabaseMLDisconnected databaseDCAML = new EmployeeDatabaseMLDisconnected();
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
                        databaseDCAML.AllEmployeeDetails();
                        break;
                    case 2:
                        Console.WriteLine("ENTER NEW EMPLOYEE DETAILS :");
                        ClsEmployee Employee = new ClsEmployee();
                        Console.Write("Enter Employee Name :");
                        Employee.EmpName = Console.ReadLine();
                        Console.Write("Enter Employee Dept ID :");
                        Employee.DeptID = Convert.ToInt32(Console.ReadLine());
                        databaseDCAML.AddEmployee(Employee);
                        break;
                    case 3:
                        databaseDCAML.UpdateEmployee();
                        break;
                    case 4:
                        databaseDCAML.DeleteEmployee();
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
