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

namespace Windows
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

        private void ButtonNoModal_Click(object sender, RoutedEventArgs e)
        {
            var window = new ModalWin("Modal Win");
            window.Show();
        }

        private void ButtonMadal_Click(object sender, RoutedEventArgs e)
        {
            var window = new ModalWin("Modal Win") { Owner = this };
            window.ShowDialog();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (var windows in Application.Current.Windows)
                if (windows is ModalWin)
                    (windows as ModalWin)?.Close();
        }
    }
}
