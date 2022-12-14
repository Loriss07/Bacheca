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
            Client_Bacheca Bacheca = new Client_Bacheca();
            try {
                bool validBoard = false;
                IP = IPAddress.Parse(Ip.Text);
                Bacheca.Owner = this;
                if (BoardName.Text.Length > 3 && Usr.Text.Length > 3)
                {
                    Bacheca.BoardName = BoardName.Text;
                    Bacheca.Username = Usr.Text;
                    Client.Connect(IP, 50000);
                    if (Client.ConnectedClient)
                    {
                        validBoard = Client.ExistsBoard(BoardName.Text, Usr.Text);

                        if (validBoard && Client.ConnectedClient)
                        {
                            Bacheca.Run(IP, Usr.Text, ref Client);
                            Hide();
                        }
                        else if (!validBoard)
                        {
                            MessageBox.Show("La bacheca non esiste!");
                            btnLogin.Enabled = false;
                        }
                    }
                }
                else
                    MessageBox.Show("Username e la bacheca devono essere lunghi almeno 3 caratteri...");
                
                    
            }
            catch (FormatException fe) { MessageBox.Show("IP non valido :/ "); }
            
            catch (System.Net.Sockets.SocketException se)
            {
                MessageBox.Show("Impossibile connettersi :( ");
                Bacheca.Hide();
                Show();
            }

            
        }

        private void Create_Click(object sender, EventArgs e)
        {
            Client_Bacheca Bacheca = new Client_Bacheca();
            try
            {
                bool validBoard = false;
                IP = IPAddress.Parse(Ip.Text);
                Bacheca.Owner = this;
                if (BoardName.Text.Length > 3 && Usr.Text.Length > 3)
                {
                    Bacheca.BoardName = BoardName.Text;
                    Bacheca.Username = Usr.Text;
                    Client.Connect(IP, 50000);
                    if (Client.ConnectedClient)
                    {
                        validBoard = Client.ExistsBoard(BoardName.Text, Usr.Text);

                        if (!validBoard)
                        {
                            Client.CreateBoard(BoardName.Text, Usr.Text, PrivateBoard.Checked);
                            Bacheca.Run(IP, Usr.Text, ref Client);
                            Hide();
                        }
                        else
                        {
                            MessageBox.Show("La bacheca esiste già!");
                            Create.Enabled = false;
                        }
                    }
                }
                   else
                    MessageBox.Show("L'Username e la bacheca devono essere lunghi almeno 3 caratteri...");



            }
            catch (FormatException fe) 
                { MessageBox.Show("IP non valido :/ "); 
            }
            catch (System.Net.Sockets.SocketException se)
            {
                MessageBox.Show("Impossibile connettersi :( ");
                Bacheca.Hide();
                Show(); 
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
