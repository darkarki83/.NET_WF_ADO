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
using System.Windows.Shapes;

namespace DocumentColection.Source
{
    /// <summary>
    /// Interaction logic for Document1.xaml
    /// </summary>
    public partial class Document1 : Window
    {
        public Document1()
        {
            InitializeComponent();
        }

        public void SetContent(string content)
        {
            Content = content;
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            (Application.Current as App).Documents.Remove(this);
        }
    }
}
