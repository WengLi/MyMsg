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

namespace MyMsg
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AppendLine(string msg)
        {
            socketText.AppendText(msg);
            socketText.AppendText(Environment.NewLine);
        }

        private Socket socketClient;
        private IPEndPoint ipEndPoint;

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] data = new byte[1024];
            socketClient = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            if (string.IsNullOrWhiteSpace(ipAddressText.Text))
            {
                AppendLine("please input the server ip address！");
                return;
            }
            if (string.IsNullOrWhiteSpace(ipPortText.Text))
            {
                AppendLine("please input the server ip port！");
                return;
            }
            ipEndPoint = new IPEndPoint(IPAddress.Parse(ipAddressText.Text), int.Parse(ipPortText.Text));//服务器的IP和端口
            try
            {
                //因为客户端只是用来向特定的服务器发送信息，所以不需要绑定本机的IP和端口。不需要监听。
                socketClient.Connect(ipEndPoint);
            }
            catch (SocketException ex)
            {
                AppendLine("unable to connect to server");
                AppendLine(ex.ToString());
                return;
            }
            int recv = socketClient.Receive(data);
            string stringdata = Encoding.UTF8.GetString(data, 0, recv);
            AppendLine(stringdata);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (socketClient == null || !socketClient.IsBound)
            {
                AppendLine("unable to connect to server");
            }
            byte[] data = new byte[1024];
            socketClient.Send(Encoding.UTF8.GetBytes(txtContent.Text));
            int recv = socketClient.Receive(data);
            string stringdata = Encoding.UTF8.GetString(data, 0, recv);
            AppendLine(stringdata);
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (socketClient != null && socketClient.IsBound)
            {
                socketClient.Shutdown(SocketShutdown.Both);
                socketClient.Close();
            }
        }
    }
}
