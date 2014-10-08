using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using System.Collections;
using System.Data.SqlServerCe;

namespace ServerGUI
{
    class Server
    {
        TcpListener Listner;
        static ListBox lb;
        static ArrayList Writers = new ArrayList();
        static bool stop;
        static object locker = new object();
        static string Message;
        Thread Accepting;
        static SqlCeConnection connection;
        public Server(int Port, ref ListBox _lb)
        {
            Listner = new TcpListener(Port);
            lb = _lb;
            stop = true;
        }
        public void Start()
        {
            Listner.Start();
            string connectionString = @"Data Source=D:\Labs\3 курс\1 семестр\ТРПО ИС\Task2\Users.sdf";
            connection = new SqlCeConnection(connectionString);
            connection.Open();
            stop = false;
            Accepting = new Thread(new ThreadStart(Start_Accept));
            Accepting.Start();
        }

        void Start_Accept()
        {
            while(!stop)
            {
                try
                {
                    TcpClient Client = Listner.AcceptTcpClient();
                    Thread Thread = new Thread(new ParameterizedThreadStart(ClientThread));
                    Thread.Start(Client);
                }
                catch (SocketException)
                { }
            }
        }

        public void Stop()
        {
            if (Listner != null)
            {
                stop = true;
                //Accepting.Abort();
                SendMessages("");
                Listner.Stop();
            }
            connection.Close();
            connection.Dispose();
        }

       static void SendMessages(string Message)
        {
            StreamWriter writer;
            for (int i = 0; i < Writers.Count; i++)
            {
                writer = (StreamWriter)Writers[i];
                try
                {
                    writer.WriteLine(Message);
                }
                catch (Exception)
                { }
            }
            if (Message == "")
                Message = "SERVER SHUTDOWN!";
            Message = "[" + DateTime.Now.ToString() + "] " + Message;
            lb.Invoke(new Action(() => lb.Items.Add(Message)));
        }

       public void GetAllClientData()
       {
           SqlCeCommand command = connection.CreateCommand();
           command.CommandText = "SELECT * FROM Users";
           SqlCeDataReader reader = command.ExecuteReader();
           while (reader.Read())
           {
               string txt = "[ " + reader[0].ToString() + " ] [ " + (string)reader[1] + " ] [ " + (string)reader[2] + " ] [ " + reader[3].ToString() + " ] [ " + reader[4].ToString()+" ]";
               lb.Invoke(new Action(() => lb.Items.Add(txt)));
               
           }
           reader.Dispose();
       }

        static void ClientThread(Object StateInfo)
        {
            TcpClient Client = (TcpClient)StateInfo;
            var stream = Client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);
            writer.AutoFlush = true;
            SqlCeCommand command = connection.CreateCommand();
            bool isFirst = Boolean.Parse(reader.ReadLine());
            bool bad = false;
            string NickName = reader.ReadLine();
            string Password = reader.ReadLine();
            if (isFirst)
            {
                command.CommandText = "INSERT INTO Users (Login,Password,LastConnection,RegistrationDate) VALUES (@NN,@pwd,@lc,@rd)";
                command.Parameters.AddWithValue("@NN", NickName);
                command.Parameters.AddWithValue("@pwd", Password);
                command.Parameters.AddWithValue("@lc", DateTime.Now.ToString());
                command.Parameters.AddWithValue("@rd", DateTime.Now.ToString());
                try
                {
                    int count = command.ExecuteNonQuery();
                }
                catch (Exception)
                {
                    writer.WriteLine("THIS NICKNAME IS ALREADY USED");
                    writer.WriteLine("ERROR\t");
                   // Thread.Sleep(10);
                    bad = true;
                }
            }
            else
            {
                command.CommandText = "SELECT COUNT(*) FROM Users WHERE Login = @nn AND Password = @pwd";
                command.Parameters.AddWithValue("@NN", NickName);
                command.Parameters.AddWithValue("@pwd", Password);
                if ((int)command.ExecuteScalar() == 1)
                {
                    command.CommandText = "UPDATE Users set LastConnection = @lc WHERE Login = @lg";
                    command.Parameters.AddWithValue("@lc", DateTime.Now.ToString());
                    command.Parameters.AddWithValue("@lg", NickName);
                    int count = command.ExecuteNonQuery();
                }
                else
                {
                    writer.WriteLine("ERROR\t");
                    //Thread.Sleep(10);
                    bad = true;
                }
            }
            command.Dispose();
            if (!bad)
            {
                SendMessages("\"" + NickName + "\"" + " CONNECTED!");
                Writers.Add(writer);
                while (Client.Connected)
                {
                    try
                    {
                        Message = reader.ReadLine();
                        if (Message == null)
                            Message = "\"" + NickName + "\"" + " DISCONNECTED!";
                        SendMessages(Message);
                    }
                    catch (Exception)
                    { }
                }
            }
        }

    }
}
