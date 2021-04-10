using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace Server
{
    class Program
    {
        static void ClientThreadProc(object socket)
        {
            Socket clientSocket = (Socket)socket;

            try
            {
                while(true)
                {
                    // Получаем данные от клиента. Ожидаем пока полностью их не получим,
                    // потому что метод Receive — это тоже блокирующий метод.
                    byte[] bytes = new byte[1024];
                    int bytesReceived = clientSocket.Receive(bytes);

                    string data = Encoding.UTF8.GetString(bytes, 0, bytesReceived);

                    // Показываем данные на консоли
                    Console.WriteLine($"Get from {clientSocket.RemoteEndPoint}:\n {data}");

                    // Отправляем ответ клиенту
                    string reply = $"Thanks lenght {data.Length} signet";
                    byte[] msg = Encoding.UTF8.GetBytes(reply);
                    // В этом месте мы ожидаем, пока все данные будут отправлены,
                    // поскольку метод Send — это тоже блокирующий метод
                    clientSocket.Send(msg);

                    // Проверяем не хочет ли клиент закончить сеанс связи
                    if (data.Trim() == "exit")
                    {
                        Console.WriteLine($"Disconnect {clientSocket.RemoteEndPoint}.");
                        break;
                    }
                }
            }
            catch(SocketException)
            {
                Console.WriteLine($"Connect with {clientSocket.RemoteEndPoint} disconnect.");
            }
            finally
            {
                // Закрываем сокет
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }
        }

        static void Main(string[] args)
        {
            const int port = 11000;

            IPHostEntry ipHost = Dns.GetHostEntry("localhost");
            IPAddress iPAddress = ipHost.AddressList[0];
            IPEndPoint iPEndPoint = new IPEndPoint(iPAddress, port);

            Socket socketListener = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try
            {
                socketListener.Bind(iPEndPoint);
                socketListener.Listen(10);

                Console.WriteLine($"Whait connect to port {iPEndPoint.Port}...");

                // Начинаем слушать соединения
                while (true)
                {
                    Socket socket = socketListener.Accept();
                    // Мы дождались клиента, пытающегося с нами соединиться
                    Console.WriteLine($"Connection {socket.RemoteEndPoint}.");

                    Thread thread = new Thread(new ParameterizedThreadStart(ClientThreadProc));
                    thread.IsBackground = true;
                    thread.Start(socket);

                }

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
