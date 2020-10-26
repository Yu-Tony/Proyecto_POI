using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Users;


namespace LogIn_SingIn
{
    public class DataLibrary
    {

        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        public DataTable UserLogin(UsersLibrary obj)
        {
            SqlCommand cmd = new SqlCommand("Login_User", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", obj.user);
            cmd.Parameters.AddWithValue("@pass", obj.pass);
            SqlDataAdapter dataAd = new SqlDataAdapter(cmd);
            DataTable dataTa = new DataTable();
            dataAd.Fill(dataTa);
            return dataTa;

        }

        public DataTable UserSignin(UsersLibrary obj)
        {
            SqlCommand cmd = new SqlCommand("Signin_User", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", obj.user);
            cmd.Parameters.AddWithValue("@pass", obj.pass);
            cmd.Parameters.AddWithValue("@email", obj.mail);
            SqlDataAdapter dataAd = new SqlDataAdapter(cmd);
            DataTable dataTa = new DataTable();
            dataAd.Fill(dataTa);
            return dataTa;

        }

        public DataTable TraerContactos()
        {
            SqlCommand cmd = new SqlCommand("select * from Users", conn);
            cmd.CommandType = CommandType.Text;
            SqlDataAdapter dataAd = new SqlDataAdapter(cmd);
            DataTable dataTa = new DataTable();
            dataAd.Fill(dataTa);
            return dataTa;

        }

        public DataTable CnhgUser(UsersLibrary objActual, UsersLibrary objNew)
        {

            SqlCommand cmd = new SqlCommand("Edit_User", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ActualUser", objActual.user);
            cmd.Parameters.AddWithValue("@NewUser", objNew.user);
            cmd.Parameters.AddWithValue("@email", objNew.mail);
            cmd.Parameters.AddWithValue("@pass", objNew.pass);
            SqlDataAdapter dataAd = new SqlDataAdapter(cmd);
            DataTable dataTa = new DataTable();
            dataAd.Fill(dataTa);
            return dataTa;

        }

        public DataTable DelUser(UsersLibrary obj)
        {

            SqlCommand cmd = new SqlCommand("Delete_User", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", obj.user);
            SqlDataAdapter dataAd = new SqlDataAdapter(cmd);
            DataTable dataTa = new DataTable();
            dataAd.Fill(dataTa);
            return dataTa;

        }


    }
}
