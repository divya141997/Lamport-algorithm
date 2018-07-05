using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LamportServer
{
    public partial class serverForm : Form
    {
        private Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private List<Socket> clientSockets = new List<Socket>();
        private List<bool> live = new List<bool>();
        private byte[] buffer = new byte[1024];
        private int idCount = 0;

        public serverForm()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void AddStat(String s)
        {
            log.BeginInvoke(new MethodInvoker(() => log.AppendText(s + System.Environment.NewLine)));
        }

        private void SetupServer()
        {
            AddStat("Setting up server..");
            serverSocket.Bind(new IPEndPoint(IPAddress.Any, 100));
            serverSocket.Listen(10);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            AddStat("Waiting for connection...");
        }

        private void AcceptCallback(IAsyncResult AR)
        {
            Socket socket = serverSocket.EndAccept(AR);
            clientSockets.Add(socket);
            live.Add(true);
            AddStat("Client connected.");
            socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
            SendText(socket, "" + idCount);
            idCount++;
        }

        private void ReceiveCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            int received = 0;
            try
            {
                received = socket.EndReceive(AR);
            }
            catch (SocketException)
            {
                handleSocketException(socket);
            }
            byte[] dataBuff = new byte[received];
            Array.Copy(buffer, dataBuff, received);

            string text = Encoding.ASCII.GetString(dataBuff);
            string[] data = text.Split(' ');
            int dest = 0;
            try
            {
                dest = int.Parse(data[1]);
                if (dest < clientSockets.Count && live[dest])
                {
                    SendText(clientSockets[dest], text);
                    AddStat(data[0] + " -> " + data[1] + " : " + data[2]);
                }
                else
                {
                    int src = int.Parse(data[0]);
                    SendText(clientSockets[src], "No such client");
                }
            }
            catch (IndexOutOfRangeException)
            {
                AddStat("No such client [" + dest + "]");
            }

            try
            {
                socket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), socket);
            }
            catch (SocketException)
            {
                handleSocketException(socket);
            }
        }

        private void SendText(Socket socket, string text)
        {
            byte[] data = Encoding.ASCII.GetBytes(text);
            try
            {
                socket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), socket);
            }
            catch (SocketException)
            {
                handleSocketException(socket);
            }
        }

        private void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }

        private void handleSocketException(Socket socket)
        {
            int index = clientSockets.IndexOf(socket);
            if (index >= 0 && live[index])
            {
                AddStat("Client [" + index + "] disconnected.");
                live[index] = false;
            }
        }

        private void serverForm_Load(object sender, EventArgs e)
        {
            SetupServer();
            ip.Text = Dns.GetHostByName(Dns.GetHostName()).AddressList[0].ToString();
        }
    }
}
