using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Dates
{
    class Connect
    {
        private SqlConnection Connection = new SqlConnection("Server=DELL-DESKTOP;DataBase=Login;Integrated Security=true");
        public SqlConnection GetConnection()
        {
            if(Connection.State == ConnectionState.Closed)
            {
                Connection.Open();
            }
            return Connection;
        }

        public SqlConnection GetOut()
        {
            if(Connection.State == ConnectionState.Open)
            {
                Connection.Close();
            }
            return Connection;
        }
    }
}
