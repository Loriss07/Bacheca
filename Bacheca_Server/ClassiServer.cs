using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Bacheca_Server
{
    internal class ClassiServer
    {
    }

    public class Server_Bacheca
    {
        private Socket socket;
        private EndPoint endPoint;

        public Server_Bacheca(IPAddress IP, int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            endPoint = new IPEndPoint(IP, port);
        }
        public void Start()
        {
            
            try {
                socket.Bind(endPoint);
                socket.Listen(20);

               
            }
            catch (SocketException se)
            {
               
            }
            
        }

        


    }
    public class Item
    {
        private string username;
        private string board_name;
        private bool visible;
        private int length;
        private string text;
        private DateTime creation_time;
        private DateTime fixed_date;

        public Item()
        {
            text = "";
            creation_time = DateTime.Now;
        }
        public string Username { get { return username; } set { username = value; } }
        public string Text { get { return text; } set { text = value; } }
        public bool Visibility { get { return visible; } set { visible = value; } }
        public string Board { get { return board_name; } }
        public DateTime Date { get { return fixed_date; } set { fixed_date = value; } }

        public string Pack()
        {
            string msg = "";
            msg += Username + "|" + Board + "|" + Visibility.ToString() + "|" + /* Lunghezza + Tipo +*/ Date.ToString() + "|" + Text;

            return msg;
        }
        public string Unpack(string msg)
        {

            return "";
        }
    }

    public class Board
    {
        string filepath;
        string name;
        bool prvt;

        public Board()
        {
            filepath = "";
            name = "MyBoard";
        }
        public void Create(string name, string filepath)
        {
            this.name = name;
            this.filepath = filepath;
        }
        public void AddMemo(Item memo)
        {
            // Scrive il memo nel file
        }
    }
}
