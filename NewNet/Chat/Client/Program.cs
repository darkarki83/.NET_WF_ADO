using System;
using System.Text;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            const int port = 11000;
            try
            {
                byte[] bytes = new byte[1024];

                // Соединяемся с удаленным устройством
                
                // Устанавливаем удаленную точку для сокета
                IPHostEntry ipHost = Dns.GetHostEntry("localhost");
                IPAddress ipAddr = ipHost.AddressList[0];
                IPEndPoint iPEndPoint = new IPEndPoint(ipAddr, port);

                // Создаем сокет TCP/IP для работы с сервером
                Socket sender = new Socket(ipAddr.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Соединяем сокет с удаленной точкой
                sender.Connect(iPEndPoint);

                try
                {
                    while(true)
                    {
                        Console.Write("Write msg :");
                        string message = Console.ReadLine();

                        Console.WriteLine($"Msg send to serer {sender.RemoteEndPoint}...");
                        byte[] msg = Encoding.UTF8.GetBytes(message);

                        // Отправляем данные через сокет (блокирующий вызов)
                        int bytesSent = sender.Send(msg);

                        // Получаем ответ от сервера (блокирующий вызов)
                        int bytesReceived = sender.Receive(bytes);

                        Console.WriteLine($"Answer from server :\"{Encoding.UTF8.GetString(bytes, 0, bytesReceived)}\".");

                        if (message.Trim() == "exit")
                            break;
                    }

                }
                catch(SocketException)
                {
                    Console.WriteLine("Problem with connection");
                }
                finally
                {
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }
            }
            catch(SocketException)
            {
                Console.WriteLine("Problem with connection");
            }
        }
    }
}
