using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Bacheca
{
    public partial class Login : Form
    {
        private ClientSide preClient;
        public Login()
        {
            InitializeComponent();
            preClient = new ClientSide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try { 
                IPAddress IP = IPAddress.Parse(Ip.Text);
                Client_Bacheca Bacheca = new Client_Bacheca();
                Bacheca.Owner = this;
                Bacheca.BoardName = BoardName.Text;
                Bacheca.Run(IP,Usr.Text);
                preClient.Connect(IP, 50000);
                MessageBox.Show(preClient.ExistsBoard(BoardName.Text,Usr.Text));
                Hide();
            }
            catch (FormatException fe) { 
                MessageBox.Show("IP non valido");
                //Ip.Clear();
            }
        }
    }
}
