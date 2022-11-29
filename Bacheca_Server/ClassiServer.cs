using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Bacheca_Server
{
    public class Server_Bacheca
    {
        private Socket socket;
        private EndPoint endPoint;
        private BoardsManager BoardsManager;

        
        public Server_Bacheca(IPAddress IP, int port)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            BoardsManager = new BoardsManager();
            endPoint = new IPEndPoint(IP, port);
        }
        public void Start()
        {
            
            try {
                socket.Bind(endPoint);
                socket.Listen(20);
                Socket handler;
                while (true)
                {
                    handler = socket.Accept();

                    ClientManager clientThread = new ClientManager(handler, ref BoardsManager);
                    Thread t = new Thread(new ThreadStart(clientThread.ReceiveRequests));
                    t.Start();

                }

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
        private int id;

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
    public class BoardsManager
    {
        List<Board> BoardsList; 

        public BoardsManager()
        {
            BoardsList =  new List<Board>();
        }

        public static bool Exists(string name)
        {
            bool exists = false;
            string path = Environment.CurrentDirectory;
            path = path.Substring(0, path.IndexOf("bin")) + "Boards";
            if (Directory.Exists(path))
                foreach (string file in Directory.GetFiles(path))
                    if (file.EndsWith(name + ".json"))
                        exists = true;

            return exists;
        }

        public void Create(string name,string user, bool visible)
        {
            BoardsList.Add(new Board(name,user,visible));
        }


    }
    public class Board
    {
        string filename;
        string filepath;
        string name;
        string owner;
        List<Item> memos;
        bool prvt;

        public string Name { get { return name; } set { name = value; } }
        public string BoardPath { get { return filepath; } set { filepath = value; } }
        public string Owner { get { return owner; } set { owner = value; } }
        public bool Private { get { return prvt; } set { prvt = value; } }
        public Board()
        {
            filepath = "";
            name = "MyBoard";
        }
        public Board(string name,string owner)
        {
            filepath = "";
            this.name = name;
            this.owner = owner;
            
        }
        public Board(string name,string ownerUser,bool visible)
        {
            this.name = name;
            owner = ownerUser;
            filename = name + ".json";
            filepath = Environment.CurrentDirectory;
            filepath = filepath.Substring(0, filepath.IndexOf("bin")) + "Boards";
            prvt = !visible;
            if (!Directory.Exists(filepath))
                Directory.CreateDirectory(filepath);

            filepath = Path.Combine(filepath, filename);
            FileStream file = File.Create(filepath);
            file.Write(Encoding.ASCII.GetBytes("[ ]"));
        }
        
        public void Load()
            // Carica in memoria i promemoria
        {
            memos = JsonSerializer.Deserialize(filepath,typeof(List<Item>)) as List<Item>;
        }
        public void Unload()
            // Scarica i promemoria dalla memoria
        {
            string memoFile = JsonSerializer.Serialize(memos);
            File.WriteAllText(filepath, memoFile);
            memos.Clear();
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

    public class ClientManager
    {
        Socket ManagerSocket;
        BoardsManager BoardsManager;
        byte[] bytes = new byte[1024];
        string request = "";

        public ClientManager(Socket handler,ref BoardsManager manager)
        {
            ManagerSocket = handler;
            BoardsManager = manager;
        }
            
        public void ReceiveRequests()
        {
                while (request.IndexOf("++") == -1 /*|| request.IndexOf("*£*") == -1*/)
                {
                    int bytesRec = ManagerSocket.Receive(bytes);
                    request += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                }
            if (request.EndsWith("++"))
                Respond(request);
            

            Console.Write("Messaggio ricevuto : {0}", request);
            request = "";
            ManagerSocket.Shutdown(SocketShutdown.Both);
            ManagerSocket.Close();
        }

        private void Respond(string request)
        {
            string res = "";
            request
            switch (request.Split("|")[3])
            {
                case "DOWNLOAD++":
                    {

                    } break;

                case "CHECK++":
                    {
                        res = "+" + BoardsManager.Exists(request.Split("|")[2]) + "++";
                        byte[] outbound = Encoding.ASCII.GetBytes(res);
                        ManagerSocket.Send(outbound);
                    } break;
                case "CREATE++":
                    {
                        // Crea la bacheca
                        string[] meta = request.Split("|");
                    } break;
            }
        }

        public void SendBoard(Board ReqBoard)
        {

            object m = JsonSerializer.Deserialize(ReqBoard.BoardPath, typeof(List<Item>));

            List<Item> list = m as List<Item>;

        }
    }
}
