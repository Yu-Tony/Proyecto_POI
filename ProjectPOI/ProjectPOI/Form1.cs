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

using System.Net.Mail;
using System.Net;

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

        ObjUserLibrary GetGroups = new ObjUserLibrary();
        ObjUserLibrary UsersFromGroup = new ObjUserLibrary();

        /// <summary>
        /// Contiene todos los usuarios que estan disponibles
        /// </summary>
        DataTable Users = new DataTable();
        /// <summary>
        /// Todos los grupos que tiene ese usuario
        /// </summary>
        DataTable GroupsDT = new DataTable();

        //Bool para ver si se cambiara la contrase;a o no
        bool Pass = false;
        bool Conect = false;

        private void SomeoneDisconnected(string s)
        {
            MostrarUsuarios();
        }
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
                    //MessageBox.Show(read);
                    bool message = false;


                    if (read != (objUserU.user + "Disconnected") && read != (objUserU.user + "Connected"))
                    {
                        this.Invoke(new GiveItem(SomeoneDisconnected), read);


                        if (read.Contains("{") == true)
                        {
                            message = true;
                        }


                        if (message == true)
                        {
                            Messages newMensaje = JsonConvert.DeserializeObject<Messages>(read);
                            string gp = "";
                            bool IsInGroup = false;
                            for (int i = 0; i < GroupsDT.Rows.Count; i++)
                            {

                                if (GroupsDT.Rows[i][0].ToString() == selected)
                                {
                                    IsInGroup = true;

                                }

                            }

                            if ((newMensaje.destinatario == nick && newMensaje.remitente == selected) || newMensaje.remitente == nick || (IsInGroup == true && newMensaje.grupo != null))
                            {
                                string Enviado = newMensaje.remitente + " : " + newMensaje.mensaje;
                                this.Invoke(new GiveItem(ConvertText), Enviado);
                                //AddItem(Enviado);

                            }

                            // this.Invoke(new GiveItem(AddItem), streamR.ReadLine());
                        }


                    }

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
                    objUserU.status = "Connected";
                    objUsersAll.EditStatus(objUserU);
                    streamW.WriteLine(objUserU.user + objUserU.status);
                    streamW.Flush();
                }
                else
                {
                    MessageBox.Show("Servidor no disponible");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Servidor no disponible");
                Application.Exit();
            }
        }

        /// Primera pantalla. Log In - Sign In

        private void Form1_Load(object sender, EventArgs e)
        {
            //listBoxMessages.Location = new Point(-700, 68);
            //WriteMessage.Location = new Point(-700, 523);
            //Send_Button.Location = new Point(-700, 523);
            //File_Button.Location = new Point(-700, 523);
            //Emoji_Button.Location = new Point(-700, 523);
            label3.Location = new Point(130, -40);
            Password2_Login.Location = new Point(130, -20);
            SignIn_Button.Location = new Point(-80, 430);

            label4.Location = new Point(130, -20);
            Mail_LogIn.Location = new Point(130, -20);

            panel4.Location = new Point(-1500, 0);

            listViewContact.Location = new Point(0, 70);


            label7.Location = new Point(40, -20);
            PasswordDisplay1.Location = new Point(40, -20);
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
                if (Conect == false)
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
                    EnviarCorreo();
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

            //trans.add(listBoxMessages, "Left", 25);
            //trans.add(WriteMessage, "Left", 25);
            //trans.add(Send_Button, "Left", 455);
            //trans.add(File_Button, "Left", 520);
            //trans.add(Emoji_Button, "Left", 585);

            trans.add(panel4, "Left", 0);


            trans.run();
        }

        private void EnviarCorreo()
        {
            SmtpClient client = new SmtpClient("smtp.gmail.com");
            MailMessage email = new MailMessage();

            email.From = new MailAddress("MensajeriaPOI@gmail.com");
            email.To.Add(objUserU.mail);
            email.Subject = "Bienvenido/a";
            email.Body = "Gracias por usar nuestro servicio de mensajeria" + " " + objUserU.user;

            client.Port = 587;
            client.Credentials = new NetworkCredential("MensajeriaPOI@gmail.com", "POIMessages1");
            client.EnableSsl = true;

            client.Send(email);
        }

        private void MostrarUsuarios()
        {
            //Mostrar usuarios
            Users = objUsersAll.AllUsers();

            Groups GG = new Groups();
            GG.NombrePersona = objUserU.user;

            GroupsDT = GetGroups.GetUserGroups(GG);

            listViewContact.Items.Clear();



            for (int i = 0; i < Users.Rows.Count; i++)
            {
                if (Users.Rows[i][0].ToString() != objUserU.user)
                {
                    //ContactList.Items.Add(Users.Rows[i][0].ToString() + " : ");
                    //ConnectedList.Items.Add(Users.Rows[i][3].ToString());

                    string[] row = { Users.Rows[i][0].ToString(), Users.Rows[i][3].ToString() };
                    var listViewItem = new ListViewItem(row);
                    listViewContact.Items.Add(listViewItem);

                }
                else
                {
                    objUserU.mail = Users.Rows[i][2].ToString();
                    UserDisplay.Text = Users.Rows[i][0].ToString();
                    MailDisplay.Text = Users.Rows[i][2].ToString();

                }
            }

            for (int i = 0; i < GroupsDT.Rows.Count; i++)
            {

                //ContactList.Items.Add(GroupsDT.Rows[i][0].ToString());
                string[] row = { GroupsDT.Rows[i][0].ToString(), "" };
                var listViewItem = new ListViewItem(row);
                listViewContact.Items.Add(listViewItem);

            }
        }

        private void GuardarMensajes(string msg)
        {

            DataTable Messages = new DataTable();
            Messages Search = new Messages();
            Search.remitente = nick;
            Search.mensaje = CifradoCesar.Encipher(msg, 4);

            DateTime myDateTime = DateTime.Now;
            //string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

            Search.NowTime = myDateTime;

            for (int i = 0; i < Users.Rows.Count; i++)
            {
                if (Users.Rows[i][0].ToString() == selected)
                {
                    Search.grupo = "";
                    Search.destinatario = selected;
                    Messages = MessageToSave.InsertMessages(Search);
                }
            }

            for (int i = 0; i < GroupsDT.Rows.Count; i++)
            {
                if (GroupsDT.Rows[i][0].ToString() == selected)
                {
                    //DataTable UsersFromGrp = new DataTable();
                    //Groups UsersG = new Groups();
                    //UsersG.NombreGrupo = selected;
                    Search.grupo = selected;
                    Search.destinatario = "";
                    Messages = MessageToSave.InsertMessages(Search);
                    //UsersFromGrp = UsersFromGroup.GetUsersFromGroups(UsersG);
                    //Search.grupo = selected;
                    //for (int j = 0; j < UsersFromGrp.Rows.Count; j++)
                    //{
                    //    Search.destinatario = UsersFromGrp.Rows[j][0].ToString();
                    //    Messages = MessageToSave.InsertMessages(Search);
                    //}



                }
            }



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
                string Decifrado = (Messages.Rows[i][0].ToString() + " : " + MessageDecrypt);
                ConvertText(Decifrado);


            }
        }

        private void MostrarBusqueda()
        {
            UsersLibrary US = new UsersLibrary();
            US.user = SearchContact.Text;
            DataTable UsersSearch = new DataTable();
            UsersSearch = objUsersAll.SearchUsers(US);



            listViewContact.Items.Clear();

            for (int i = 0; i < UsersSearch.Rows.Count; i++)
            {
                if (UsersSearch.Rows[i][0].ToString() != objUserU.user)
                {
                    //ContactList.Items.Add(UsersSearch.Rows[i][0].ToString());


                    string[] row = { UsersSearch.Rows[i][0].ToString(), UsersSearch.Rows[i][3].ToString() };
                    var listViewItem = new ListViewItem(row);
                    listViewContact.Items.Add(listViewItem);
                }
                else
                {
                    objUserU.mail = UsersSearch.Rows[i][2].ToString();
                    UserDisplay.Text = UsersSearch.Rows[i][0].ToString();
                    MailDisplay.Text = UsersSearch.Rows[i][2].ToString();

                }
            }

            Groups GS = new Groups();
            GS.NombreGrupo = SearchContact.Text;
            GS.NombrePersona = objUserU.user;
            DataTable GpSearch = new DataTable();
            GpSearch = objUsersAll.SearchGroup(GS);

            for (int i = 0; i < GpSearch.Rows.Count; i++)
            {
                if (GpSearch.Rows[i][0].ToString() != objUserU.user)
                {
                    //ContactList.Items.Add(GpSearch.Rows[i][0].ToString());

                    string[] row = { GpSearch.Rows[i][0].ToString(), " " };
                    var listViewItem = new ListViewItem(row);
                    listViewContact.Items.Add(listViewItem);
                }
            }
        }

        /// --------------------------------------------------------------Segunda pantalla. Mensajes
        /// 

        public class Emoji
        {
            readonly int[] codes;
            public Emoji(int[] codes)
            {
                this.codes = codes;
            }

            public Emoji(int code)
            {
                codes = new int[] { code };
            }

            public override string ToString()
            {
                if (codes == null)
                    return string.Empty;

                var sb = new StringBuilder(codes.Length);

                foreach (var code in codes)
                    sb.Append(Char.ConvertFromUtf32(code));

                return sb.ToString();
            }
        }
        void ConvertText(string s)
        {
            Emoji Emoji1 = new Emoji(0x1F604);
            Emoji Emoji2 = new Emoji(0x1F603);
            Emoji Emoji3 = new Emoji(0x1F602);
            Emoji Emoji4 = new Emoji(0x1F606);
            Emoji Emoji5 = new Emoji(0x1F609);
            Emoji Emoji6 = new Emoji(0x1F61B);
            Emoji Emoji7 = new Emoji(0x2764);


            string a = s;

            if (s.Contains(":)"))
            {
                a = s.Replace(":)", Emoji1.ToString());
            }
            if (s.Contains(":D"))
            {
                a = s.Replace(":D", Emoji2.ToString());
            }
            if (s.Contains(":'D"))
            {
                a = s.Replace(":'D", Emoji3.ToString());
            }
            if (s.Contains("><"))
            {
                a = s.Replace("><", Emoji4.ToString());
            }
            if (s.Contains(";)"))
            {
                a = s.Replace(";)", Emoji5.ToString());
            }
            if (s.Contains(":P"))
            {
                a = s.Replace(":P", Emoji6.ToString());
            }
            if (s.Contains("<3"))
            {
                a = s.Replace("<3", Emoji7.ToString());
            }
            listBoxMessages.Items.Add(a);
            
        }

        private void File_Button_Click(object sender, EventArgs e)
        {

        }

  /// <summary>
        ///Button <c>Send_Button_Click</c>
        ///  Realiza un WriteLine por parte del usuario y limpia lo que estaba en el textbox para escribir
        /// </summary>  
        private void Send_Button_Click(object sender, EventArgs e)
        {
            bool IsInGroup = false;
            for (int i = 0; i < GroupsDT.Rows.Count; i++)
            {

                if (GroupsDT.Rows[i][0].ToString() == selected)
                {
                    IsInGroup = true;

                }

            }

            //streamW.WriteLine(WriteMessage.Text);
            if (selected!= "Unknown")
            {
                string msg = WriteMessage.Text;
                string result = " ";

                if (IsInGroup==true)
                {
                    Messages mensaje = new Messages { remitente = nick, grupo = selected, mensaje = msg };
                    result = JsonConvert.SerializeObject(mensaje);
                }
                else 
                {
                    Messages mensaje = new Messages { remitente = nick, destinatario = selected, mensaje = msg };
                    result = JsonConvert.SerializeObject(mensaje);
                }

                streamW.WriteLine(result);

                GuardarMensajes(msg);
                streamW.Flush();
                WriteMessage.Clear();
            }
         
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

        private void RefreshContacts_Click_1(object sender, EventArgs e)
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

        private void CreateGroup_Click(object sender, EventArgs e)
        {
            Form2 GW = new Form2();
            GW.ShowDialog();
            MostrarUsuarios();
        }

        private void SalirGrupo_Click(object sender, EventArgs e)
        {
            bool IsInGroup = false;
            for (int i = 0; i < GroupsDT.Rows.Count; i++)
            {

                if (GroupsDT.Rows[i][0].ToString() == selected)
                {
                    IsInGroup = true;

                }

            }

            if(IsInGroup==true)
            {
                DialogResult dialogResult = MessageBox.Show("¿Desea salir de este grupo?", "Message", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.Yes)
                {
                    DataTable dataTa = new DataTable();
                    Groups GruposAct = new Groups();
                    GruposAct.NombreGrupo = selected;
                    GruposAct.NombrePersona = nick;
                    GetGroups.DeleteFromGroup(GruposAct);

                    selected = "Unknown";
                    MostrarUsuarios();

                    listViewContact.Items.Clear();

                }
            }
           
        }

        private void GroupOptions_Click_1(object sender, EventArgs e)
        {
            Transition trans = new Transition(new TransitionType_EaseInEaseOut(800));
            trans.add(panel6, "Left", 0);
           
            trans.run();


        }

        private void BackGroupConfig_Click(object sender, EventArgs e)
        {
            Transition trans = new Transition(new TransitionType_EaseInEaseOut(800));
            trans.add(panel6, "Left", -500);

            trans.run();

        }

        private void AddMember_Click(object sender, EventArgs e)
        {
            bool IsInGroup = false;
            for (int i = 0; i < GroupsDT.Rows.Count; i++)
            {

                if (GroupsDT.Rows[i][0].ToString() == selected)
                {
                    IsInGroup = true;

                }

            }

            if (IsInGroup == true)
            {
                
               Form3 GW = new Form3(Users, selected);
               GW.ShowDialog();
               MostrarUsuarios();
                listViewContact.Items.Clear();

            }

           

        }

        private void LeftPanel_Click(object sender, EventArgs e)
        {
            Transition trans = new Transition(new TransitionType_EaseInEaseOut(800));
            trans.add(panel3, "Left", 0);
            trans.add(listViewContact, "Left", 15);

            trans.run();

        }

        private void RightPanel_Click(object sender, EventArgs e)
        {
            Transition trans = new Transition(new TransitionType_EaseInEaseOut(800));
            trans.add(panel5, "Left", 950);

            trans.run();
        }

        private void CloseRightPanel_Click(object sender, EventArgs e)
        {
            Transition trans = new Transition(new TransitionType_EaseInEaseOut(800));
            trans.add(panel5, "Left", 1600);

            trans.run();
          

        }

        private void CloseLeftPanel_Click_1(object sender, EventArgs e)
        {
            Transition trans = new Transition(new TransitionType_EaseInEaseOut(800));
            trans.add(panel3, "Left", -500);

            trans.run();
        }

        private void listBoxMessages_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(Object sender, FormClosingEventArgs e)
        {

            //System.Text.StringBuilder messageBoxCS = new System.Text.StringBuilder();
            //messageBoxCS.AppendFormat("{0} = {1}", "CloseReason", e.CloseReason);
            //messageBoxCS.AppendLine();
            //messageBoxCS.AppendFormat("{0} = {1}", "Cancel", e.Cancel);
            //messageBoxCS.AppendLine();
            //MessageBox.Show(messageBoxCS.ToString(), "FormClosing Event");

            if(objUserU.user!=null)
            {
                objUserU.status = "Disconnected";
                objUsersAll.EditStatus(objUserU);
                streamW.WriteLine(objUserU.user + objUserU.status);
                streamW.Flush();
            }
            

        }

        private void WriteMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void MailDisplay_TextChanged(object sender, EventArgs e)
        {

        }

        private void listViewContact_SelectedIndexChanged(object sender, EventArgs e)
        {
           //selected = this.listViewContact.SelectedItems[0].Text;

            if (listViewContact.SelectedIndices.Count <= 0)
            {
                return;
            }
            int intselectedindex = listViewContact.SelectedIndices[0];
            if (intselectedindex >= 0)
            {
                selected = listViewContact.Items[intselectedindex].Text;
                listBoxMessages.Items.Clear();
                MostrarMensajes();


                //do something
                //MessageBox.Show(listView1.Items[intselectedindex].Text); 
            }

        }
    }


}
