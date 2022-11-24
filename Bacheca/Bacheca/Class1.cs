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

        public string Pack()
        {
            string msg = "";
                msg += Username + "|" + Board + "|" + Visibility.ToString() + "|" + /* Lunghezza + Tipo +*/ Date.ToString() + "|" + Text;
                
            return msg;
        }
        public string Unpack(string msg)
        {
            
        }
    }

    internal class ClientSide
    {
        private Socket socket;
        private List<Item> Memos;   //La lista che salva i promemoria

        public ClientSide() { 
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Memos = new List<Item>();
        }

        public void Connect(IPAddress serverIp, int Port)
        {
            EndPoint Server = new IPEndPoint(serverIp, Port);
            socket.Connect(Server);
        }

        public List<Item> Download()
        /*Recupera i promemoria dal server e li mostra sul client*/
        {
            List<Item> list = new List<Item>();
            return null;
        }

        public void Send(Item memo)
        /*Manda un promemoria al server*/
        { 
            string msg = memo.Pack();
            byte[] packet = Encoding.ASCII.GetBytes(msg);
            Add(memo);
            
            socket.Send(packet);
        }

        private void Add(Item memo)
        /* Salva in locale il promemoria */
        {
            Memos.Add(memo);
        }
    }

}
