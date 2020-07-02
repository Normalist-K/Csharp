using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket ServerSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Any, 50000);
            ServerSocket.Bind(ip);
            ServerSocket.Listen(5);

            Thread AcceptThread = new Thread(delegate () {
                while (true)
                {
                    Socket ClientSocket = ServerSocket.Accept();
                    Console.WriteLine("클라이언트 접속 성공 {0}", ClientSocket.RemoteEndPoint);

                    Thread RecvThread = new Thread(delegate(object objSocket)
                    {
                        Socket NewClientSocket = (Socket)objSocket;
                        byte[] recvData = new byte[4096];
                        while (true)
                        {
                            try
                            {
                                int iRecvLen = NewClientSocket.Receive(recvData);
                                string strMsg = Encoding.Default.GetString(recvData, 0, iRecvLen);
                                Console.WriteLine("{0}님의 메시지: {1}", NewClientSocket.RemoteEndPoint, strMsg);
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("{0}님이 접속을 끊었습니다.", NewClientSocket.RemoteEndPoint);
                                return;
                            }
                        }
                    });
                    RecvThread.Start(ClientSocket);
                }
            });
            AcceptThread.Start();
            

            Console.ReadLine(); // 프라이머리 쓰레드가 기다리도록.
            ServerSocket.Close();
            ServerSocket.Dispose();
        }
    }
}
