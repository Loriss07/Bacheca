
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
            this.DateSave = new System.Windows.Forms.DateTimePicker();
            this.Usr = new System.Windows.Forms.Label();
            this.Board = new System.Windows.Forms.Panel();
            this.boardName = new System.Windows.Forms.Label();
            this.DeleteMemo = new System.Windows.Forms.Button();
            this.DeleteBoard = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TestoAttivita
            // 
            this.TestoAttivita.Location = new System.Drawing.Point(220, 405);
            this.TestoAttivita.Margin = new System.Windows.Forms.Padding(4);
            this.TestoAttivita.Multiline = true;
            this.TestoAttivita.Name = "TestoAttivita";
            this.TestoAttivita.Size = new System.Drawing.Size(702, 133);
            this.TestoAttivita.TabIndex = 0;
            // 
            // Send
            // 
            this.Send.Location = new System.Drawing.Point(930, 501);
            this.Send.Margin = new System.Windows.Forms.Padding(4);
            this.Send.Name = "Send";
            this.Send.Size = new System.Drawing.Size(110, 41);
            this.Send.TabIndex = 1;
            this.Send.Text = "Salva";
            this.Send.UseVisualStyleBackColor = true;
            this.Send.Click += new System.EventHandler(this.Send_Click);
            // 
            // Public
            // 
            this.Public.AutoSize = true;
            this.Public.Location = new System.Drawing.Point(930, 473);
            this.Public.Margin = new System.Windows.Forms.Padding(4);
            this.Public.Name = "Public";
            this.Public.Size = new System.Drawing.Size(82, 20);
            this.Public.TabIndex = 2;
            this.Public.Text = "Pubblico";
            this.Public.UseVisualStyleBackColor = true;
            // 
            // DateSave
            // 
            this.DateSave.Location = new System.Drawing.Point(930, 405);
            this.DateSave.Margin = new System.Windows.Forms.Padding(4);
            this.DateSave.Name = "DateSave";
            this.DateSave.Size = new System.Drawing.Size(204, 22);
            this.DateSave.TabIndex = 4;
            // 
            // Usr
            // 
            this.Usr.AutoSize = true;
            this.Usr.Font = new System.Drawing.Font("Gadugi", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Usr.Location = new System.Drawing.Point(13, 27);
            this.Usr.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Usr.Name = "Usr";
            this.Usr.Size = new System.Drawing.Size(184, 45);
            this.Usr.TabIndex = 8;
            this.Usr.Text = "Username";
            // 
            // Board
            // 
            this.Board.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(75)))));
            this.Board.Location = new System.Drawing.Point(220, 27);
            this.Board.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Board.Name = "Board";
            this.Board.Size = new System.Drawing.Size(915, 370);
            this.Board.TabIndex = 9;
            this.Board.Paint += new System.Windows.Forms.PaintEventHandler(this.Client_Bacheca_Paint);
            // 
            // boardName
            // 
            this.boardName.AutoSize = true;
            this.boardName.Font = new System.Drawing.Font("Gadugi", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.boardName.Location = new System.Drawing.Point(80, 100);
            this.boardName.Name = "boardName";
            this.boardName.Size = new System.Drawing.Size(117, 45);
            this.boardName.TabIndex = 10;
            this.boardName.Text = "Board";
            // 
            // DeleteMemo
            // 
            this.DeleteMemo.Enabled = false;
            this.DeleteMemo.Location = new System.Drawing.Point(12, 405);
            this.DeleteMemo.Name = "DeleteMemo";
            this.DeleteMemo.Size = new System.Drawing.Size(201, 53);
            this.DeleteMemo.TabIndex = 12;
            this.DeleteMemo.Text = "Elimina promemoria";
            this.DeleteMemo.UseVisualStyleBackColor = true;
            this.DeleteMemo.Click += new System.EventHandler(this.DeleteMemo_Click);
            // 
            // DeleteBoard
            // 
            this.DeleteBoard.Location = new System.Drawing.Point(12, 487);
            this.DeleteBoard.Name = "DeleteBoard";
            this.DeleteBoard.Size = new System.Drawing.Size(201, 51);
            this.DeleteBoard.TabIndex = 13;
            this.DeleteBoard.Text = "Elimina bacheca";
            this.DeleteBoard.UseVisualStyleBackColor = true;
            this.DeleteBoard.Click += new System.EventHandler(this.button1_Click);
            // 
            // Client_Bacheca
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1173, 554);
            this.Controls.Add(this.DeleteBoard);
            this.Controls.Add(this.DeleteMemo);
            this.Controls.Add(this.boardName);
            this.Controls.Add(this.Board);
            this.Controls.Add(this.Usr);
            this.Controls.Add(this.DateSave);
            this.Controls.Add(this.Public);
            this.Controls.Add(this.Send);
            this.Controls.Add(this.TestoAttivita);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Client_Bacheca";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Client_Bacheca_FormClosed);
            this.Load += new System.EventHandler(this.Client_Bacheca_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TestoAttivita;
        private System.Windows.Forms.Button Send;
        private System.Windows.Forms.CheckBox Public;
        private System.Windows.Forms.DateTimePicker DateSave;
        private System.Windows.Forms.Label Usr;
        private System.Windows.Forms.Panel Board;
        private System.Windows.Forms.Label boardName;
        private System.Windows.Forms.Button DeleteMemo;
        private System.Windows.Forms.Button DeleteBoard;
    }
}

