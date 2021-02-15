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

namespace _03ProgressBarAsync
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Cancallation token source
        private CancellationTokenSource cancellationTokenSource;

        // Cancellation token itself
        private CancellationToken cancellationToken;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Метод, выполняющий длительную операцию(например,
        // обращение к БД)
        private void SomeOperation(IProgress<Tuple<string, int>> progress)
        {
            for (int i = 0; i < 100; i++)
            {
                // Здесь в боевых проектах мы будем делать какую-то полезную работу
                Task.Delay(100).Wait();

                // Сообщаем о необходимости обновить текст и состояние полосы прогресса
                progress.Report(new Tuple<string, int>($"Progressing... {i}%", i));

                // Если была нажата кнопка Cancel, то сообщаем о необходимости обновить текст
                // и состояние полосы прогресса и заканчиваем асинхронную операцию
                if (cancellationToken.IsCancellationRequested)
                {
                    progress.Report(new Tuple<string, int>("Task is Canceled", 0));
                    return;
                }
            }

            progress.Report(new Tuple<string, int>("Task is Complited", 100));
        }



        private async void Start_Click(object sender, RoutedEventArgs e)
        {
            // Меняем доступность кнопок
            start.IsEnabled = false;
            cancel.IsEnabled = true;

            // Создаем объект класса System.Progress. Именно в нем мы обращаемся к UI.
            var progress = new Progress<Tuple<string, int>>(t =>
            {
                labelPro.Content = t.Item1;
                progressBar.Value = t.Item2;
            });

            // Получаем cancellation token
            cancellationTokenSource = new CancellationTokenSource();
            cancellationToken = cancellationTokenSource.Token;

            // Запускаем асинхронную операцию
            await Task.Factory.StartNew(() => SomeOperation(progress));

            // Меняем доступность кнопок обратно
            start.IsEnabled = true;
            cancel.IsEnabled = false;
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            cancellationTokenSource.Cancel();
        }
    }
}
