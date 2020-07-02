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

namespace Server
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

        private void btnStartServer_Click(object sender, RoutedEventArgs e)
        {
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 50000);
            m_ServerSocket.Bind(ip);
            m_ServerSocket.Listen(5);

            Thread AcceptThread = new Thread(delegate ()
            {
                while (true)
                {
                    Socket ClientSocekt = m_ServerSocket.Accept();
                    Dispatcher.Invoke(() => listConnUser.Items.Add(ClientSocekt.RemoteEndPoint));
                    // Dispatcher: 메시지큐에 action 함수를 넣어줌 -> 메인쓰레드에서 처리할 수 있도록
                    Thread RecvTread = new Thread(delegate (object objSocket)
                    {
                        Socket NewClientSocket = (Socket)objSocket;
                        byte[] data = new byte[4096];
                        while (true)
                        {
                            int iRecvLen = NewClientSocket.Receive(data);
                            string strMsg = Encoding.Default.GetString(data, 0, iRecvLen);
                            Dispatcher.Invoke(delegate ()
                            {
                                int iIndex = listRecvMsg.Items.Add(strMsg);
                                listRecvMsg.ScrollIntoView(listRecvMsg.Items[iIndex]);
                            });
                        }
                    });
                    RecvTread.Start(ClientSocekt);
                }

            });
            AcceptThread.Start();
        }
        Socket m_ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }
}
