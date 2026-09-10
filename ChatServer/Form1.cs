using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatServer
{
    public partial class Form1 : Form
    {
        TcpListener tcpListener;
            
        public Form1()
        {
            InitializeComponent();
        }

        private async void server_Click(object sender, EventArgs e)
        {
            tcpListener=new TcpListener(IPAddress.Parse("127.0.0.1"),5000);
            tcpListener.Start();
            MessageBox.Show("Server started");
            TcpClient client = await tcpListener.AcceptTcpClientAsync();
            MessageBox.Show("Client connected!");
            NetworkStream stream = client.GetStream();
            StreamReader reader = new StreamReader(stream);
            StreamWriter writer = new StreamWriter(stream);

            while (true)
            {
                string msg = await reader.ReadLineAsync();
                MessageBox.Show(msg);

                await writer.WriteLineAsync(msg);
                await writer.FlushAsync();
            }
            

        }
    }
}
