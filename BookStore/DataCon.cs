using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore
{
    public class DataCon
    {
        public static SqlConnection DataConnection { get; set; }
        public static void ConnectionDB(string server, string db)
        {
            string con = "Server="+server+";Database="+db+";Trusted_Connection=True;";
            DataConnection = new SqlConnection(con);
            DataConnection.Open();
        }
    }
}
