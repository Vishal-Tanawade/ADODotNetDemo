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
    internal class SqlTransactionDemo
    {

        static void Main(string[] args)
        {
            SqlConnection con;

            string mycon = ConfigurationManager.ConnectionStrings["mycon1"].ConnectionString;

            con = new SqlConnection();
            con.ConnectionString = mycon;
            con.Open();

            //Create transaction reference object and start transaction 
            SqlTransaction MyTransaction = con.BeginTransaction();
            //Initialize the command object
            SqlCommand MyCommand = con.CreateCommand();
            //Assign transaction to command 
            MyCommand.Transaction = MyTransaction;
            MyCommand.CommandText
                = "insert into tblEmployee values ('Krishna',102)";
            MyCommand.ExecuteNonQuery();
            Console.WriteLine("One record inserted:");
            //Create save point
            MyTransaction.Save("SAVE1");
            Console.ReadLine();
            MyCommand.CommandText
                = "insert into tblEmployee values ('Aniket',102)";
            MyCommand.ExecuteNonQuery();
            Console.WriteLine("One record inserted:");
            //Create save point
            MyTransaction.Save("SAVE2");
            Console.ReadLine();
            Console.WriteLine("NOW LET'S ROLL BACK:");
            //roll back upto save point 1
            MyTransaction.Rollback("SAVE1");
            //Commit Transaction
            Console.ReadLine();
            MyTransaction.Commit();
            con.Close();

        }
    }
}
