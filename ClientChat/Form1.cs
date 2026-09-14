using System;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientChat
{
    public partial class Form1 : Form
    {
        TcpClient tcpClient;
        NetworkStream stream;

        StreamReader reader;
        StreamWriter writer;

        public Form1()
        {
            InitializeComponent();
        }

        private async void clientconnect_Click(object sender, EventArgs e)
        {
            try
            {
                tcpClient = new TcpClient();

                await tcpClient.ConnectAsync("127.0.0.1", 5000);

                stream = tcpClient.GetStream();

                reader = new StreamReader(stream);
                writer = new StreamWriter(stream);

                rtbChat.AppendText("Connected to server." +
                    Environment.NewLine);

                _ = ReceiveMessages();

                clientconnect.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Could not connect to server: " + ex.Message
                );
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
                        rtbChat.AppendText(
                            "Server disconnected." +
                            Environment.NewLine
                        );

                        break;
                    }

                    rtbChat.AppendText(
                        "Server: " + message +
                        Environment.NewLine
                    );
                }
            }
            catch (Exception ex)
            {
                rtbChat.AppendText(
                    "Connection error: " +
                    ex.Message +
                    Environment.NewLine
                );
            }
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            if (writer == null)
            {
                MessageBox.Show(
                    "Connect to the server first."
                );

                return;
            }

            if (string.IsNullOrWhiteSpace(txtMessage.Text))
            {
                return;
            }

            try
            {
                string message = txtMessage.Text;

                await writer.WriteLineAsync(message);
                await writer.FlushAsync();

                rtbChat.AppendText(
                    "Client: " + message +
                    Environment.NewLine
                );

                txtMessage.Clear();
                txtMessage.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Failed to send message: " +
                    ex.Message
                );
            }
        }
    }
}