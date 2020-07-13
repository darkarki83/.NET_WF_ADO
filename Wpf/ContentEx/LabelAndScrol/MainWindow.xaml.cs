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

namespace LabelAndScrol
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

        private void ButtonLineUp_Click(object sender, RoutedEventArgs e)
        {
            scrollViewer.LineUp();
        }

        private void ButtonLineDown_Click(object sender, RoutedEventArgs e)
        {
            scrollViewer.LineDown();
        }

        private void ButtonPageDown_Click(object sender, RoutedEventArgs e)
        {
            scrollViewer.PageDown();
        }

        private void ButtonPageUp_Click(object sender, RoutedEventArgs e)
        {
            scrollViewer.PageUp();
        }
    }
}
