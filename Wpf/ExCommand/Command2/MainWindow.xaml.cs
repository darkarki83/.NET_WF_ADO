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

namespace Command2
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

        public void CommandB_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Команда 'New' была вызвана.", "CommandXamlB");
        }
        public void Close_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Команда 'Close' была вызвана.", "CommandXamlClose");
            Close();
        }
    }
}
