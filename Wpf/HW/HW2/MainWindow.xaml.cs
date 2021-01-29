using System.Windows;
using System.Windows.Controls;

namespace HW03
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

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton button = e.OriginalSource as RadioButton;

            try
            {
                Image image = (Image)button.Content;

                if (bigFhoto != null)
                    bigFhoto.Source = image.Source;
            }
            catch
            {
                
            }
        }

        private void WidthSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

        }
    }
}
