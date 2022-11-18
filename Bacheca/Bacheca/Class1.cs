using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacheca
{
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

        private string Code()
        {
            string msg = "";
                msg += Username + "|" + Board + "|" + Visibility.ToString() + "|" + /* Lunghezza + Tipo +*/ Date.ToString() + "|" + Text;
                
            return msg;
        }
    }

    internal class ClientSide
    {
        private Socket socket;

        public ClientSide() { socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); }

        public void Connect(IPAddress serverIp, int Port)
        {
            EndPoint Server = new IPEndPoint(serverIp, Port);
            socket.Connect(Server);
        }
    }
}
