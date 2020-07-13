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

namespace modularContent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            AddHandler(CheckBox.CheckedEvent, new RoutedEventHandler(checkBoxPanel_Checked));
            AddHandler(CheckBox.UncheckedEvent, new RoutedEventHandler(checkBoxPanel_Unchecked));
        }

        private void checkBoxPanel_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = e.OriginalSource as CheckBox;

            DependencyObject boxObject = LogicalTreeHelper.FindLogicalNode(wrapPanel, checkBox.Content.ToString());

            ((FrameworkElement)boxObject).Visibility = Visibility.Visible;
        }

        private void checkBoxPanel_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = e.OriginalSource as CheckBox;

            DependencyObject boxObject = LogicalTreeHelper.FindLogicalNode(wrapPanel, checkBox.Content.ToString());

            ((FrameworkElement)boxObject).Visibility = Visibility.Hidden;
        }
    }
}
