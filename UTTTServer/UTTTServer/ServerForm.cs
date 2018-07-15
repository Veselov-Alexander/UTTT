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

namespace UTTTServer
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
        }

        Thread serverThread;
        int timer = 0;

        private void ServerForm_Load(object sender, EventArgs e)
        {
            serverThread = new Thread(new ThreadStart(Server.Run));
            serverThread.Start();
            Database.Open();
        }

        private void AppendLog()
        {
            String text = Server.PushLog();
            if (text != String.Empty && text != null)
            {
                log.AppendText(text);
            }
        }

        private void Update_Tick(object sender, EventArgs e)
        {
            AppendLog();
            if (++timer % 10 == 0)
            {
                Server.UpdateTime();
                timer = 0;
            }
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Server.Close();
            Database.Close();
        }
    }
}
