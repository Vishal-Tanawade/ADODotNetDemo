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
                string mycon = ConfigurationManager.ConnectionStrings["mycon1"].ConnectionString;

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


            #region CALLING PARAMETERIZED STORED PROCEDURE
            public void CallParaProcedure()
            {
                Employee Emp = new Employee()
                {
                    EmpName = "Abhishek Sharma",
                    EmpLoc = "Delhi"
                };
                com = new SqlCommand();
                com.CommandText = "SPAddEmployeeAutoID";
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = con;
                com.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = Emp.EmpName;
                com.Parameters.Add("@EmpLoc", SqlDbType.VarChar).Value = Emp.EmpLoc;
                int i = com.ExecuteNonQuery();
                Console.WriteLine("{0}. record inserted :", i);
            }
            #endregion

            #region CALLING PARAMETERIZED STORED PROCEDURE WITH OUT TYPE PARAMETER
            public void CallParaProcedureWithOutpara()
            {
                Employee Emp = new Employee()
                {
                    EmpID = 1011,
                    EmpName = "Abhishek",
                    EmpLoc = "Delhi"
                };

                com = new SqlCommand();
                com.CommandText = "spouttypeselectEmployee";
                com.CommandType = CommandType.StoredProcedure;
                com.Connection = con;
                com.Parameters.Add("@EmpID", SqlDbType.Int).Value = Emp.EmpID;  //@EmpID should be same as in table
                com.Parameters.Add("@EmpName", SqlDbType.VarChar).Value = Emp.EmpName;
                SqlParameter OutP =
                    new SqlParameter("@CurrentDateTime", SqlDbType.DateTime);
                OutP.Direction = ParameterDirection.Output;
                com.Parameters.Add(OutP);
                SqlDataReader dr = com.ExecuteReader();
                if (dr.HasRows)
                {
                    dr.Read();
                    Console.WriteLine($"EmpId:{dr[0].ToString()} EmpName :{dr[1].ToString()} DeptID :{dr[2].ToString()} ");
                    dr.Close();
                }

                Console.WriteLine($"Transaction done successfully at {OutP.Value}");
                com.Dispose();
            }
            #endregion
        }
        static void Main(string[] args)
        {
            ClsProcedureCall clsProcedureCall = new ClsProcedureCall();
            //clsProcedureCall.CallNonParaProcedure();
            clsProcedureCall.CallParaProcedure();

            //clsProcedureCall.CallParaProcedureWithOutpara();


        }
    }
}
