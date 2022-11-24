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
            try { 
                IPAddress IP = IPAddress.Parse(Ip.Text);
                Client_Bacheca Bacheca = new Client_Bacheca();
                Bacheca.Owner = this;
                Bacheca.Run(IP,Usr.Text);
                Hide();
            }
            catch (FormatException fe) { 
                MessageBox.Show("IP non valido");
                Ip.Clear();
            }
        }
    }
}
