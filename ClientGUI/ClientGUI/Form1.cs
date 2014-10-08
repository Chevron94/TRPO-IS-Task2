using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ClientGUI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Connected = false;
            Application.Idle += MyIdle;
        }

        void MyIdle(object sender, EventArgs e)
        {
            if (Client != null)
            {
                Connected = Client.CONNECTED;
            }
            ConnectClient.Enabled = !Connected && NICK_FIELD.Text.Trim() != "" && Password_Field.Text.Trim() != "" && IP_PORT_FIELD.Text.Trim() != "";
            DisconnectClient.Enabled = Connected;
            NICK_FIELD.Enabled = !Connected;
            IP_PORT_FIELD.Enabled = !Connected;
            Password_Field.Enabled = !Connected;
            SendButton.Enabled = Connected && MessageInput.Text.Trim() != "";
            NewUser.Enabled = !Connected;
            MessageLog.SelectedIndex = MessageLog.Items.Count - 1;
            MessageLog.SelectedIndex = -1;
        }

        Client Client;
        bool Connected;
        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client = new Client(IP_PORT_FIELD.Text, 6008, NICK_FIELD.Text, Password_Field.Text,NewUser.Checked, ref MessageLog);
            try
            {
                Client.Connect();
                Connected = true;
            }
            catch (Exception)
            { MessageBox.Show("Server not responding"); }
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            Client.SendMessage(NICK_FIELD.Text+": "+MessageInput.Text);
            MessageInput.Text = "";
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Client.Disconnect();
            Connected = false;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Connected)
                Client.Disconnect();
       
        }

        private void MessageInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
                SendButton.PerformClick();
        }

    }
}
