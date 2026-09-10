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
using System.IO;

namespace ClientChat
{
    public partial class Form1 : Form
    {
        TcpClient tcpClient;
        NetworkStream stream;
        public Form1()
        {
            InitializeComponent();
        }

        private async void clientconnect_Click(object sender, EventArgs e)
        {
            tcpClient = new TcpClient();
            await tcpClient.ConnectAsync("127.0.0.1", 5000);
            stream=tcpClient.GetStream();

            MessageBox.Show("Connected to server!");
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            StreamWriter writer = new StreamWriter(stream);
            await writer.WriteLineAsync(msg.Text);
            await writer.FlushAsync();

            StreamReader reader = new StreamReader(stream);
            string msgs = await reader.ReadLineAsync();
            MessageBox.Show(msgs);
        }
    }
}
