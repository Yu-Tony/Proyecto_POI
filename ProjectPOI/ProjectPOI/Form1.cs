using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;
using Transitions;

using Users;
using UsersInformation;


namespace ProjectPOI
{
    public partial class Form1 : Form
    {
        //sistemas para las conexiones
        static private NetworkStream stream;
        static private StreamWriter streamW;
        static private StreamReader streamR;
        //para hacer contacto entre clientes
        static private TcpClient client = new TcpClient();
        //identificar usuario
        static private string nick = "Unknown";
        //crear enlaces al listbox para agregar info del server
        private delegate void GiveItem(string s);

        //Para crear el objeto de usuario y revisarlo
        UsersLibrary objUserU = new UsersLibrary();
        ObjUserLibrary objUserI = new ObjUserLibrary();
        ObjUserLibrary objUsersAll = new ObjUserLibrary();

        private void AddItem(string s)
        {
            listBoxMessages.Items.Add(s);
        }

        public Form1()
        {
            InitializeComponent();
        }

        void Listen()
        {
            while (client.Connected)
            {
                try 
                {
                    this.Invoke(new GiveItem(AddItem), streamR.ReadLine());
                }
                catch
                {
                    MessageBox.Show("No se ha podido conectar al servidor");
                    Application.Exit();
                }
            }
        }

        void _Connect() 
        {
            try 
            {
                client.Connect("127.0.0.1", 8000);
                if (client.Connected)
                {
                    Thread t = new Thread(Listen);

                    stream = client.GetStream();
                    streamW = new StreamWriter(stream);
                    streamR = new StreamReader(stream);

                    streamW.WriteLine(nick);
                    streamW.Flush();

                    t.Start();
                }
                else 
                {
                    MessageBox.Show("Servidor no disponible");
                }
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Servidor no disponible");
                Application.Exit();
            }
        }


        private void Connect_LogIn_Click(object sender, EventArgs e)
        {
            LogIn();

        }

        private void SignIn_Button_Click(object sender, EventArgs e)
        {
            SignIn();
        }

        private void Sing_In_Chng_Click(object sender, EventArgs e)
        {

            Transition trans = new Transition(new TransitionType_EaseInEaseOut(800));
            trans.add(label1, "Top", 100);
            trans.add(User_LogIn, "Top", 130);

            trans.add(label2, "Top", 180);
            trans.add(Password_Login, "Top", 210);

            trans.add(Connect_LogIn, "Left", -1000);
            trans.add(SignIn_Button, "Left", 245);

            trans.add(label3, "Top", 260);
            trans.add(Mail_LogIn, "Top", 290);

            trans.run();
            Sing_In_Chng.Visible = false;
            Log_In_Chng.Visible = true;

        }

        private void Log_In_Chng_Click(object sender, EventArgs e)
        {
            Transition trans = new Transition(new TransitionType_EaseInEaseOut(800));

            trans.add(label1, "Top", 130);
            trans.add(User_LogIn, "Top", 170);

            trans.add(label2, "Top", 220);
            trans.add(Password_Login, "Top", 260);

            trans.add(Connect_LogIn, "Left", 245);
            trans.add(SignIn_Button, "Left", -1000);

            trans.add(label3, "Top", -40);
            trans.add(Mail_LogIn, "Top", -20);

            trans.run();

            Sing_In_Chng.Visible = true;
            Log_In_Chng.Visible = false;

        }


        private void Send_Button_Click(object sender, EventArgs e)
        {
            streamW.WriteLine(WriteMessage.Text);
            streamW.Flush();
            WriteMessage.Clear();
        }

    

        private void Form1_Load(object sender, EventArgs e)
        {
            listBoxMessages.Location = new Point(-700, 68);
            WriteMessage.Location = new Point(-700, 523);
            Send_Button.Location = new Point(-700, 523);
            File_Button.Location = new Point(-700, 523);
            Emoji_Button.Location = new Point(-700, 523);
            label3.Location = new Point(130, -40);
            Mail_LogIn.Location=new Point(130, -20);
            SignIn_Button.Location = new Point(-80, 350);
            panel3.Location = new Point(-300, 0);
            panel4.Location = new Point(-1000, 0);
            panel5.Location = new Point(-300, 0);
            ContactList.Location = new Point(0, 70);
        }

        void LogIn()
        {
            DataTable dataTa = new DataTable();
            objUserU.user = User_LogIn.Text;
            objUserU.pass = Password_Login.Text;

            dataTa = objUserI._Users(objUserU);


            if (dataTa.Rows.Count > 0)
            {
                MessageBox.Show("Bienvenido" + dataTa.Rows[0][0].ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                nick = User_LogIn.Text;
                _Connect();

                Transition trans = new Transition(new TransitionType_EaseInEaseOut(800));
                trans.add(label1, "Left", 1000);
                trans.add(User_LogIn, "Left", 1000);
                trans.add(label2, "Left", 1000);
                trans.add(Password_Login, "Left", 1000);
                trans.add(Connect_LogIn, "Left", 1000);
                trans.add(panel1, "Left", 1200);
                trans.add(panel2, "Left", 1000);

                trans.add(listBoxMessages, "Left", 25);
                trans.add(WriteMessage, "Left", 25);
                trans.add(Send_Button, "Left", 455);
                trans.add(File_Button, "Left", 520);
                trans.add(Emoji_Button, "Left", 585);
                trans.add(panel3, "Left", 0);
                trans.add(ContactList, "Left", 15);
                trans.add(panel4, "Left", 250);
                trans.add(panel5, "Left", 930);

                trans.run();

            DataTable Users = new DataTable();
            Users = objUsersAll.AllUsers();

            for (int i = 0; i < Users.Rows.Count; i++)
            {
                    if (Users.Rows[i][0].ToString() != objUserU.user)
                    {
                        ContactList.Items.Add(Users.Rows[i][0].ToString());
                    }
                }
        }

            else
            {
                MessageBox.Show("Usuario o contrasena incorrecta", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
}

        void SignIn()
        {
            DataTable dataTa = new DataTable();
            objUserU.user = User_LogIn.Text;
            objUserU.pass = Password_Login.Text;
            objUserU.mail = Mail_LogIn.Text;

            dataTa = objUserI._Users(objUserU);


            if (dataTa.Rows.Count > 0)
            {
       
                MessageBox.Show("Usuario ya existente", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                objUserI._UsersNew(objUserU);
                dataTa = objUserI._Users(objUserU);

                MessageBox.Show("Bienvenido" + dataTa.Rows[0][0].ToString(), "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                nick = User_LogIn.Text;
                _Connect();

                Transition trans = new Transition(new TransitionType_EaseInEaseOut(800));
                trans.add(label1, "Left", 1000);
                trans.add(User_LogIn, "Left", 1000);
                trans.add(label2, "Left", 1000);
                trans.add(Password_Login, "Left", 1000);
                trans.add(Connect_LogIn, "Left", 1000);
                trans.add(panel1, "Left", 1000);
                trans.add(panel2, "Left", 1000);


                trans.add(listBoxMessages, "Left", 180);
                trans.add(WriteMessage, "Left", 180);
                trans.add(Send_Button, "Left", 610);
                trans.add(File_Button, "Left", 675);
                trans.add(Emoji_Button, "Left", 740);
                trans.add(panel3, "Left", 0);
                trans.add(ContactList, "Left", 0);
                // trans.add(panel4, "Left", 300);
                trans.run();
            }
        }

        private void File_Button_Click(object sender, EventArgs e)
        {

        }

        private void Emoji_Button_Click(object sender, EventArgs e)
        {

        }


    }
}
