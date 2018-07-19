using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Dates
{
   public class Users
    {
        private Connect Connect = new Connect();
        private SqlDataReader Reader;

        public SqlDataReader LogIn(string User, string Password)
        {            
            SqlCommand Command = new SqlCommand("Logear",Connect.GetConnection());
            Command.CommandType = CommandType.StoredProcedure;
            Command.Parameters.AddWithValue("@User", User);
            Command.Parameters.AddWithValue("@Password", Password);
            Reader = Command.ExecuteReader();

            return Reader;
        }
    }
}
