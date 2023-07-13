using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCArchitecture
{
    internal class Connection
    {
        private static string _connectionString =
            "Server=ASUS-GL552;" + //bisa menggunakan Server
            "Database=kantor;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;";
        private static SqlConnection _conn;
        public static SqlConnection get()
        {
            try 
            {
                _conn = new SqlConnection(_connectionString);
                return _conn;
            }
            catch(Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
