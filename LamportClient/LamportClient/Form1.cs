using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LamportClient
{
    public partial class Form1 : Form
    {
        private Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        private byte[] buffer = new byte[1024];
        private bool firstMsg = true;
        private Form form;
        private System.Windows.Forms.Timer timer;
        private int time = 0;
        private Random random = new Random();

        private int id;

        public Form1()
        {
            InitializeComponent();
            form = this;

            timer = new System.Windows.Forms.Timer();
            timer.Interval = random.Next(100, 2000);
            timer.Start();
            timer.Tick += new EventHandler(TimerTick);

        }

        private void TimerTick(object sender, EventArgs e)
        {
            clock.Text = "" + (++time);
        }
                
        private void LoopConnect(string serverAddr)
        {
            int attempts = 0;
            while (!clientSocket.Connected)
            {
                try
                {
                    attempts++;
                    clientSocket.Connect(serverAddr, 100);
                }
                catch (SocketException)
                {
                    AddStat("Connection attempts: " + attempts);
                }
            }
            AddStat("Connected");

            clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), clientSocket);
        }

        private void SendText(string text)
        {
            byte[] data = Encoding.ASCII.GetBytes(text);
            clientSocket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), clientSocket);
            clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), clientSocket);
        }

        private void SendCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            socket.EndSend(AR);
        }

        private void ReceiveCallback(IAsyncResult AR)
        {
            Socket socket = (Socket)AR.AsyncState;
            int received = socket.EndReceive(AR);
            byte[] dataBuff = new byte[received];
            Array.Copy(buffer, dataBuff, received);

            string text = Encoding.ASCII.GetString(dataBuff);
            if (firstMsg)
            {
                log.BeginInvoke(new MethodInvoker(() => form.Text = "Client [" + text + "]"));
                firstMsg = false;
                id = int.Parse(text);
            }
            else
            {
                if (text.Equals("No such client"))
                {
                    AddStat(text);
                }
                else
                {
                    string[] data = text.Split(' ');
                    AddStat(data[0] + " -> " + data[1] + " : " + data[2]);

                    int timestamp = int.Parse(data[2]);
                    if (time < timestamp)
                    {
                        AddStat("Sending time : " + timestamp + "\tReceiving time : " + time);
                        AddStat("Changing time to " + (timestamp + 1));
                        time = timestamp + 1;
                        clock.BeginInvoke(new MethodInvoker(() => clock.Text = time.ToString()));
                        //AddStat("-----------------------------------------------");
                    }
                    else
                    {
                        AddStat("Sending time : " + timestamp + "\tReceiving time : " + time);
                    }
                }
            }
            clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), clientSocket);
        }

        public void AddStat(String s)
        {
            try
            {
                log.BeginInvoke(new MethodInvoker(() => log.AppendText(s + System.Environment.NewLine)));
            }
            catch (InvalidOperationException)
            {

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dest = destination.Text.ToString();
            SendText(id + " " + dest + " " + time);
            AddStat(id + " -> " + dest + " : " + time);
            AddStat("-----------------------------------------------");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void connect_Click(object sender, EventArgs e)
        {
            if (serverAddress.Text != null || !serverAddress.Text.ToString().Equals(""))
            {
                LoopConnect(serverAddress.Text.ToString());
            }
        }
    }
}
