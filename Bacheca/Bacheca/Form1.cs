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
        private Point MouseDownLocation;
        private Label SelectedLabel;
        private List<Item> _items;

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
            _items = Client.Download(_boardname, _usr);
            foreach (Item memo in _items)
                PinMemo(memo);

            
        }
        private void PinMemo(Item memo)
        {
            //Mostra i promemoria
            Random rand = new Random();
            Label label = new Label();
            label.Name = memo.MemoID;
            label.Text = memo.Text;
            label.Padding = new Padding(4, 4, 4, 4);
            label.AutoSize = true;
            label.BackColor = Color.Gainsboro;
            label.ForeColor = Color.DodgerBlue;
            label.Font = new Font("Arial", 14, FontStyle.Bold);
            label.Location = new Point(rand.Next(Board.Size.Width) - label.Width, rand.Next(Board.Size.Height) - label.Height);
            label.TextAlign = ContentAlignment.MiddleCenter;
            label.Click += Memo_Click;
            label.MouseDown += Memo_MouseDown;
            label.MouseMove += Memo_MouseMove;
            label.CreateControl();
            Board.Controls.Add(label);
            label.Show();
        }
        private void CancelMemo(Label l)
        {
            l.Dispose();
        }
        private void Memo_Click(object sender, EventArgs e)
        {
            Label memo = sender as Label;
            DeleteMemo.Enabled = true;
            SelectedLabel = memo;
        }
        private void Memo_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }
        private void Memo_MouseMove(object sender, MouseEventArgs e)
        {
            Label a = sender as Label;
            if (e.Button == MouseButtons.Left)
            {
                a.Left = e.X + a.Left - MouseDownLocation.X;
                a.Top = e.Y + a.Top - MouseDownLocation.Y;
            }
                
            
        }
        private void Send_Click(object sender, EventArgs e)
        {
            //Impacchetta il messaggio e lo spedisce

            Item attivita = new Item();
            attivita.Text = TestoAttivita.Text;
            attivita.Board = boardName.Text;
            attivita.Username = Usr.Text;
            attivita.Visibility = Public.Checked;
            attivita.CDate = DateTime.Now;
            attivita.Date = DateSave.Value;
            PinMemo(attivita);
            Client.Send(attivita);
            TestoAttivita.Text = "";
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

        private void DeleteMemo_Click(object sender, EventArgs e)
        {
            string memo_id = SelectedLabel.Name;
            bool found = false;
            int i = 0;
            while (!found && i < _items.Count)
            {
                if (_items[i].MemoID == memo_id)
                    found = true;
                i++;
            }
            if (i > -1)
            {
                Client.Remove(_items[i - 1]);
                _items.RemoveAt(i - 1);
            }

            foreach (Label label in Board.Controls)
            {
                CancelMemo(label);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Client.Delete(BoardName);
            Hide();
            _form.Show();
        }
    }
    
   
    
}
