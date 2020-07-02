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
                    Socket ClientSocket = m_ServerSocket.Accept();
                    Client NewClient = new Client(ClientSocket);
                    NewClient.ClientRecvEvent += NewClient_ClientRecvEvent;
                    NewClient.ClientDisConnEvent += NewClient_ClientDisConnEvent;
                    Dispatcher.Invoke(() => listConnUser.Items.Add(NewClient.ClientInfo));
                    NewClient.Recv();
                }

            });
            AcceptThread.Start();
        }

        private void NewClient_ClientDisConnEvent(Client delClient)
        {
            Dispatcher.Invoke(delegate()
            {
                int iIndex = listConnUser.Items.IndexOf(delClient.ClientInfo);
                listConnUser.Items.RemoveAt(iIndex);
            });
        }

        private void NewClient_ClientRecvEvent(string strMsg)
        {
            Dispatcher.Invoke(delegate ()
            {
                int iIndex = listRecvMsg.Items.Add(strMsg);
                listRecvMsg.ScrollIntoView(listRecvMsg.Items[iIndex]);
            });
        }

        Socket m_ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
    }
    class Client
    {
        public Client(Socket ClientSocket)
        {
            m_ClientSocket = ClientSocket;
            m_strClientInfo = m_ClientSocket.RemoteEndPoint.ToString();
        }
        public string ClientInfo
        {
            get
            {
                return m_strClientInfo;
            }
        }
        public void Recv()
        {
            Thread RecvTread = new Thread(delegate ()
            {
                byte[] data = new byte[4096];
                while (true)
                {
                    try
                    {
                        int iRecvLen = m_ClientSocket.Receive(data);
                        string strMsg = Encoding.Default.GetString(data, 0, iRecvLen);
                        ClientRecvEvent(strMsg);
                    }
                    catch (Exception)
                    {
                        ClientDisConnEvent(this);
                        return;
                    }
                }
            });
            RecvTread.Start();
        }
        public void Send(string strSend)
        {
            try
            {
                byte[] data = Encoding.Default.GetBytes(strSend);
                m_ClientSocket.Send(data);
            }
            catch (Exception)
            {
                ClientDisConnEvent(this);
                return;
            }
        }
        public void Dispose()
        {
            m_ClientSocket.Close();
            m_ClientSocket.Dispose();
        }
        private string m_strClientInfo;
        private Socket m_ClientSocket;
        public event Action<string> ClientRecvEvent;
        public event Action<Client> ClientDisConnEvent;
    }
    class ClientMgr
    {
        List<Client> m_ClientList = new List<Client>();
    }
}
