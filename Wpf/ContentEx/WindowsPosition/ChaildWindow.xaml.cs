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
    /// Interaction logic for ChaildWindow.xaml
    /// </summary>
    public partial class ChaildWindow : Window
    {
        public ChaildWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var windiws = new ChaildChaildWindow()
            {
                Owner = this,
                ShowInTaskbar = false
            };
            windiws.Show();
        }
    }
}
