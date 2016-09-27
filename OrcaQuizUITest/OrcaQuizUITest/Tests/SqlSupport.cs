using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrcaQuizUITest.Tests
{
    class SqlSupport
    {
        static string _clearDBsScript1 = @"EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'";
        static string _clearDBsScript2 = @"EXEC sp_MSForEachTable 'DELETE FROM ?'";
        static string _clearDBsScript3 = @"EXEC sp_MSForEachTable 'ALTER TABLE ? WITH CHECK CHECK CONSTRAINT ALL'";

        static string _connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["UiTestCon"].ConnectionString;

        internal static void CreateCommand() //string queryString
        {
            using (SqlConnection connection = new SqlConnection(
                       _connectionString))
            {
                SqlCommand command = new SqlCommand(_clearDBsScript1, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();
            }
        }

        

        internal static void ClearDb() //string queryString
        {
            using (SqlConnection connection = new SqlConnection(
                       _connectionString))
            {
                SqlCommand command = new SqlCommand(_clearDBsScript1, connection);
                command.Connection.Open();
                command.ExecuteNonQuery();

                SqlCommand command2 = new SqlCommand(_clearDBsScript2, connection);
              
                command2.ExecuteNonQuery();

                SqlCommand command3 = new SqlCommand(_clearDBsScript3, connection);
                
                command3.ExecuteNonQuery();


            }
        }
     
    }
}
