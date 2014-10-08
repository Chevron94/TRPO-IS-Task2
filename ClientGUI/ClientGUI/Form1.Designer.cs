namespace ClientGUI
{
    partial class Form1
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ConnectClient = new System.Windows.Forms.ToolStripMenuItem();
            this.DisconnectClient = new System.Windows.Forms.ToolStripMenuItem();
            this.SendButton = new System.Windows.Forms.Button();
            this.MessageLog = new System.Windows.Forms.ListBox();
            this.MessageInput = new System.Windows.Forms.TextBox();
            this.NICK_FIELD = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IP_PORT_FIELD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Password_Field = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.NewUser = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConnectClient,
            this.DisconnectClient});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(448, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ConnectClient
            // 
            this.ConnectClient.Name = "ConnectClient";
            this.ConnectClient.Size = new System.Drawing.Size(64, 20);
            this.ConnectClient.Text = "Connect";
            this.ConnectClient.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // DisconnectClient
            // 
            this.DisconnectClient.Enabled = false;
            this.DisconnectClient.Name = "DisconnectClient";
            this.DisconnectClient.Size = new System.Drawing.Size(78, 20);
            this.DisconnectClient.Text = "Disconnect";
            this.DisconnectClient.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(12, 340);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(424, 23);
            this.SendButton.TabIndex = 1;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // MessageLog
            // 
            this.MessageLog.FormattingEnabled = true;
            this.MessageLog.HorizontalScrollbar = true;
            this.MessageLog.Location = new System.Drawing.Point(12, 79);
            this.MessageLog.Name = "MessageLog";
            this.MessageLog.Size = new System.Drawing.Size(424, 225);
            this.MessageLog.TabIndex = 2;
            // 
            // MessageInput
            // 
            this.MessageInput.Location = new System.Drawing.Point(12, 314);
            this.MessageInput.Name = "MessageInput";
            this.MessageInput.Size = new System.Drawing.Size(424, 20);
            this.MessageInput.TabIndex = 3;
            this.MessageInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MessageInput_KeyDown);
            // 
            // NICK_FIELD
            // 
            this.NICK_FIELD.Location = new System.Drawing.Point(78, 27);
            this.NICK_FIELD.Name = "NICK_FIELD";
            this.NICK_FIELD.Size = new System.Drawing.Size(137, 20);
            this.NICK_FIELD.TabIndex = 4;
            this.NICK_FIELD.Text = "NickName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "NickName:";
            // 
            // IP_PORT_FIELD
            // 
            this.IP_PORT_FIELD.Location = new System.Drawing.Point(78, 53);
            this.IP_PORT_FIELD.Name = "IP_PORT_FIELD";
            this.IP_PORT_FIELD.Size = new System.Drawing.Size(194, 20);
            this.IP_PORT_FIELD.TabIndex = 6;
            this.IP_PORT_FIELD.Text = "127.0.0.1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(52, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "IP:";
            // 
            // Password_Field
            // 
            this.Password_Field.Location = new System.Drawing.Point(323, 27);
            this.Password_Field.Name = "Password_Field";
            this.Password_Field.Size = new System.Drawing.Size(100, 20);
            this.Password_Field.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(253, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Password";
            // 
            // NewUser
            // 
            this.NewUser.AutoSize = true;
            this.NewUser.Location = new System.Drawing.Point(323, 53);
            this.NewUser.Name = "NewUser";
            this.NewUser.Size = new System.Drawing.Size(70, 17);
            this.NewUser.TabIndex = 10;
            this.NewUser.Text = "NewUser";
            this.NewUser.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(448, 375);
            this.Controls.Add(this.NewUser);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Password_Field);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.IP_PORT_FIELD);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NICK_FIELD);
            this.Controls.Add(this.MessageInput);
            this.Controls.Add(this.MessageLog);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Client";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem ConnectClient;
        private System.Windows.Forms.ToolStripMenuItem DisconnectClient;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.ListBox MessageLog;
        private System.Windows.Forms.TextBox MessageInput;
        private System.Windows.Forms.TextBox NICK_FIELD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox IP_PORT_FIELD;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Password_Field;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox NewUser;
    }
}

