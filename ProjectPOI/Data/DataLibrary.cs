﻿using System;
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


    }
}
