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
    public class MessageLibrary
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["sql"].ConnectionString);
  
        public DataTable InsertMes(Messages obj)
        {

            SqlCommand cmd = new SqlCommand("Crear_Mensaje", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@remi", obj.remitente);
            cmd.Parameters.AddWithValue("@desti", obj.destinatario);
            cmd.Parameters.AddWithValue("@mensaje", obj.mensaje);
            cmd.Parameters.AddWithValue("@grupo", obj.grupo);
            cmd.Parameters.AddWithValue("@time", obj.NowTime);
            SqlDataAdapter dataAd = new SqlDataAdapter(cmd);
            DataTable dataTa = new DataTable();
            dataAd.Fill(dataTa);
            return dataTa;

        }


        public DataTable SearchMes(Messages obj)
        {

            SqlCommand cmd = new SqlCommand("Search_Message", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@remi", obj.remitente);
            cmd.Parameters.AddWithValue("@desti", obj.destinatario);
            SqlDataAdapter dataAd = new SqlDataAdapter(cmd);
            DataTable dataTa = new DataTable();
            dataAd.Fill(dataTa);
            return dataTa;

        }

    }
}
