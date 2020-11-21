using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;


namespace ServerPOI
{
    class Servidor_Chat
    {


        //Permita esperar la conexion del cliente
        private TcpListener server;
        //Promocionar una conexion netre el servidor y el cliente 
        private TcpClient client = new TcpClient();
        //Instacniar la clase, se va a trabajar con las IP
        private IPEndPoint endPoint = new IPEndPoint(IPAddress.Any, 8000);
        //Para hacer la conexion, y tener una lista de todas las conecciones
        private List<Connection> list = new List<Connection>();
        Connection connect;

        private struct Connection
        {
            public NetworkStream stream;
            public StreamWriter streamW;
            public StreamReader streamR;
            //para identificar al usuario
            public string nick;
            public string enviar;
        }

        public Servidor_Chat()
        {
            Inicio();
        }

        public void Inicio()
        {
            int NumRed = 0;
            Console.WriteLine("Servidor Activado");
            server = new TcpListener(endPoint);
            server.Start();

            while (true)
            {
                //Si esta conexion se cumple
                client = server.AcceptTcpClient();
                //hara una nueva conexion
                connect = new Connection();
                //Hace conexion con el network stream
                connect.stream = client.GetStream();
                //Para leer
                connect.streamR = new StreamReader(connect.stream);
                //para escribir
                connect.streamW = new StreamWriter(connect.stream);

                //para leer y captar
                connect.nick = connect.streamR.ReadLine();
                //y agregar al listado
                list.Add(connect);
                Console.WriteLine(connect.nick + " se ha conectado");
                //para un buscador
                Thread thread = new Thread(EscucharConexion);
                thread.Start();
                NumRed++;
            }
        }

        void EscucharConexion()
        {
            Connection hcon = connect; //hconection



            //ver si la conexion se pudo realizar o no
            do
            {
                try
                {
                    string tmp = hcon.streamR.ReadLine();
                    Console.WriteLine(tmp);
                    //mostar el listado de los datos leidos



                    foreach (Connection c in list)
                    {
                        //condicion
                        try
                        {
                            //Escribir el mensaje
                            c.streamW.WriteLine(tmp);
                            c.streamW.Flush();
                        }
                        catch
                        {
                            //si no sucede nada no pasa nada
                        }
                    }
                }
                catch
                {
                    //si el susuario se desconecta no se va a guardar la info
                    list.Remove(hcon);
                    Console.WriteLine(connect.nick + " se ha desconectado");
                    break;
                }

            } while (true);
        }
    }
}

//create table Users
//(
//UserName varchar(20),
//Pass varchar(20),
//Email varchar(20),
//)

//insert into Users values('Chris', 'CB97', 'Loveskz@gmail.com');
//insert into Users values('Jisung', 'JONE', 'cheescake@gmail.com');
//insert into Users values('Changbin', 'SPEARB', 'babycb@gmail.com');


//create proc Login_User
//@user varchar(20),
//@pass varchar
//as
//select UserName, Pass, Email from Users
//where UserName = @user and Pass = @pass
//go