using System;
using System.Net;
using System.Net.Sockets;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bacheca
{
    internal class Item
    {
        private string _id;
        private string text;
        private DateTime creation_time;
        private DateTime fixed_date;

        public Item()
        {
            text = "";
            creation_time = DateTime.Now;
        }
        public string Text { get { return text; } set { text = value; } }
    }

    internal class Connection
    {
        private Socket socket;

        public Connection(IPAddress IP, int Porta)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            EndPoint ep = new IPEndPoint(IP, Porta);
            socket.Bind(ep);
        }
    }
}
