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
    public partial class Form3 : Form
    {
        DataTable Users = new DataTable();
        private static string GroupName;
        ObjUserLibrary objGroup = new ObjUserLibrary();
        public Form3(DataTable AllUsers, string Group)
        {
            Users = AllUsers;
            GroupName = Group;
            InitializeComponent();
            
        }

        private void Form3_Load(object sender, EventArgs e)
        {

            ChatNameOut.Text = GroupName;

            Groups GG = new Groups();
            GG.NombreGrupo = GroupName;
            DataTable GroupsDT = new DataTable();
            ObjUserLibrary GetGroups = new ObjUserLibrary();
            GroupsDT = GetGroups.GetUsersFromGroups(GG);
            bool different = true;

            for (int i = 0; i < Users.Rows.Count; i++)
            {
                different = true;
                for (int j = 0; j < GroupsDT.Rows.Count; j++)
                {
                    if (Users.Rows[i][0].ToString() == GroupsDT.Rows[j][0].ToString())
                    {
                        different = false;
                    }
                    
                }
                if (different == true)
                {
                    ChatMembersAdd.Items.Add(Users.Rows[i][0].ToString());
                }

            }

        }

        private void AddMembersBtn_Click(object sender, EventArgs e)
        {
            

            DialogResult dialogResult =  MessageBox.Show("¿Está seguro de añadir estos integrantes al grupo?", "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                DataTable Personas = new DataTable();
                Groups Grupo = new Groups();
                Grupo.NombreGrupo = GroupName;

                foreach (var item in ChatMembersAdd.SelectedItems)
                {
                    Grupo.NombrePersona = item.ToString();
                    Personas = objGroup.AddToGroup(Grupo);
                }

                 this.Close();

            }

           

        }
    }
}
