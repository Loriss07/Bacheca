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
            boardName.Text = _boardname;
            
            if (client != null)
                Client = client;


            //  Recupera gli oggetti dal server se presenti
            foreach (Item memo in Client.Download(_boardname, _usr))
                PinMemo(memo);

            
        }
        private void PinMemo(Item memo)
        {
            //Mostra i promemoria
            Random rand = new Random();
            Label label = new Label();
            label.Text = memo.Text;
            label.AutoSize = true;
            label.CreateControl();
            Board.Controls.Add(label);
            label.BackColor = Color.Gainsboro;
            label.ForeColor = Color.DodgerBlue;
            label.Font = new Font("Arial", 14, FontStyle.Bold);
            label.Location = new Point(rand.Next(Board.Size.Width) - label.Width, rand.Next(Board.Size.Height) - label.Height);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Show();
                
            
        }
        private void Send_Click(object sender, EventArgs e)
        {
            //Impacchetta il messaggio e lo spedisce

            Item attivita = new Item();
            attivita.Text = TestoAttivita.Text;
            attivita.Board = boardName.Text;
            attivita.Username = Usr.Text;
            attivita.Visibility = Public.Checked;
            PinMemo(attivita);
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
            if (Client != null)
            {
                Client.Disconnect();
                _form.Dispose();
            }
                
        }
    }
    
   
    
}
