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

namespace Bacheca_Server
{
    public partial class Form1 : Form
    {
        public Server_Bacheca Server;
        public IPAddress IP = IPAddress.Parse("127.0.0.1");
        public Form1()
        {
            
            InitializeComponent();
            Server = new Server_Bacheca(IP,50000);
            //Thread ServerListening = new Thread(new ThreadStart(Server.Start));
            //ServerListening.Start();
            Board a = new Board();
            a.Create("a",true);
        }


    }
}
