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


using Newtonsoft.Json;

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
        static private string selected = "Unknown";

       


        //crear enlaces al listbox para agregar info del server
        private delegate void GiveItem(string s);

        //Para crear el objeto de usuario y revisarlo
        //User con los datos ingresados para login, a buscar
        UsersLibrary objUserU = new UsersLibrary();
        //User login para usar la funcion
        ObjUserLibrary objUserI = new ObjUserLibrary();
        ObjUserLibrary objUsersAll = new ObjUserLibrary();

        ObjUserLibrary MessageToSave = new ObjUserLibrary();
        ObjUserLibrary objMessagesAll = new ObjUserLibrary();

        //Bool para ver si se cambiara la contrase;a o no
        bool Pass = false;
        bool Conect = false;


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
                    string read = streamR.ReadLine();
                    Messages newMensaje = JsonConvert.DeserializeObject<Messages>(read);

                    if ((newMensaje.destinatario == nick && newMensaje.remitente == selected) || newMensaje.remitente == nick)
                    {
                        string Enviado = newMensaje.remitente + " : " + newMensaje.mensaje;
                        this.Invoke(new GiveItem(AddItem), Enviado);
                        //AddItem(Enviado);

                    }
                        

                    //this.Invoke(new GiveItem(AddItem), streamR.ReadLine());
                   
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

        /// Primera pantalla. Log In - Sign In

        private void Form1_Load(object sender, EventArgs e)
        {
            listBoxMessages.Location = new Point(-700, 68);
            WriteMessage.Location = new Point(-700, 523);
            Send_Button.Location = new Point(-700, 523);
            File_Button.Location = new Point(-700, 523);
            Emoji_Button.Location = new Point(-700, 523);
            label3.Location = new Point(130, -40);
            Password2_Login.Location=new Point(130, -20);
            SignIn_Button.Location = new Point(-80, 430);

            label4.Location = new Point(130, -20);
            Mail_LogIn.Location = new Point(130, -20);

            panel3.Location = new Point(-300, 0);
            panel4.Location = new Point(-1000, 0);
            panel5.Location = new Point(-300, 0);
            ContactList.Location = new Point(0, 70);

            label7.Location = new Point(40, -20);
            PasswordDisplay1.Location = new Point(40,-20);
            label8.Location = new Point(40, -20);
            PasswordDisplay2.Location = new Point(40, -20);
        }

        /// <summary>
        ///Button <c>Connect_LogIn_Click</c>
        ///  Redirige a la función de LogIn
        /// </summary> 
        private void Connect_LogIn_Click(object sender, EventArgs e)
        {
            LogIn();

        }

        /// <summary>
        ///Button <c>SignIn_Button_Click</c>
        ///  Redirige a la función de SignIn
        /// </summary> 
        private void SignIn_Button_Click(object sender, EventArgs e)
        {
            SignIn();
        }

        /// <summary>
        ///Button <c>Sing_In_Chng_Click</c>
        ///  Realiza animaciones para cambiar a la pantalla de Sign In
        /// </summary> 
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
            trans.add(Password2_Login, "Top", 290);

            trans.add(label4, "Top", 340);
            trans.add(Mail_LogIn, "Top", 370);

            trans.run();
            Sing_In_Chng.Visible = false;
            Log_In_Chng.Visible = true;

        }

        /// <summary>
        ///Button <c>Log_In_Chng_Click</c>
        ///  Realiza animaciones para cambiar a la pantalla de Log In
        /// </summary> 
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
            trans.add(Password2_Login, "Top", -20);

            trans.add(label4, "Top", -60);
            trans.add(Mail_LogIn, "Top", -40);

            trans.run();

            Sing_In_Chng.Visible = true;
            Log_In_Chng.Visible = false;

        }


        /// <summary>
        ///Funcion <c>LogIn</c>
        ///  Busca un usuario en la base de datos, entra si existe y manda un mensaje de error si no es así.
        ///  
        /// <code>
        /// <description>Crea una variable tipo DataTable.
        ///  Toma la informacion que se puso en las casillas de usuario y contraseña.
        ///  Revisa que esos datos existan en la tabla de usuarios y que sean correctos con la funcion "_Users".
        ///  Regresa el resultado de lo que encontró en la tabla "dataTa".
        ///  </description>
        /// </code>
        /// 
        /// <list type="bullet">
        /// <item>
        /// <term>IF</term>
        /// <description> Con un if revisa que haya encontrado algo viendo que la tabla resultante no esté en 0 (dataTa.Rows.Count > 0).
        /// Muestra un mensaje de bienvenida, toma el nombre del usuario para usarlo, se conecta al servidor y hace transiciones para ir a la pantalla de mensajes.
        /// Con un for muestra la lista de usuarios que están en la base de datos. 
        /// </description>
        /// </item>
        /// 
        /// 
        /// <item>
        /// <term>ELSE</term>
        /// <description> 
        /// Si ningún usuario en la base de datos hace match con lo que ingresó la persona en usuario y contraseña muestra un mensaje de que el usuario o contraseña está incorrecto.
        /// </description>
        /// </item>
        /// </list>
        /// </summary> 
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
                if(Conect==false)
                {
                    _Connect();
                    Conect = true;
                }

                TransitionToMessages();

                MostrarUsuarios();


            }

            else
            {
                MessageBox.Show("Usuario o contrasena incorrecta", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        /// <summary>
        ///Funcion <c>SignIn</c>
        ///  Busca si el usuario existe en la base de datos. Lo agrega si no existe y manda un error si ya existe
        ///  
        /// <code>
        /// <description>
        ///  </description>
        /// </code>
        /// 
        /// <list type="bullet">
        /// <item>
        /// <term>IF</term>
        /// <description>
        /// </description>
        /// </item>
        /// 
        /// 
        /// <item>
        /// <term>ELSE</term>
        /// <description> 
        /// </description>
        /// </item>
        /// </list>
        /// </summary> 
        void SignIn()
        {

            if (String.Equals(Password_Login.Text, Password2_Login.Text))
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

                    LogIn();
                }
            }
            else 
            {
                MessageBox.Show("La confirmación de contraseña es distinta al campo de contraseña", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        void TransitionToMessages()
        {
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
        }

        void TransitionToMain()
        {
            Transition trans = new Transition(new TransitionType_EaseInEaseOut(800));
            trans.add(listBoxMessages, "Left", -1000);
            trans.add(WriteMessage, "Left", -1000);
            trans.add(Send_Button, "Left", -1000);
            trans.add(File_Button, "Left", -1000);
            trans.add(Emoji_Button, "Left", -1000);
            trans.add(panel3, "Left", -1000);
            trans.add(ContactList, "Left", -1000);
            trans.add(panel4, "Left", -1000);
            trans.add(panel5, "Left", -1000);

            trans.add(label1, "Left", 129);
            trans.add(User_LogIn, "Left", 129);
            trans.add(label2, "Left", 129);
            trans.add(Password_Login, "Left", 129);
            trans.add(Connect_LogIn, "Left", 252);
            trans.add(panel1, "Left", 0);
            trans.add(panel2, "Left", 580);

            trans.run();
        }

        private void MostrarUsuarios()
        {
            //Mostrar usuarios
            DataTable Users = new DataTable();
            Users = objUsersAll.AllUsers();

            ContactList.Items.Clear();

            for (int i = 0; i < Users.Rows.Count; i++)
            {
                if (Users.Rows[i][0].ToString() != objUserU.user)
                {
                    ContactList.Items.Add(Users.Rows[i][0].ToString());
                }
                else
                {
                    objUserU.mail= Users.Rows[i][2].ToString();
                    UserDisplay.Text = Users.Rows[i][0].ToString();
                    MailDisplay.Text = Users.Rows[i][2].ToString();

                }
            }
        }

        private void GuardarMensajes(string msg)
        {
            DataTable Messages = new DataTable();
            Messages Search = new Messages();
            Search.remitente = nick;
            Search.destinatario = selected;
            Search.mensaje = CifradoCesar.Encipher(msg, 4);
            Messages = MessageToSave.InsertMessages(Search);

        }

        private void MostrarMensajes()
        {
            
            DataTable Messages = new DataTable();
            Messages Search = new Messages();
            Search.remitente = nick;
            Search.destinatario = selected;
            Messages = objMessagesAll.SearchMessages(Search);

            listBoxMessages.Items.Clear();

            for (int i = 0; i < Messages.Rows.Count; i++)
            {
                string MessageDecrypt = CifradoCesar.Decipher(Messages.Rows[i][2].ToString(), 4);
                listBoxMessages.Items.Add(Messages.Rows[i][0].ToString() + " : " + MessageDecrypt);
    
                
            }
        }

        private void MostrarBusqueda()
        {
            UsersLibrary UserSerach = new UsersLibrary();
            UserSerach.user = SearchContact.Text;
            DataTable Users = new DataTable();

            Users = objUsersAll.SearchUsers(UserSerach);

            ContactList.Items.Clear();

            for (int i = 0; i < Users.Rows.Count; i++)
            {
                if (Users.Rows[i][0].ToString() != objUserU.user)
                {
                    ContactList.Items.Add(Users.Rows[i][0].ToString());
                }
                else
                {
                    objUserU.mail = Users.Rows[i][2].ToString();
                    UserDisplay.Text = Users.Rows[i][0].ToString();
                    MailDisplay.Text = Users.Rows[i][2].ToString();

                }
            }
        }

        /// --------------------------------------------------------------Segunda pantalla. Mensajes

        private void File_Button_Click(object sender, EventArgs e)
        {

        }

        private void Emoji_Button_Click(object sender, EventArgs e)
        {

        }

  /// <summary>
        ///Button <c>Send_Button_Click</c>
        ///  Realiza un WriteLine por parte del usuario y limpia lo que estaba en el textbox para escribir
        /// </summary>  
        private void Send_Button_Click(object sender, EventArgs e)
        {

            //streamW.WriteLine(WriteMessage.Text);
            string msg = WriteMessage.Text;
            Messages mensaje = new Messages {remitente = nick, destinatario = selected, mensaje = msg };
            string result = JsonConvert.SerializeObject(mensaje);
            streamW.WriteLine(result);

            GuardarMensajes(msg);
            streamW.Flush();
            WriteMessage.Clear();
        }


        private void EditInfo_Button_Click(object sender, EventArgs e)
        {
            UserDisplay.ReadOnly = false;
            MailDisplay.ReadOnly = false;
            PasswordDisplay1.ReadOnly = false;
            PasswordDisplay2.ReadOnly = false;
        }

        private void SaveInfo_Button_Click(object sender, EventArgs e)
        {
            int op = 0;
            string DisplayMessage = " ";

            string ActName = objUserU.user;
            string ActMail = objUserU.mail;
            string ActPass = objUserU.pass;
            UsersLibrary objUserAct = new UsersLibrary();
            objUserAct.user = ActName;
            objUserAct.mail = ActMail;
            objUserAct.pass = ActPass;

            objUserU.user = UserDisplay.Text;
            objUserU.mail = MailDisplay.Text;
      

            if (Pass==true && PasswordDisplay1.Text != "")
            {
                if (String.Equals(PasswordDisplay1.Text, PasswordDisplay2.Text))
                {
                    objUserU.pass = PasswordDisplay1.Text;
                    if (!String.Equals(ActPass, objUserU.pass))
                    {
                        op = op + 5;
                    }
                        
                }
                else
                {
                    MessageBox.Show("La confirmación de contraseña es distinta al campo de contraseña", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    PasswordDisplay1.Clear();
                    PasswordDisplay2.Clear();
                    op = op + 10;

                }
            }
            else
            {
                if(Pass == true && PasswordDisplay1.Text == "")
                {
                    MessageBox.Show("La contraseña no puede quedarse en blanco", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    op = op + 10;
                }
            }

            if (!String.Equals(ActName, objUserU.user))
            {
                op = op + 1;
            }

            if (!String.Equals(ActMail, objUserU.mail))
            {
                op = op + 3;
            }

            switch (op)
            {
                case 1:
                    DisplayMessage = "¿Está seguro de realizar estos cambios?" + "\n" + "Usuario: " + UserDisplay.Text;
                    break;
                case 3:
                    DisplayMessage = "¿Está seguro de realizar estos cambios?" + "\n" + "Correo: " + MailDisplay.Text ;
                    break;
                case 4:
                    DisplayMessage = "¿Está seguro de realizar estos cambios?" + "\n" + "Usuario: " + UserDisplay.Text + "\n" + "Correo: " + MailDisplay.Text;
                    break;
                case 5:
                    DisplayMessage = "¿Está seguro de realizar estos cambios?" + "\n" + "Cambio de contraseña";
                    break;
                case 6:
                    DisplayMessage = "¿Está seguro de realizar estos cambios?" + "\n" + "Usuario: " + UserDisplay.Text + "\n" + "Y contraseña";
                    break;
                case 8:
                    DisplayMessage = "¿Está seguro de realizar estos cambios?" + "\n" + "Correo: " + MailDisplay.Text + "\n" + "Y contraseña";
                    break;
                case 9:
                    DisplayMessage = "¿Está seguro de realizar estos cambios?" + "\n" + "Usuario: " + UserDisplay.Text + "\n" + "Correo: " + MailDisplay.Text + "\n" + "Y contraseña";
                    break;
                default:
                    DisplayMessage = "No hay nada que guardar";
                    break;
            }

            if(op<10)
            {
                DialogResult dialogResult = MessageBox.Show(DisplayMessage, "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    DataTable dataTa = new DataTable();
                    objUserI.ChangeUser(objUserAct, objUserU);
                    dataTa = objUserI._Users(objUserU);
                    nick = objUserU.user;
                    PasswordDisplay1.Clear();
                    PasswordDisplay2.Clear();

                }
                else
                {

                    objUserU.user = ActName;
                    objUserU.mail = ActMail;
                    objUserU.pass = ActPass;

                }
            }
            else
            {
                objUserU.user = ActName;
                objUserU.mail = ActMail;
                objUserU.pass = ActPass;
            }

  


          

            MostrarUsuarios();
            UserDisplay.ReadOnly = true;
            MailDisplay.ReadOnly = true;
            PasswordDisplay1.ReadOnly = true;
            PasswordDisplay2.ReadOnly = true;

        }



        private void RefreshContacts_Click(object sender, EventArgs e)
        {
            if(SearchContact.Text!="")
            {
                MostrarBusqueda();
            }
            else
            {
                MostrarUsuarios();
            }
            
        }

        private void EditPassword_Button_Click(object sender, EventArgs e)
        {
            Transition trans = new Transition(new TransitionType_EaseInEaseOut(800));
            if (Pass==false)
            {
                trans.add(label7, "Top", 315);
                trans.add(PasswordDisplay1, "Top", 330);
                trans.add(label8, "Top", 360);
                trans.add(PasswordDisplay2, "Top", 380);
            }
            else 
            {
                trans.add(label7, "Top", -200);
                trans.add(PasswordDisplay1, "Top", -200);
                trans.add(label8, "Top", -200);
                trans.add(PasswordDisplay2, "Top", -200);
            }
           
            trans.run();
            Pass = !Pass;
        }

        private void DeleteUser_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Desea eliminar esta cuenta definitivamente?", "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                DataTable dataTa = new DataTable();
                objUserU.user = User_LogIn.Text;
                objUserU.pass = Password_Login.Text;
                objUserU.mail = Mail_LogIn.Text;
                objUserI.DeleteUser(objUserU);

                dataTa = objUserI._Users(objUserU);

                //TransitionToMain();
                this.Close();

            }

       
        }

        private int ImageNumber = 1;
        private void LoadImage()
        {
            if (ImageNumber == 4)
            {
                ImageNumber = 1;
            }
            Carousel.ImageLocation = string.Format(@"Images\{0}.jpg", ImageNumber);
            ImageNumber++;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            LoadImage();
        }

        private void ContactList_SelectedIndexChanged(object sender, EventArgs e)
        {
            selected = ContactList.GetItemText(ContactList.SelectedItem);
            listBoxMessages.Items.Clear();
            MostrarMensajes();


        }

        private void CreateGroup_Click(object sender, EventArgs e)
        {
            Form2 GW = new Form2();
            GW.ShowDialog();
        }
    }


}
