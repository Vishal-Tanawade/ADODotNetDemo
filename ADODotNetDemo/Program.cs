using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;  //API
namespace ADODotNetDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FCE1AML;Initial Catalog=GN22ADMDNF001;Integrated Security=true");
            
            con.Open();
            SqlCommand com = new SqlCommand("select * from tblEmployee", con);
            SqlDataReader dr = com.ExecuteReader();
            Console.WriteLine("EMPLOYEE DETAILS ARE AS FOLLOWS :");
            Console.WriteLine("Without while loop:");
            int counter = 1;
            Console.WriteLine(dr.HasRows); //True

            if (dr.HasRows)
            {
                dr.Read();
                Console.WriteLine();
                Console.WriteLine("{0} Employee details :", counter);
                Console.WriteLine("EmpID   : {0}", dr[0].ToString());
                Console.WriteLine("Emp Name : {0}", dr["EmpName"].ToString());
                Console.WriteLine("Dept ID : {0}", dr["DeptID"].ToString());


                Console.WriteLine();
                counter++;

                dr.Read(); // it will read next record
                Console.WriteLine();
                Console.WriteLine("{0} Employee details :", counter);
                Console.WriteLine("EmpID   : {0}", dr[0].ToString());
                Console.WriteLine("Emp Name : {0}", dr["EmpName"].ToString());
                Console.WriteLine("Dept ID : {0}", dr["DeptID"].ToString());
                Console.WriteLine();
                counter++;
            }
            dr.Close();
            Console.Read();

        }
    }
}
