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
        private ClientSide Client;
        private IPAddress IP;
        public Login()
        {
            InitializeComponent();
            Client = new ClientSide();
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try { 
                IP = IPAddress.Parse(Ip.Text);
                Client_Bacheca Bacheca = new Client_Bacheca();
                Bacheca.Owner = this;
                Bacheca.BoardName = BoardName.Text;
                Bacheca.Run(IP, Usr.Text,ref Client);
                Client.Connect(IP, 50000);
                MessageBox.Show(Client.ExistsBoard(BoardName.Text,Usr.Text));
                Hide();
            }
            catch (FormatException fe) { 
                MessageBox.Show("IP non valido");
            }

            
        }

        private void Create_Click(object sender, EventArgs e)
        {
            try
            {
                IP = IPAddress.Parse(Ip.Text);
                Client_Bacheca Bacheca = new Client_Bacheca();
                Bacheca.Owner = this;
                Bacheca.BoardName = BoardName.Text;
                Bacheca.Run(IP, Usr.Text,ref Client);
                Client.Connect(IP, 50000);
                Client.CreateBoard(BoardName.Text, Usr.Text, PrivateBoard.Checked);
                Hide();
            }
            catch (FormatException fe)
            {
                MessageBox.Show("IP non valido");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Errore. Tentativo di riconnessione");
                Connetti();
            }
            
            
        }
        private void Connetti()
        {
            try
            {
                IPAddress IP = IPAddress.Parse(Ip.Text);
                Client.Connect(IP, 50000);
            }
            catch (System.Net.Sockets.SocketException se)
            {
                MessageBox.Show("C'è stato un errore.");
            }
            
        }
    }
}
