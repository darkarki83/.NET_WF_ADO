using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Clock
{
    public partial class ClockForm : Form
    {
        // Локальный порт для прослушивания
        private static int localPort;
        // Удаленный IP и порт для подключения
        private static IPAddress remoteIPAddress;
        private static int remotePort;

        public ClockForm()
        {
            InitializeComponent();
        }

        private void ClockForm_Load(object sender, EventArgs e)
        {

            localPort = Convert.ToInt32("5001");
            remoteIPAddress = IPAddress.Parse("127.0.0.1");
            remotePort = Convert.ToInt32("5001");

            var threadReceiver = new Thread(new ThreadStart(Receiver));
            threadReceiver.IsBackground = true;
            threadReceiver.Start();
        }
        private static void Send()
        {
            DateTime date = DateTime.Now;
            // Создаем UdpClient
            var sender = new UdpClient();

            // Создаем endPoint по информации об удаленном хосте
            var endPoint = new IPEndPoint(remoteIPAddress, remotePort);

            try
            {
                // Преобразуем данные в массив байтов
                byte[] bytes = Encoding.UTF8.GetBytes(date.ToString("T"));

                // Отправляем данные
                sender.Send(bytes, bytes.Length, endPoint);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка сокета: " + ex.Message);
            }
            finally
            {
                // Закрываем соединение
                sender.Close();
            }
        }
        public void Receiver()
        {
            // Создаем UdpClient для чтения входящих данных
            var receivingUdpClient = new UdpClient(localPort);

            IPEndPoint RemoteIpEndPoint = null;

            try
            {
                while (true)
                {
                    // Ожидание дейтаграммы
                    byte[] receiveBytes = receivingUdpClient.Receive(ref RemoteIpEndPoint);

                    // Преобразуем и отображаем данные
                    string returnData = Encoding.UTF8.GetString(receiveBytes);

                    textBox1.Invoke((MethodInvoker)(() => textBox1.Text = returnData));
                    //if (returnData != null)
                     //   break;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Ошибка сокета: " + ex.Message);
            }
        }

        private void buttonGet_Click(object sender, EventArgs e)
        {
            Send();
        }
    }
}
