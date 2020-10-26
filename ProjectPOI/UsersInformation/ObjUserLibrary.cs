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

        public DataTable _UsersNew(UsersLibrary _objU)
        {
            return objU.UserSignin(_objU);
        }

        public DataTable AllUsers()
        {
            return objU.TraerContactos();
        }

        public DataTable SearchUsers(UsersLibrary _objU)
        {
            return objU.TraerContacto(_objU);
        }

        public DataTable ChangeUser(UsersLibrary _objU, UsersLibrary _objUU)
        {
            return objU.CnhgUser(_objU, _objUU);
        }

        public DataTable DeleteUser(UsersLibrary _objU)
        {
            return objU.DelUser(_objU);
        }


    }
}
