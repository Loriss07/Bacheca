using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;

namespace Bacheca
{
    public partial class Client_Bacheca : Form
    {
        private Login Login;
        private ClientSide Client;

        public Client_Bacheca(IPAddress IP, string username)
        {
            InitializeComponent();
            Usr.Text = username;
            Client = new ClientSide();
            Client.Connect(IP, 50000);


            //  Recupera gli oggetti dal server se presenti
        }

        private void Send_Click(object sender, EventArgs e)
        {
            //Impacchetta il messaggio e lo spedisce

            Item attivita = new Item();
            attivita.Text = TestoAttivita.Text;
            attivita.Username = Usr.Text;
            attivita.Visibility = Public.Checked;
        }
    }
    
   
    
}
