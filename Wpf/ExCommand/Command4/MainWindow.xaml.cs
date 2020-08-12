using Microsoft.Win32;
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

namespace Command4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isModified = false;

        public MainWindow()
        {
            InitializeComponent();

            var bilding = new CommandBinding(ApplicationCommands.New);
            bilding.Executed += New_File;
            CommandBindings.Add(bilding);

            bilding = new CommandBinding(ApplicationCommands.Open);
            bilding.Executed += Open_File;
            CommandBindings.Add(bilding);

            bilding = new CommandBinding(ApplicationCommands.Save);
            bilding.Executed += Save_File;
            bilding.CanExecute += CanSave_File;
            CommandBindings.Add(bilding);
        }

        private void ToolBar_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void New_File(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Open new file", "open new file", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
            isModified = false;
        }
        private void Open_File(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Open file", "open file", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
            isModified = false;
        }

        private void CanSave_File(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = isModified;
        }
        private void Save_File(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show($"Save file  {e.Source}", $"Save the file ", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK);
        }

        private void textB1_TextChanged(object sender, TextChangedEventArgs e)
        {
            isModified = true;
        }
    }
}
