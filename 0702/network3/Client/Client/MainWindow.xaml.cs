using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private Socket m_RemoteSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("192.168.0.12"), 50000);
            IPEndPoint ip2 = new IPEndPoint(IPAddress.Parse("192.168.0.44"), 50000);
            m_RemoteSocket.Connect(ip2);

            Thread RecvThread = new Thread(delegate ()
            {
                byte[] data = new byte[4096];
                while (true)
                {
                    try
                    {
                        int iRecvLen = m_RemoteSocket.Receive(data);
                        string strMsg = Encoding.Default.GetString(data, 0, iRecvLen);
                        Dispatcher.Invoke(() => listRecv.Items.Add(strMsg));
                    }
                    catch (Exception)
                    {
                        return;
                    }
                }
            });
            RecvThread.Start();
        }

        private void textSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                byte[] data = Encoding.Default.GetBytes(textSend.Text);
                m_RemoteSocket.Send(data);
                listRecv.Items.Add(textSend.Text);
                textSend.Text = "";
            }
        }
    }
}
