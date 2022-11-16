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
        private Connection Client;
        public Client_Bacheca(IPAddress IP, string username)
        {
            InitializeComponent();
            Usr.Text = username;
        }

        private void Send_Click(object sender, EventArgs e)
        {
            Item attivita = new Item();
            attivita.Text = TestoAttivita.Text;
        }
    }
    
    
}
