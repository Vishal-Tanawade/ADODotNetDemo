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
    internal class MoreConceptsOnDataTable
    {
        static void Main(string[] args)
        {
         
                string mycon = ConfigurationManager.ConnectionStrings["mycon1"].ConnectionString;
                SqlConnection con = new SqlConnection(mycon);
                con.Open();
                SqlCommand com = new SqlCommand("select * from tblEmployee", con);

                DataTable dt = new DataTable();
                dt.Load(com.ExecuteReader()); 

                // Now create a DataView based on the DataTable.  
                // Sort and filter the data.  
                DataView Dview = dt.DefaultView;
                Dview.Sort = "EmpName";

                DataTable Dtable = new DataTable();
                Dtable = (DataTable)Dview.Table;

                Console.WriteLine(Dtable.Rows.Count);
                Console.WriteLine(Dtable.Columns.Count);
                foreach (DataRow drow in Dview.Table.Rows)
                {
                    Console.WriteLine($" {drow[0]}  {drow[1] }   {drow[2]}");
                }

                DataSet ds = new DataSet();
                ds.Tables.Add(dt);
                Console.WriteLine("Data from Dataset table:");

                foreach (DataRow drow in ds.Tables[0].Rows)
                {
                    Console.WriteLine($" {drow[0]}  {drow[1] }   {drow[2]}");
                }

            }
        }
}
