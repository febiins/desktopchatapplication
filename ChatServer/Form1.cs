using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatServer
{
    public partial class Form1 : Form
    {
        TcpListener tcpListener;

        TcpClient client;
        NetworkStream stream;

        StreamReader reader;
        StreamWriter writer;

        public Form1()
        {
            InitializeComponent();
        }

        private async void server_Click(object sender, EventArgs e)
        {
            try
            {
                tcpListener = new TcpListener(
                    IPAddress.Loopback,
                    5000
                );

                tcpListener.Start();

                rtbChat.AppendText("Server started...\r\n");
                rtbChat.AppendText("Waiting for client...\r\n");

                client = await tcpListener.AcceptTcpClientAsync();

                rtbChat.AppendText("Client connected!\r\n");

                stream = client.GetStream();

                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);

                _ = ReceiveMessages();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private async Task ReceiveMessages()
        {
            try
            {
                while (true)
                {
                    string message = await reader.ReadLineAsync();

                    if (message == null)
                    {
                        rtbChat.AppendText("Client disconnected.\r\n");
                        break;
                    }

                    rtbChat.AppendText(
                        "Client: " + message + Environment.NewLine
                    );
                }
            }
            catch (Exception ex)
            {
                rtbChat.AppendText(
                    "Connection error: " + ex.Message + Environment.NewLine
                );
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (writer == null)
            {
                MessageBox.Show("Client is not connected.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMessage.Text))
                return;

            try
            {
                string message = txtMessage.Text;

                await writer.WriteLineAsync(message);
                await writer.FlushAsync();

                rtbChat.AppendText(
                    "Server: " + message + Environment.NewLine
                );

                txtMessage.Clear();
                txtMessage.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to send message: " + ex.Message);
            }
        }
    }
}