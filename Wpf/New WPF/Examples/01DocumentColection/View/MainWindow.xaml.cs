
using DocumentColection.Source;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

namespace DocumentColection.View
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

        private void CreateDocument(object sender, RoutedEventArgs e)
        {

            var document = new Document1(); // create document(window)

            document.Owner = this;          // get Owner (.net needed)

            document.Show();

            (Application.Current as App).Documents.Add(document);
        }

        private void UpdateDocument(object sender, RoutedEventArgs e)
        {
            foreach (Document1 doc in ((App)Application.Current).Documents)
                // Обновляем содержимое всех окно
                doc.SetContent($"Updated at {DateTime.Now.ToLongTimeString()}");
        }
    }
}
