using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Configuration;
using System.Data.SqlClient;
using System.Data;


using Users;
using LogIn_SingIn;

namespace UsersInformation
{
    public class ObjUserLibrary
    {
        DataLibrary objU = new DataLibrary();
        public DataTable _Users(UsersLibrary _objU)
        {
            return objU.UserLogin(_objU);
        }
    }
}
