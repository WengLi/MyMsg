using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace SocketServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AppendLine(string msg)
        {
            if (textBox1.InvokeRequired)
            {
                this.Invoke(new Action(()=> 
                {
                    textBox1.AppendText(msg);
                    textBox1.AppendText(Environment.NewLine);
                }));
            }
            else
            {
                textBox1.AppendText(msg);
                textBox1.AppendText(Environment.NewLine);
            }
        }

        private static Socket socketwatch = null;
        private static Dictionary<string, Socket> clientConnectionItems = new Dictionary<string, Socket> { };

        private void button1_Click(object sender, EventArgs e)
        {
            socketwatch = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPAddress address = IPAddress.Parse("127.0.0.1");
            IPEndPoint point = new IPEndPoint(address, 9050);
            socketwatch.Bind(point);
            socketwatch.Listen(20);
            Thread thread = new Thread(WatchConnecting);
            thread.IsBackground = true;
            thread.Start();
            AppendLine("开启监听。。。");
        }

        private void WatchConnecting()
        {
            Socket connection = null;
            while (true)
            {
                try
                {
                    connection = socketwatch.Accept();
                }
                catch (Exception ex)
                {
                    AppendLine(ex.ToString());
                    break;
                }
                IPEndPoint ipEndPoint = (connection.RemoteEndPoint as IPEndPoint);
                IPAddress clientIp = ipEndPoint.Address;
                int clientPort = ipEndPoint.Port;
                string sengMsg = "连接本地服务器成功:" + clientIp + "-" + clientPort;
                byte[] arrSendMsg = Encoding.UTF8.GetBytes(sengMsg);
                connection.Send(arrSendMsg);

                string remoteEndPoint = connection.RemoteEndPoint.ToString();
                AppendLine("成功与" + remoteEndPoint + "客户端建立连接！\t\n");
                clientConnectionItems.Add(remoteEndPoint, connection);
                ParameterizedThreadStart pts = new ParameterizedThreadStart(Receive);
                Thread thread = new Thread(pts);
                thread.IsBackground = true;
                thread.Start(connection);
            }
        }

        private void Receive(object socketclientpara)
        {
            Socket socketServer = socketclientpara as Socket;
            while (true)
            {
                byte[] arrServerRecMsg = new byte[1024 * 1024];
                try
                {
                    int length = socketServer.Receive(arrServerRecMsg);
                    string strSRecMsg = Encoding.UTF8.GetString(arrServerRecMsg, 0, length);
                    AppendLine("客户端:" + socketServer.RemoteEndPoint + ",time:" + DateTime.Now + "\r\n" + strSRecMsg + "\r\n\n");
                }
                catch (Exception ex)
                {
                    clientConnectionItems.Remove(socketServer.RemoteEndPoint.ToString());
                    AppendLine("客户端" + socketServer.RemoteEndPoint + "已经中断连接" + "\r\n" + ex.Message + "\r\n" + ex.StackTrace + "\r\n");
                    socketServer.Close();
                    break;
                }
            }
        }
    }
}
