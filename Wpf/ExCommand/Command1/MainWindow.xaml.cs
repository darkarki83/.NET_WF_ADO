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

namespace Command1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            var bilding = new CommandBinding(ApplicationCommands.New);
            bilding.Executed += new ExecutedRoutedEventHandler(new_FromSC);
            CommandBindings.Add(bilding);
        }

        public void new_FromSC(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Commonds new From sc load", "NewCommand");
        }

    }
}
