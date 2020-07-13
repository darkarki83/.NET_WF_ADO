using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfMultiThread_smp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Click_Thread(object sender, RoutedEventArgs e)
        {
            var thread = new Thread(UpdateTextBox);
            thread.Start();

            MessageBox.Show("Вызов из первичного потока : ", $"Hash: {Thread.CurrentThread.GetHashCode()}");
        }
        private void UpdateTextBox()
        {
            Thread.Sleep(TimeSpan.FromSeconds(1));

            MessageBox.Show("Вызов из вторичного потока : ", $"Hash: {Thread.CurrentThread.GetHashCode()}");

            textBox.Dispatcher.BeginInvoke((Action)(() => { textBox.Text = "New Text"; }), null);

            Dispatcher.Invoke(WorkerMethod);
        }
        private void WorkerMethod()
        {
            // Показываем хэш-код текущего потока. Поскольку этот метод вызывается из вторичного потока,
            // но через Dispatcher, то он всё равно будет работать первичном потоке нашего WPF UI.
            MessageBox.Show("Формально этот метод вызывается из вторичного потока, но поскольку это реализуется через через Dispatcher, то на самом деле этот вызов осуществляется из первичного потока", $"Hash: {Thread.CurrentThread.GetHashCode()}");

            // Этот метод выполняется в потоке диспетчера, поэтому трудоемкие операции
            // подвесят приложение точно так же, как если бы оно работало в одном потоке.
            //Thread.Sleep(TimeSpan.FromSeconds(5));

            // Собственно, обращение контролу
            textBox.Text = "Test";
        }
    }
}
