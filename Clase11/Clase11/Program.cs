using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clase11
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             * INSTRUCTOR-403\SQLEXPRESS
             * 
             */
            String connStr = @"Server = INSTRUCTOR-403\SQLEXPRESS; Database = clase11; Trusted_Connection = True;";
            var conn = new System.Data.SqlClient.SqlConnection(connStr);
            conn.Open();
            conn.Close();
        }
    }
}
