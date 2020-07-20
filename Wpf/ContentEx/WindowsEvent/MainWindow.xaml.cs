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

namespace WindowsEvent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            listBox.Items.Add("InitializeComponent");
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            listBox.Items.Add("Window Closing");
            if (new ExitWindows() { Owner = this }.ShowDialog() == false)
                e.Cancel = true;
        }

        private void Win_Loaded(object sender, RoutedEventArgs e)
        {
            listBox.Items.Add("Loaded");
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("Closing", "App exit", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            listBox.Items.Add("Window Activated");
        }

        private void Window_Deactivated(object sender, EventArgs e)
        {
            listBox.Items.Add("Window Deactivated");
        }

        private void Window_ContentRendered(object sender, EventArgs e)
        {
            listBox.Items.Add("Window ContentRendered");
        }
    }
}
