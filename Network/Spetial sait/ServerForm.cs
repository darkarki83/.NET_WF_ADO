﻿using System;
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

namespace Spetial_sait
{
    public partial class ServerForm : Form
    {
        public List<UsersList> UsersLists { get; set; }
        private TcpListener listner;

        public ServerForm()
        {
            InitializeComponent();
            UsersLists = new List<UsersList>();

            textBoxIp.Text = "127.0.0.1";
            textBoxPort.Text = "80";
            buttonStart_Click(new object(), EventArgs.Empty);
        }
        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                // Создаем экземпляр класса TcpListener.
                // Хост и порт вводит пользователь.
                listner = new TcpListener(
                    IPAddress.Parse(textBoxIp.Text.Trim()),
                    Convert.ToInt32(textBoxPort.Text.Trim()));
                // Начинаем прослушивание клиентов
                listner.Start();
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
            while (true)
            {
                // Сообщаем клиенту о готовности к соединению
                TcpClient client = listner.AcceptTcpClient();
                // Читаем данные из сети в формате Unicode
                var stream = new StreamReader(client.GetStream(), Encoding.Unicode);
                listBoxHapen.Invoke((MethodInvoker)(() => listBoxHapen.Items.Add("idu dalshe")));
                string s = stream.ReadLine();
                if (s != null)
                {
                    listBoxHapen.Invoke((MethodInvoker)(() => listBoxHapen.Items.Add(s)));
                    listBoxHapen.Invoke((MethodInvoker)(() => listBoxHapen.Items.Add("Chitaiu snova")));
                    // При получении сообщения EXIT завершаем работу приложения
                    if (s.ToUpper() == "EXIT")
                    {
                        listner.Stop();
                        Close();
                    }
                    if (s == "Get")
                    {
                        NetworkStream nstream = client.GetStream();
                        byte[] message = Encoding.Unicode.GetBytes(/*Names.Trim() + ":" + */"Paluchai");
                        Thread.Sleep(500);
                        //StreamWriter streams = new StreamWriter(client.GetStream(), Encoding.Unicode);
                        //new StreamWriter(client.GetStream(), Encoding.Unicode);
                        nstream.Write(message, 0, message.Length);
                        listBoxHapen.Invoke((MethodInvoker)(() => listBoxHapen.Items.Add("Sending")));

                    }
                }
                listBoxHapen.Invoke((MethodInvoker)(() => listBoxHapen.Items.Add("idu dalshe")));
                client.Close();
            }
        }
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (listner != null)
                listner.Stop();
        }
    }
    public class UsersList
    {
        public string Name { get; set; }
        public List<string> Masseges { get; set; }
        public UsersList()
        {
            Masseges = new List<string>();
        }
    }
}
