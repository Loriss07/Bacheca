using System;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bacheca
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            IPAddress IP = IPAddress.Parse(Ip.Text);
            Client_Bacheca Bacheca = new Client_Bacheca(IP,Usr.Text);
            Bacheca.Show();
            Close();
        }
    }
}
