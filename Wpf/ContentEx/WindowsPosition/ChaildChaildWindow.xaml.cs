using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WindowsPosition
{
    /// <summary>
    /// Interaction logic for ChaildChaildWindow.xaml
    /// </summary>
    public partial class ChaildChaildWindow : Window
    {
        public ChaildChaildWindow()
        {
            InitializeComponent();
        }

        private void ButtonSayHello_Click(object sender, RoutedEventArgs e)
        {
            (Owner as ChaildWindow).Title = "hello from child";

            Application.Current.MainWindow.Title = "hello from child chaild";

        }
    }
}
