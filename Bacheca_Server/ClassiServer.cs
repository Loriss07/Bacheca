﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text.Json;

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

        public void SendBoard(Board ReqBoard)
        {

            object m = JsonSerializer.Deserialize(ReqBoard.BoardPath,typeof(List<Item>));

            List<Item> list = m as List<Item>;
            
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
        public int Length { get { return length; } set { length = value; } }
        public string Board { get { return board_name; } set { board_name = value; } }
        public DateTime Date { get { return fixed_date; } set { fixed_date = value; } }

        public byte[] Pack()
        {
            string msg = "";
            msg += "^|"+ Username + "|" + Board + "|" + Visibility.ToString() + "|" +
                    Convert.ToString(Text.Length) + "|" +/*Tipo +*/ Date.ToString() + "|" + Text + "| *£*";

            byte[] output = Encoding.ASCII.GetBytes(msg);
            return output;
        }

        public static List<Item> Unzip(string msg)
        /*Crea la lista di memo che poi viene usata dal client - è statico*/
        {
            List<Item> Memolist = new List<Item>();
            char[] delim = "*£*".ToCharArray();
            string[] Memos = msg.Split(delim);  //Separa i messaggi
            foreach (string memo in Memos)
            {
                string[] memo_comp = memo.Split('|');
                Item m = new Item();
                m.Username = memo_comp[0];
                m.Board = memo_comp[1];
                m.Visibility = Convert.ToBoolean(memo_comp[2]);
                m.Length = Convert.ToInt32(memo_comp[3]);
                m.Date = DateTime.Parse(memo_comp[4]);
                m.Text = memo_comp[5];
            }

            return Memolist;
        }
    }

    public class Board
    {
        string filename;
        string path;
        string name;
        string owner;
        List<Item> memos;
        bool prvt;

        public string Name { get { return name; } set { name = value; } }
        public string BoardPath { get { return path; } set { path = value; } }
        public string Owner { get { return owner; } set { owner = value; } }
        public Board()
        {
            path = "";
            name = "MyBoard";
        }
        
        public void Create(string name, bool visible)
        {
            this.name = name;
            filename = name + ".json";
            path = Environment.CurrentDirectory;
            path = path.Substring(0, path.IndexOf("bin")) + "Boards";
            prvt = !visible;
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            path = Path.Combine(path, filename);
            FileStream file = File.Create(path);
            file.Write(Encoding.ASCII.GetBytes("[ ]"));
        }
        public void Load()
        {
            memos = JsonSerializer.Deserialize(path,typeof(List<Item>)) as List<Item>;
        }
        public void AddMemo(Item memo)
        {
            // Scrive il memo nel file json
            memos.Add(memo);

        }

        public void RemoveMemo(Item memo)
        {
            //Rimuove il memo dal file
            memos.Remove(memo);
        }

        public void EditMemo(Item Memo)
        {
            //Modifica il memo
            
        }
    }
}
