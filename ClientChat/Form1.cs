using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;

namespace ClientChat
{
    public partial class Form1 : Form
    {
        TcpClient tcpClient;
        public Form1()
        {
            InitializeComponent();
        }

        private async void clientconnect_Click(object sender, EventArgs e)
        {
            tcpClient = new TcpClient();
            await tcpClient.ConnectAsync("127.0.0.1", 5000);

            MessageBox.Show("Connected to server!");
        }
    }
}
