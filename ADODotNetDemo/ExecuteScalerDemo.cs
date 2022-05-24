using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
namespace ADODotNetDemo
{
    internal class ExecuteScalerDemo
    {

        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-FCE1AML;Initial Catalog=GN22ADMDNF001;Integrated Security=true");
            con.Open();

            using (SqlCommand com = new SqlCommand("select * from tblEmployeeAutoID1", con))
            {
                //Executes the query, and returns the first column of the first row in the 
                //resultset returned by the query. Extra columns or rows are ignored.

                object obj = com.ExecuteScalar();

                Console.WriteLine(obj.ToString());
            }

            }
    }
}
