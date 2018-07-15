using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UTTTClient
{
    public partial class Auth : Form
    {
        public Auth()
        {
            InitializeComponent();
        }

        public bool isConnected = false;
        private Thread clientThread;

        private void Auth_Load(object sender, EventArgs e)
        {
            clientThread = new Thread(new ThreadStart(ConnectionWait));
            clientThread.Start();
        }

        private void ConnectionWait()
        {
            while (true)
            {
                if (ConnectionCheck())
                {
                    isConnected = true;
                }
                else
                {
                    isConnected = false;
                }
                Thread.Sleep(300);
            }
        }

        private bool ConnectionCheck()
        {
            if (Client.SendMessage("Connection check") == "Connection error")
            {
                return false;
            }
            return true;
        }

        private void Update_Tick(object sender, EventArgs e)
        {
            if (isConnected)
            {
                connectionStatus.Text = "Status: server is online";
                LogIn.Enabled = true;
                SignIn.Enabled = true;
            }
            else
            {
                connectionStatus.Text = "Status: server is offline";
                LogIn.Enabled = false;
                SignIn.Enabled = false;
            }
        }

        private void Auth_FormClosing(object sender, FormClosingEventArgs e)
        {
            CloseThread();
        }

        private void CloseThread()
        {
            clientThread.Abort();
            clientThread.Join(300);
        }

        private bool SomeFieldsAreEmpty()
        {
            return loginField.Text == String.Empty || passwordField.Text == String.Empty;
        }

        private void LogIn_Click(object sender, EventArgs e)
        {
            if (SomeFieldsAreEmpty())
            {
                MessageBox.Show("Some fields are empty.");
                return;
            }
            String request = "LogIn;" + loginField.Text.ToUpper() + ";" + passwordField.Text;
            String response = Client.SendMessage(request);

            if (response == "ERROR")
            {
                MessageBox.Show("Invalid login or password.");
            }
            else
            {
                Client.SetToken(response);
                Client.SetLogin(loginField.Text);
                new Menu(true).Show();
                this.Hide();
                CloseThread();
            }
        }

        private void SignIn_Click(object sender, EventArgs e)
        {
            if (SomeFieldsAreEmpty())
            {
                MessageBox.Show("Some fields are empty.");
                return;
            }
            String request = "SignIn;" + loginField.Text.ToUpper() + ";" + passwordField.Text;
            String response = Client.SendMessage(request);
            if (response == "ERROR")
            {
                MessageBox.Show("This user already exist.");
            }
            else
            {
                Client.SetToken(response);
                Client.SetLogin(loginField.Text);
                new Menu(true).Show();
                this.Hide();
                CloseThread();
            }
        }

        private void offline_Click(object sender, EventArgs e)
        {
            new Menu(false).Show();
            this.Hide();
            CloseThread();
        }
    }
}
