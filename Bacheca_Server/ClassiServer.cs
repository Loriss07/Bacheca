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

        public Server_Bacheca(IPAddress IP, int port,ref BoardsManager Manager)
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            BoardsManager = Manager;
            endPoint = new IPEndPoint(IP, port);
        }
        public void Start(object Form)
        {
            
            try {
                socket.Bind(endPoint);
                socket.Listen(20);
                Socket handler;
                while (true)
                {
                    handler = socket.Accept();

                    ClientManager clientThread = new ClientManager(handler, ref BoardsManager);
                    Thread t = new Thread(new ParameterizedThreadStart(clientThread.ReceiveRequests));
                    t.Start(Form);
                }
                

            }
            catch (SocketException se)
            {
               
            }
            
        }
        
        public void Stop()
        {
            socket.Close();
            socket.Dispose();
        }

    }
    public class Item
    {
        private string uesrName;
        private string boardName;
        private bool visible;
        private int length;
        private string text;
        private DateTime creation_time;
        private DateTime fixed_date;
        private int id;

        public Item()
        {
            text = "";
            boardName = "";
            visible = false;
            length = 0;

            creation_time = DateTime.Now;
        }

        public string Username { get { return uesrName; } set { uesrName = value; } }
        public string Text { get { return text; } set { text = value; } }
        public bool Visibility { get { return visible; } set { visible = value; } }
        public int Length { get { return length; } set { length = value; } }
        public string Board { get { return boardName; } set { boardName = value; } }
        public DateTime Date { get { return fixed_date; } set { fixed_date = value; } }

        public byte[] Pack()
        {
            string msg = "";
            msg += "^|"+ Username + "|" + Board + "|" + Visibility.ToString() + "|" +
                    Convert.ToString(Text.Length) + "|" +/*Tipo +*/ Date.ToString() + "|" + Text + "| **";

            byte[] output = Encoding.ASCII.GetBytes(msg);
            return output;
        }

        public static string Zip(List<Item> MemoList)
        /*Crea la lista di memo che poi viene usata dal client - è statico*/
        {
            string Memos = "";
            if (MemoList.Count > 0)
            {
                Memos = "^|";
                foreach (Item memo in MemoList)
                {
                    Memos += memo.Username + "|" + memo.Board + "|" +
                        memo.Visibility.ToString() + "|" + Convert.ToString(memo.Length) + "|" + memo.Date.ToString() + "|" + memo.Text + "| **"; ;
                }
                Memos += "%%";
            }
            else
            {
                Memos = " %%";
            }

            return Memos;
        }

        public static Item Unpack(string packedMsg)
        {
            Item item = new Item();
            string[] args = packedMsg.Split('|');
           
            item.uesrName = args[1];
            item.boardName = args[2];
            item.visible = Convert.ToBoolean(args[3]);
            item.length = Convert.ToInt32(args[4]);
            item.fixed_date = DateTime.Parse(args[5]);
            item.text = args[6];


            return item;
        }
    }
    public class BoardsManager
    {
        private List<Board> BoardsList;
        static string indexFile;

        public List<Board> boardList { get { return BoardsList;  } set { } }
        public BoardsManager() { 
            BoardsList =  new List<Board>();
            indexFile = Environment.CurrentDirectory;
            indexFile = indexFile.Substring(0, indexFile.IndexOf("bin")) + "BoardManager\\Boards.json";
            if (File.Exists(indexFile))
            {
                string boards = File.ReadAllText(indexFile);
                BoardsList = JsonSerializer.Deserialize<List<Board>>(boards); ;
            } else
            {
                FileStream fs = File.Create(indexFile);
                fs.Write(Encoding.ASCII.GetBytes("[ ]"));
                fs.Dispose();
            }
        }
        public void UnloadBoards()
        {
            string boardFile = JsonSerializer.Serialize(BoardsList);
            File.WriteAllText(indexFile, boardFile);
            //memos.Clear();
        }
        public static bool Exists(string board_name)
        {
            bool exists = false;
            string path = Environment.CurrentDirectory;
            path = path.Substring(0, path.IndexOf("bin")) + "Boards";
            if (Directory.Exists(path))
                foreach (string file in Directory.GetFiles(path))
                    if (file.EndsWith(board_name + ".json"))
                        exists = true;

            return exists;
        }
        public Board OpenBoard(string board_name,string board_user)
        {
            return BoardsList[GetBoard(board_name, board_user)];
        }
        public void CreateBoard(string board_name,string board_user, bool visible)
        {
            BoardsList.Add(new Board(board_name,board_user,visible));
            UnloadBoards();
        }
        public string SendBoard(string board_name, string board_user)
        {
            string board;
            if (GetBoard(board_name, board_user) >= 0 && BoardsList.Count > 0)
            {
                Board ReqBoard = BoardsList[GetBoard(board_name, board_user)];
                string memo = File.ReadAllText(ReqBoard.BoardPath);
                object m = JsonSerializer.Deserialize(memo, typeof(List<Item>));
                List<Item> list = m as List<Item>;

                board = Item.Zip(list)+"|%%";
            }
            else
                board = " %%";

            return board;
        }
        public int GetBoard(string board_name,string board_user)
        {
            int index = -1;
            foreach (Board board in BoardsList)
            {
                if (IsEqual(board.ID,Board.GetID(board_name,board_user)))
                    index = BoardsList.IndexOf(board);
            }
            return index;
        }
        private bool IsEqual(char[] a,char[] b)
        {
            bool ok = true;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i])
                    ok = false;
            }
            return ok;
        }
    }
    public class Board
    {
        private string fileName;
        private string filePath;
        private string boardName;
        private List<string> boardUsers;
        private List<Item> memos;
        private bool prvt;
        private DateTime creationTime;
        private char[] Id;

        public string BoardName { get { return boardName; } set { boardName = value; } }
        public string BoardPath { get { return filePath; } set { filePath = value; } }
        public List<string> BoardOwner { get { return boardUsers; } set { boardUsers = value; } }
        public bool Private { get { return prvt; } set { prvt = value; } }
        public char[] ID { get { return Id; } set { Id = value; } }
        public DateTime CreationTime { get { return creationTime; } set { creationTime = value; } }
        public Board()
        {
            filePath = "";
            boardName = "MyBoard";
            memos = new List<Item>();
        }
        public Board(string name,string user)
        {
            filePath = "";
            boardName = name;
            boardUsers.Add(user);

        }

        //Crea la bacheca
        public Board(string name,string user,bool visible)
        {
            boardUsers = new List<string>();
            creationTime = DateTime.Now;
            boardName = name;
            boardUsers.Add(user);
            fileName = name + user + ".json";
            filePath = Environment.CurrentDirectory;
            filePath = filePath.Substring(0, filePath.IndexOf("bin")) + "Boards";
            prvt = !visible;
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            filePath = Path.Combine(filePath, fileName);
            FileStream file = File.Create(filePath);
            file.Write(Encoding.ASCII.GetBytes("[ ]"));
            file.Dispose();
            Id = GenerateID(boardName,boardUsers[0]);
            memos = new List<Item>();
        }
        
        public void Load()
            // Carica in memoria i promemoria
        {
            memos = JsonSerializer.Deserialize(filePath,typeof(List<Item>)) as List<Item>;
        }
        public void Unload()
            // Scarica i promemoria dalla memoria
        {
            string memoFile = JsonSerializer.Serialize(memos);
            File.WriteAllText(filePath, memoFile);
            memos.Clear();
        }
        public void AddMemo(Item memo)
        {
            // Scrive il memo nel file json
            
            memos.Add(memo);
            Unload();
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

        private char[] GenerateID(string boardname,string user)
        {
            Id = new char[5];
            Id[0] = boardname[0];
            Id[1] = boardname[1];
            Id[2] = user[2];
            Id[3] = user[3];
            Id[4] = Convert.ToChar(boardname[0] + user[user.Length - 1]);
            return Id;
        }
        public static char[] GetID(string boardname,string user)
        {
            char[] hash = new char[5];
            hash[0] = boardname[0];
            hash[1] = boardname[1];
            hash[2] = user[2];
            hash[3] = user[3];
            hash[4] = Convert.ToChar(boardname[0] + user[user.Length - 1]);
            return hash;
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
            
        public void ReceiveRequests(object Form)
        {
            Form1 Server = Form as Form1;
            //string request = "";
            while(request != "-EXIT--")
            {
                bool validReq = true;

                while (request.IndexOf("++") == -1 && validReq && request.IndexOf("**") == -1)
                {
                    int bytesRec = ManagerSocket.Receive(bytes);
                    request += Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    if (request.Length > 0)
                    {
                        if (request[0] != '+' && request[0] != '^')
                            validReq = false;
                    }
                    else
                        validReq = false;
                }
                if (request.EndsWith("++") && validReq)
                    Respond(request,Server);
                else if (request.EndsWith("**") && validReq)
                    ManageMemo(request);

                request = "";
                //Debug.Write("Messaggio ricevuto : {0}", request);
            }
                
            ManagerSocket.Shutdown(SocketShutdown.Both);
            ManagerSocket.Close();
        }
        private void ManageMemo(string request)
        {
            Item memo = Item.Unpack(request);
            Board board = BoardsManager.OpenBoard(memo.Board, memo.Username);
            board.AddMemo(memo);
        }
        private void Respond(string request, Form1 Server)
        {
            string res = "";
            string[] packetData = request.Split('|');
            string reqType = packetData[packetData.Length - 1];
            switch (reqType)
            {
                case "DOWNLOAD++":
                    {
                        if (BoardsManager.Exists(packetData[1]+packetData[2]))
                            res =  BoardsManager.SendBoard(packetData[1], packetData[2]);
                        else
                            res = "+" + "NOT FOUND" + "++";
                    } break;

                case "CHECK++":
                    {
                        res = "+" + BoardsManager.Exists(request.Split("|")[1] + request.Split("|")[2]) + "++";
                        
                    } break;
                case "CREATE++":
                    {
                        // Crea la bacheca
                        
                        BoardsManager.CreateBoard(packetData[1], packetData[2],Convert.ToBoolean(packetData[3]));
                        if (Server.Files.IsHandleCreated)
                        {
                            Server.Files.Invoke(new Action(() => Server.Files.Items.Add(packetData[1])));
                        }
                        res = "+|Bacheca Creata++";

                    } break;
                
            }
            byte[] outbound = Encoding.ASCII.GetBytes(res);
            ManagerSocket.Send(outbound);
        }

        
    }
}
