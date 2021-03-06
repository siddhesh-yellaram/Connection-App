using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace ConnectionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string conString = ConfigurationManager.ConnectionStrings["connection_string"].ConnectionString;
            SqlConnection sqlCon = new SqlConnection(conString);
            try
            { 
                sqlCon.Open();

                var serverName = sqlCon.DataSource;
                var database = sqlCon.Database;
                var state = sqlCon.State;
                var connectiontTimeout = sqlCon.ConnectionTimeout;

                Console.WriteLine("Server Name: " + serverName);
                Console.WriteLine("Database Name: " + database);
                Console.WriteLine("Connection State: " + state);
                Console.WriteLine("Connection Timeout: " + connectiontTimeout + " sec.");
                Console.WriteLine();

                string query = "Select * from Emp";
                SqlCommand cmd = new SqlCommand(query, sqlCon);
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " " + reader[3].ToString() + " " + reader[4].ToString() + " " + reader[5].ToString() + " " + reader[6].ToString() + " " + reader[7].ToString());
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                if(sqlCon.State == ConnectionState.Open)
                {
                    sqlCon.Close();
                }
            }
            Console.ReadLine();
        }
    }
}
