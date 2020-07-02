using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
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

            Socket ClientSocket = ServerSocket.Accept();
            Console.WriteLine("클라이언트 접속 성공 {0}", ClientSocket.RemoteEndPoint);

            byte[] recvData = new byte[4096];
            while (true)
            {
                int iRecvLen = ClientSocket.Receive(recvData);
                string strMsg = Encoding.Default.GetString(recvData, 0, iRecvLen);
                Console.WriteLine(strMsg);

                strMsg = Console.ReadLine();
                byte[] sendData = Encoding.Default.GetBytes(strMsg);
                ClientSocket.Send(sendData);
            }

            ServerSocket.Close();
            ServerSocket.Dispose();
        }
    }
}
