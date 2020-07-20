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

namespace ExSmile2
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

        private void windows_1_Click(object sender, RoutedEventArgs e)
        {
            new Window1().Show();
        }

        private void windows_2_Click(object sender, RoutedEventArgs e)
        {
            var window = new Window2();
            window.Show();

        }

        private void find_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            try
            { 
                ImageBrush brush = (ImageBrush)button.FindResource("MyBrush");
                one.Background = brush;
                MessageBox.Show($"fined resourse: {brush}", "ApplicationResource");
            }
            catch(Exception ex)
            {
                MessageBox.Show($"no fined resourse: {ex.Message}", "ApplicationResource");
            }


            //ImageBrush brush2 = (ImageBrush)button.TryFindResource("MyBrush2");
            //if(brush2 == null)
            // {
            //    MessageBox.Show($"no fined resourse:", "ApplicationResource");
            // }



        }
    }
}
