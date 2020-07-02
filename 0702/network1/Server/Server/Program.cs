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

            Socket ClientSocket = ServerSocket.Accept(); // client 접속할 때까지 멈춰있음
            Console.WriteLine("클라이언트 접속 성공 {0}", ClientSocket.RemoteEndPoint);

            byte[] recvBuffer = new byte[4096];
            while (true)
            {
                int iRecvLen = ClientSocket.Receive(recvBuffer);
                string strMsg = Encoding.Default.GetString(recvBuffer, 0, iRecvLen);
                Console.WriteLine(strMsg);

                strMsg = Console.ReadLine();
                byte [] sendData = Encoding.Default.GetBytes(strMsg);
                ClientSocket.Send(sendData);
            }

            ServerSocket.Close();
            ServerSocket.Dispose();
        }
    }
}
