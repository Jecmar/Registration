using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dates;
using System.Data;
using System.Data.SqlClient;

namespace Business
{
   public class User
    {
        private Users users = new Users();
        private String _User;
        private String _Password;

        public String  Usuario
        {
            set
            {
                if(value == "USERNAME")
                {
                    _User = "You haven't entered your username";
                }
                else
                {
                    _User = value;
                }
            }
            get { return _User; }
        }

        public String Password
        {
            set
            {
                if(value == "PASSWORD")
                {
                    _Password = "You haven't entered your password";
                }
                else
                {
                    _Password = value;
                }
            }
            get { return _Password; }
        }

        public User() {}
        public SqlDataReader Log()
        {
            SqlDataReader Log;
            Log = users.LogIn(Usuario, Password);
            return Log;
        }

    }
}
