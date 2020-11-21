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
using Data;

namespace UsersInformation
{
    public class ObjUserLibrary
    {
        DataLibrary objU = new DataLibrary();
       MessageLibrary objM = new MessageLibrary();
        GroupsLibrary objG = new GroupsLibrary();

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

        public DataTable EditStatus(UsersLibrary _objU)
        {
            return objU.EditarEstado(_objU);
        }

        public DataTable InsertMessages(Messages _objU)
        {
            return objM.InsertMes(_objU);
        }

        public DataTable SearchMessages(Messages _objU)
        {
            return objM.SearchMes(_objU);
        }

        public DataTable CreateGroups(Groups _objU)
        {
            return objG.CreateGp(_objU);
        }

        public DataTable GetUserGroups(Groups _objU)
        {
            return objG.GetUserGps(_objU);
        }

        public DataTable GetUsersFromGroups(Groups _objU)
        {
            return objG.GetUserFGps(_objU);
        }

        public DataTable SearchGroup(Groups _objU)
        {
            return objG.TraerGrupo(_objU);
        }

        public DataTable DeleteFromGroup(Groups _objU)
        {
            return objG.BorrarDeGrupo(_objU);
        }

        public DataTable AddToGroup(Groups _objU)
        {
            return objG.AgregarAGrupo(_objU);
        }




    }
}
