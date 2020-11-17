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

        public DataTable GetUserGp(Groups obj)
        {
            SqlCommand cmd = new SqlCommand("Login_User", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@user", obj.NombrePersona);
            cmd.Parameters.AddWithValue("@pass", obj.NombreGrupo);
            SqlDataAdapter dataAd = new SqlDataAdapter(cmd);
            DataTable dataTa = new DataTable();
            dataAd.Fill(dataTa);
            return dataTa;

        }
    }
}

//SELECT DISTINCT title,id FROM tbl_countries
