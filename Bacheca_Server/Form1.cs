using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.IO;

namespace Bacheca_Server
{
    public partial class Form1 : Form
    {
        private Server_Bacheca Server;
        private IPAddress IP = IPAddress.Parse("127.0.0.1");
        private ListBox FileBoard;
        private BoardsManager BoardsManager;
        public ListBox Files { set { FileBoard = value; } get { return FileBoard;  } }  
        public Form1()
        {
            
            InitializeComponent();
            BoardsManager = new BoardsManager();
            Files = BoardFiles;
            /*string path = Environment.CurrentDirectory;
            path = path.Substring(0, path.IndexOf("bin")) + "Boards";*/

            foreach (Board board in BoardsManager.boardList)
            {
                BoardFiles.Items.Add(board);
            }

            /*if (Directory.Exists(path))
                foreach (string file in Directory.GetFiles(path))
                {
                    string format = file.Remove(0, file.LastIndexOf("\\") + 1);
                    format = format.Substring(0, format.IndexOf(".json"));
                    BoardFiles.Items.Add(format);

                }*/

            Server = new Server_Bacheca(IP,50000,ref BoardsManager);
            Thread ServerListening = new Thread(new ParameterizedThreadStart(Server.Start));
            ServerListening.Start(this);
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Server.Stop();
        }
    }
}
