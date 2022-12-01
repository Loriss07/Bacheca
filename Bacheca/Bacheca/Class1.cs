﻿using System;
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
        public int Length { get { return length; } set { length = value; } }
        public string Board { get { return board_name; } set { board_name = value; } }
        public DateTime CDate { get { return creation_time; } set { creation_time = value; } }
        public DateTime Date { get { return fixed_date; } set { fixed_date = value; } }
        public byte[] Pack()
        {
            string msg = "";
                msg += "^|" + Username + "|" + Board + "|" + Visibility.ToString() + "|" +  
                        Convert.ToString(Text.Length) + "|" + Date.ToString() + "|" + Text + "| **";

            byte[] output = Encoding.ASCII.GetBytes(msg);
            return output;
        }

        public static List<Item> Unzip(string msg)
        /*Crea la lista di memo che poi viene usata dal client - è statico*/
        {
            List<Item> Memolist = new List<Item>();
            if (msg.Length > 6)
            {
                
                char[] delim = "**".ToCharArray();
                string[] Memos = msg.Split(delim);  //Separa i messaggi
                foreach (string memo in Memos)
                {
                    if (memo != "%%|%%" && memo != "")
                    {
                        string mo = memo.Remove(0, 2);
                        string[] memo_comp = mo.Split('|');
                        Item m = new Item();
                        m.Username = memo_comp[0];
                        m.Board = memo_comp[1];
                        m.Visibility = Convert.ToBoolean(memo_comp[2]);
                        m.Length = Convert.ToInt32(memo_comp[3]);
                        m.Date = DateTime.Parse(memo_comp[4]);
                        m.Text = memo_comp[5];
                        Memolist.Add(m);
                    }
                    
                }
            }
            return Memolist;
        }
    }

    public class ClientSide
    {
        private Socket socket;
        private List<Item> Memos;   //La lista che salva i promemoria


        public bool ConnectedClient {  get { return socket.Connected; } }
        public ClientSide() { 
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            Memos = new List<Item>();
        }

        public void Connect(IPAddress serverIp, int Port)
        {
            try
            {
                EndPoint Server = new IPEndPoint(serverIp, Port);
                socket.Connect(Server);
            }
            catch (SocketException se)
            {
                socket.Close();
                socket.Dispose();
                socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //throw new SocketException();
                EndPoint Server = new IPEndPoint(serverIp, Port);
                socket.Connect(Server);

            }
        }
        public void Disconnect()
        {
            string closingMsg = "-EXIT--";
            byte[] quit = Encoding.ASCII.GetBytes(closingMsg);  
            socket.Send(quit);
            
        }
        public List<Item> Download(string boardname, string user)
        /*Recupera i promemoria dal server e li mostra sul client*/
        {
            byte[] res = new byte[1024];
            string memo_string = "";
            int res_bytes;
            Request(boardname,user);

            while (memo_string.IndexOf("%%") == -1)
            {
                res_bytes = socket.Receive(res);
                memo_string = Encoding.ASCII.GetString(res, 0, res_bytes);
            }
            List<Item> list = new List<Item>();
            if (memo_string != "NOT FOUND")
             list = Item.Unzip(memo_string);

            return list;
        }
        
        private void Request(string boardname,string user)
        /* Richiede al server di inviare la bacheca */
        {
            string data = "";
            string msg = "+|" + boardname + "|" + user + "|DOWNLOAD++";
            byte[] req = Encoding.ASCII.GetBytes(msg);
            socket.Send(req);

        }

        public void Send(Item memo)
        /*Manda un promemoria al server*/
        { 
            byte[] packet = memo.Pack();
            Add(memo);
            socket.Send(packet);
        }

        private void Add(Item memo)
        /* Salva in locale il promemoria */
        {
            Memos.Add(memo);
        }

        public bool ExistsBoard(string boardname,string user)
        {
            bool exists; 
            string msg = "+|" + boardname + "|" + user + "|CHECK++";
            byte[] outboundReq = Encoding.ASCII.GetBytes(msg);

            socket.Send(outboundReq);
            string inbound = "";
            byte[] inboundRes = new byte[1024];
            int bytesRes = 0;
            while (inbound.IndexOf("++") == -1)
            {
                bytesRes = socket.Receive(inboundRes);
                inbound += Encoding.ASCII.GetString(inboundRes, 0, bytesRes);
            }
            inbound = inbound.Replace("+", "");
            exists = Convert.ToBoolean(inbound);

            return exists;
        }

        public void CreateBoard(string boardname, string user, bool visible)
            /* Richiede la creazione di una bacheca */
        {
            string msg = "+|" + boardname + "|" + user + "|" + visible +"|CREATE++";
            byte[] req = Encoding.ASCII.GetBytes(msg);
            socket.Send(req);
            string inbound = "";
            byte[] inboundRes = new byte[1024];
            int bytesRes;
            while (inbound.IndexOf("++") == -1)
            {
                bytesRes = socket.Receive(inboundRes);
                inbound += Encoding.ASCII.GetString(inboundRes, 0, bytesRes);
            }
        }

        
    }

}
