using Client.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Client
{
    public partial class ClientForm : Form , IClientView
    {
        public event EventHandler GetConectInfo;
        public string Names { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }

        private TcpClient client;
        private IPEndPoint endPoint;
        public ClientForm()
        {
            InitializeComponent();
        }
        private void ClientForm_Load(object sender, EventArgs e)
        {
            GetConectInfo(sender, e);
            Text = Names;
            listBoxMassege.Items.Add(Names);
            listBoxMassege.Items.Add(Ip);
            listBoxMassege.Items.Add(Port);
        }
        private void buttonSend_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем экземпляр класса IPEndPoint
                endPoint = new IPEndPoint(
                    IPAddress.Parse(Ip),
                    Convert.ToInt32(Port));
                client = new TcpClient();
                // Устанавливаем соединение с использованием данных IP и номера порта
                client.Connect(endPoint);
                // Получаем сетевой поток
                NetworkStream nstream = client.GetStream();
                // Преобразуем строки сообщения в массив байт
                byte[] message = Encoding.Unicode.GetBytes(textBoxName.Text.Trim() + ":" + textBoxMassage.Text.Trim());
                // Записываем весь массив в сетевой поток
                nstream.Write(message, 0, message.Length);
                // Закрываем клиентский сокет
                client.Close();
            }
            catch (SocketException sockEx)
            {
                MessageBox.Show("Ошибка сокета:" + sockEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка:" + ex.Message);
            }
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (client != null)
                client.Close();
        }

        private void buttonDownload_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем отдельный поток для чтения сообщения и запускаем его
                var thread = new Thread(new ThreadStart(ClientThreadProc));
                thread.IsBackground = true;
                thread.Start();
            }
            catch (SocketException sockEx)
            {
                MessageBox.Show("Ошибка сокета: " + sockEx.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void ClientThreadProc()
        {
            try
            {
                endPoint = new IPEndPoint(
                    IPAddress.Parse(Ip),
                    Convert.ToInt32(Port));
                client = new TcpClient();
                // Устанавливаем соединение с использованием данных IP и номера порта
                client.Connect(endPoint);

                NetworkStream nstream = client.GetStream();
                byte[] message = Encoding.Unicode.GetBytes(/*Names.Trim() + ":" + */"Get");
                nstream.Write(message, 0, message.Length);
                Thread.Sleep(1000);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }

            //while (true)
            {
                // Сообщаем клиенту о готовности к соединению
               
                // Читаем данные из сети в формате Unicode
                var stream = new StreamReader(client.GetStream(), Encoding.Unicode);
                string s = stream.ReadLine();
                if (s != null)
                {
                    // Добавляем полученное сообщение в список
                    listBoxMassege.Items.Add(s);
                    // При получении сообщения EXIT завершаем работу приложения
                    if (s.ToUpper() == "EXIT")
                    {
                        client.Close();
                    }
                    //break;
                }
            }
        }


    }
}
