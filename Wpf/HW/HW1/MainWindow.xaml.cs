using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace HW02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window
    {
        Image source1 = new Image();
        Image source2 = new Image();
        Image source3 = new Image();
        Image source4 = new Image();
        public MainWindow()
        {
            InitializeComponent();

            AddHandler(Button.ClickEvent, new RoutedEventHandler(button_Click));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            Button button = e.OriginalSource as Button;

            Image images = (Image)button.Content;
            textB.Text = images.Source.ToString();

            if (source1.Source == null)
                source1.Source = one.Source;
            if (source2.Source == null)
                source2.Source = two.Source;
            if (source3.Source == null)
                source3.Source = three.Source;
            if (source4.Source == null)
                source4.Source = four.Source;

            if (images.Source == source1.Source)
            {
                images.Source = source2.Source;
            }
            else if (images.Source == source2.Source)
            {
                images.Source = source3.Source;
            }
            else if (images.Source == source3.Source)
            {
                images.Source = source4.Source;
            }
            else if (images.Source == source4.Source)
            {
                images.Source = source1.Source;
            }


        }

        private void button_Click(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
