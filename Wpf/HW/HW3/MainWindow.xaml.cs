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

namespace HW3
{

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //var bilding = new CommandBinding(ApplicationCommands.Open);
            //bilding.Executed += one_Click;
            //CommandBindings.Add(bilding);
        }

        /* private void one_Click(object sender, RoutedEventArgs e)
         {
             RadioButton ee = new RadioButton();
             try
             {
                 ee = e.Source as RadioButton;
                 //MessageBox.Show(ee.Name, e.Source.ToString());
                 if (ee.Name == "radio1")
                     tab1.IsSelected = true;
             }
             catch(Exception ex)
             {
                 MessageBox.Show(ex.Message, "exption");
             }
         }*/
        private void one_Click(object sender, RoutedEventArgs e)
        {
            tab1.IsSelected = true;
        }
        private void two_Click(object sender, RoutedEventArgs e)
        {
            tab2.IsSelected = true;
        }
        private void tree_Click(object sender, RoutedEventArgs e)
        {
            tab3.IsSelected = true;
        }
        private void four_Click(object sender, RoutedEventArgs e)
        {
            tab4.IsSelected = true;
        }
        private void five_Click(object sender, RoutedEventArgs e)
        {
            tab5.IsSelected = true;
        }
        private void six_Click(object sender, RoutedEventArgs e)
        {
            tab6.IsSelected = true;
        }
        private void seven_Click(object sender, RoutedEventArgs e)
        {
            tab7.IsSelected = true;
        }
    }
}
