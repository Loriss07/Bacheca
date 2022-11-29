using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

namespace Bacheca
{
    public partial class Client_Bacheca : Form
    {
        private string _usr;
        private string _boardname;
        private IPAddress _IP;
        private ClientSide Client;
        private Login _form;

        public string Username { set { _usr = value; } get { return _usr; } }
        public string BoardName { set { _boardname = value; } get { return _boardname; } }
        public IPAddress IP { set { _IP = value; } get { return _IP; } }
        public Client_Bacheca() {  InitializeComponent(); }
        public void Run(IPAddress IP, string username,ref ClientSide client)
        {

            Show();
            Usr.Text = username;
            BoardName = _boardname;
            
            Client = client;
           

            //  Recupera gli oggetti dal server se presenti
            
              
        }
        private void PinMemo()
        {
            //Mostra i promemoria
            if (Client.ExistsBoard(boardName.Text, Usr.Text) == "+TRUE++")
            {
                foreach (Item i in Client.Download(_boardname, _usr))
                {

                }
            }
            
        }
        private void Send_Click(object sender, EventArgs e)
        {
            //Impacchetta il messaggio e lo spedisce

            Item attivita = new Item();
            attivita.Text = TestoAttivita.Text;
            attivita.Username = Usr.Text;
            attivita.Visibility = Public.Checked;
            

            Client.Send(attivita);
        }


        private void Client_Bacheca_Paint(object sender, PaintEventArgs e)
        {
            // Disegna la grafica della bacheca  
            Graphics DrawBoard = e.Graphics;
            DrawBoard.DrawRectangle(new Pen(Color.Red),
                    new Rectangle(0,0,Board.Width,Board.Height));
            Update();
        }

        private void Client_Bacheca_Load(object sender, EventArgs e)
        {
            _form =(Login)Owner;
        }

        private void Client_Bacheca_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            _form.Dispose();
        }
    }
    
   
    
}
