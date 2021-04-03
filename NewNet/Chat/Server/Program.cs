using System;
using System.Net;
using System.Net.Sockets;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            const int port = 11000;

            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress iPAddress = ipHost.AddressList[0];
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, port);

            Socket socket = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

        }
    }
}
