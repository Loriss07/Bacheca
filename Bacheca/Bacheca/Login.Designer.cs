namespace Bacheca
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Usr = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.Ip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.BoardName = new System.Windows.Forms.TextBox();
            this.Create = new System.Windows.Forms.Button();
            this.PrivateBoard = new System.Windows.Forms.CheckBox();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Usr
            // 
            this.Usr.Location = new System.Drawing.Point(116, 25);
            this.Usr.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Usr.Name = "Usr";
            this.Usr.Size = new System.Drawing.Size(243, 22);
            this.Usr.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(12, 174);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(139, 34);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Username";
            // 
            // Ip
            // 
            this.Ip.Location = new System.Drawing.Point(116, 116);
            this.Ip.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Ip.Name = "Ip";
            this.Ip.Size = new System.Drawing.Size(112, 22);
            this.Ip.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(88, 119);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(19, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "IP";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 70);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 6;
            this.label3.Text = "Nome bacheca";
            // 
            // BoardName
            // 
            this.BoardName.Location = new System.Drawing.Point(116, 66);
            this.BoardName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BoardName.Name = "BoardName";
            this.BoardName.Size = new System.Drawing.Size(243, 22);
            this.BoardName.TabIndex = 5;
            // 
            // Create
            // 
            this.Create.Location = new System.Drawing.Point(214, 174);
            this.Create.Name = "Create";
            this.Create.Size = new System.Drawing.Size(145, 34);
            this.Create.TabIndex = 7;
            this.Create.Text = "Crea nuova bacheca";
            this.Create.UseVisualStyleBackColor = true;
            this.Create.Click += new System.EventHandler(this.Create_Click);
            // 
            // PrivateBoard
            // 
            this.PrivateBoard.AutoSize = true;
            this.PrivateBoard.Location = new System.Drawing.Point(232, 212);
            this.PrivateBoard.Name = "PrivateBoard";
            this.PrivateBoard.Size = new System.Drawing.Size(127, 20);
            this.PrivateBoard.TabIndex = 8;
            this.PrivateBoard.Text = "Bacheca privata";
            this.PrivateBoard.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 183);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(15, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "o";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 244);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.PrivateBoard);
            this.Controls.Add(this.Create);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.BoardName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Ip);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.Usr);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Login";
            this.Text = "Login";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Usr;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Ip;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox BoardName;
        private System.Windows.Forms.Button Create;
        private System.Windows.Forms.CheckBox PrivateBoard;
        private System.Windows.Forms.Label label4;
    }
}