using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket RemoteSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint ip = new IPEndPoint(IPAddress.Parse("192.168.0.12"), 50000); // 내 서버 IP
            IPEndPoint ip2 = new IPEndPoint(IPAddress.Parse("192.168.0.44"), 50000); // 강사님 서버 IP
            RemoteSocket.Connect(ip2);

            byte[] recvData = new byte[4096];
            while (true)
            {
                string strMsg = Console.ReadLine();
                byte[] sendData = Encoding.Default.GetBytes(strMsg);
                RemoteSocket.Send(sendData);


                //int iRecvLen = RemoteSocket.Receive(recvData);
                //strMsg = Encoding.Default.GetString(recvData, 0, iRecvLen);
                //Console.WriteLine(strMsg);
            }

            RemoteSocket.Close();
            RemoteSocket.Dispose();
        }
    }
}
