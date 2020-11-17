using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Users;
using UsersInformation;

namespace ProjectPOI
{
    public partial class Form2 : Form
    {
        UsersLibrary objUserU = new UsersLibrary();
        //User login para usar la funcion
        ObjUserLibrary objUsersAll = new ObjUserLibrary();
        ObjUserLibrary objGroup = new ObjUserLibrary();

        public Form2(UsersLibrary objUser)
        {
            InitializeComponent();
            objUserU = objUser;
            MostrarUsuarios();
        }

        private void ChatMembersIn_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void MostrarUsuarios()
        {
            //Mostrar usuarios
            DataTable Users = new DataTable();
            Users = objUsersAll.AllUsers();

            ChatMembersIn.Items.Clear();

            for (int i = 0; i < Users.Rows.Count; i++)
            {
                if (Users.Rows[i][0].ToString() != objUserU.user)
                {
                    ChatMembersIn.Items.Add(Users.Rows[i][0].ToString());
                }
            }
        }

        private void CrearGrupoBtn_Click(object sender, EventArgs e)
        {
            string[] names= new string[10];
            int f = 0;
            foreach (var item in ChatMembersIn.SelectedItems)
            {
                names[f]=item.ToString();
                f++;
            }

            DataTable Messages = new DataTable();
            Groups Grupo = new Groups();
            Grupo.NombreGrupo = ChatNameIn.Text.ToString();
            
            if(Grupo.NombreGrupo != null)
            {
                for (int i = 0; names[i] != null; i++)
                {
                    Grupo.NombrePersona = names[i];
                    Messages = objGroup.CreateGroups(Grupo);

                }
                this.Close();
            }
           

            
           
            


        }
    }
}
