using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Users;

namespace Data
{
    public class GroupsLibrary
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
        public DataTable CreateGp(Groups obj)
        {
            SqlCommand cmd = new SqlCommand("Add_Group", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NomPers", obj.NombrePersona);
            cmd.Parameters.AddWithValue("@NomGrup", obj.NombreGrupo);
            SqlDataAdapter dataAd = new SqlDataAdapter(cmd);
            DataTable dataTa = new DataTable();
            dataAd.Fill(dataTa);
            return dataTa;

        }

        public DataTable GetUserGps(Groups obj)
        {
            SqlCommand cmd = new SqlCommand("Get_Group", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NomPers", obj.NombrePersona);
            SqlDataAdapter dataAd = new SqlDataAdapter(cmd);
            DataTable dataTa = new DataTable();
            dataAd.Fill(dataTa);
            return dataTa;

        }

        public DataTable GetUserFGps(Groups obj)
        {
            SqlCommand cmd = new SqlCommand("Get_UsersG", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@nomGpo", obj.NombreGrupo);
            SqlDataAdapter dataAd = new SqlDataAdapter(cmd);
            DataTable dataTa = new DataTable();
            dataAd.Fill(dataTa);
            return dataTa;

        }

        public DataTable TraerGrupo(Groups obj)
        {
            SqlCommand cmd = new SqlCommand("Search_Group", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@keyWord", obj.NombreGrupo);
            cmd.Parameters.AddWithValue("@User", obj.NombrePersona);
            SqlDataAdapter dataAd = new SqlDataAdapter(cmd);
            DataTable dataTa = new DataTable();
            dataAd.Fill(dataTa);
            return dataTa;

        }

        public DataTable BorrarDeGrupo(Groups obj)
        {
            SqlCommand cmd = new SqlCommand("Leave_Group", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NomGrup", obj.NombreGrupo);
            cmd.Parameters.AddWithValue("@NomPers", obj.NombrePersona);
            SqlDataAdapter dataAd = new SqlDataAdapter(cmd);
            DataTable dataTa = new DataTable();
            dataAd.Fill(dataTa);
            return dataTa;

        }

        public DataTable AgregarAGrupo(Groups obj)
        {
            SqlCommand cmd = new SqlCommand("Add_Member", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NomGrup", obj.NombreGrupo);
            cmd.Parameters.AddWithValue("@NomPers", obj.NombrePersona);
            SqlDataAdapter dataAd = new SqlDataAdapter(cmd);
            DataTable dataTa = new DataTable();
            dataAd.Fill(dataTa);
            return dataTa;

        }


    }
}

//SELECT DISTINCT title,id FROM tbl_countries
