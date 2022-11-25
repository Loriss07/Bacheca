
namespace Bacheca
{
    partial class Client_Bacheca
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            this.TestoAttivita = new System.Windows.Forms.TextBox();
            this.Send = new System.Windows.Forms.Button();
            this.Public = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Usr = new System.Windows.Forms.Label();
            this.Board = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TestoAttivita
            // 
            this.TestoAttivita.Location = new System.Drawing.Point(258, 329);
            this.TestoAttivita.Multiline = true;
            this.TestoAttivita.Name = "TestoAttivita";
            this.TestoAttivita.Size = new System.Drawing.Size(529, 109);
            this.TestoAttivita.TabIndex = 0;
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(793, 415);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(58, 23);
            this.Send.TabIndex = 1;
            this.Send.Text = "Invia";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // Public
            // 
            this.Public.AutoSize = true;
            this.Public.Location = new System.Drawing.Point(12, 343);
            this.Public.Name = "Public";
            this.Public.Size = new System.Drawing.Size(67, 17);
            this.Public.TabIndex = 2;
            this.Public.Text = "Pubblico";
            this.Public.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(98, 343);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(116, 17);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.Text = "Salva come attività";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(12, 414);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(113, 20);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(12, 121);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 5;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(22, 11);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(49, 46);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Usr
            // 
            this.Usr.AutoSize = true;
            this.Usr.Location = new System.Drawing.Point(77, 29);
            this.Usr.Name = "Usr";
            this.Usr.Size = new System.Drawing.Size(55, 13);
            this.Usr.TabIndex = 8;
            this.Usr.Text = "Username";
            // 
            // Board
            // 
            this.Board.BackColor = System.Drawing.Color.Gainsboro;
            this.Board.Location = new System.Drawing.Point(258, 22);
            this.Board.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Board.Name = "Board";
            this.Board.Size = new System.Drawing.Size(593, 301);
            this.Board.TabIndex = 9;
            this.Board.Paint += new System.Windows.Forms.PaintEventHandler(this.Client_Bacheca_Paint);
            // 
            // Client_Bacheca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 450);
            this.Controls.Add(this.Board);
            this.Controls.Add(this.Usr);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.Public);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.TestoAttivita);
            this.Name = "Client_Bacheca";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_Bacheca_FormClosed);
            this.Load += new System.EventHandler(this.Client_Bacheca_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TestoAttivita;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.CheckBox Public;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label Usr;
        private System.Windows.Forms.Panel Board;
    }
}

