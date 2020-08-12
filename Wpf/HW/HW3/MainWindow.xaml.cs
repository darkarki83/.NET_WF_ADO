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
        List<RadioButton> radios = new List<RadioButton>();
        List<RadioButton> radiosTab = new List<RadioButton>();
        List<StackPanel> radioAns = new List<StackPanel>();
        List<TabItem> tabItems = new List<TabItem>();
        List<int> resultCount = new List<int>();
        int Checkd { get; set; } = 1;
        public MainWindow()
        {
            InitializeComponent();
            for (int i = 0; i < 7; i++)
            {
                resultCount.Add(0);
            }
            radiosTab.Add(radio1);
            radiosTab.Add(radio2);
            radiosTab.Add(radio3);
            radiosTab.Add(radio4);
            radiosTab.Add(radio5);
            radiosTab.Add(radio6);
            radiosTab.Add(radio7);
            tabItems.Add(tab1);
            tabItems.Add(tab2);
            tabItems.Add(tab3);
            tabItems.Add(tab4);
            tabItems.Add(tab5);
            tabItems.Add(tab6);
            tabItems.Add(tab7);
            radios.Add(Q1);
            radios.Add(Q2);
            radios.Add(Q3);
            radios.Add(Q4);
            radios.Add(Q5);
            radios.Add(Q6);
            radios.Add(Q7);
            radios.Add(Q8);
            radioAns.Add(FirstQoution);
            radioAns.Add(SecondQoution);
            radioAns.Add(ThreesQoution);
            radioAns.Add(FoursQoution);
            radioAns.Add(FirstQoution2);
            radioAns.Add(SecondQoution2);
            radioAns.Add(ThreesQoution2);
            radioAns.Add(FoursQoution2);
            //var bildiQ2ng = new CommandBinding(ApplicationCommands.Open);
            //bilding.EQ3xecuted += one_Click;
            //CommandBiQ4ndings.Add(bilding);
        }
        private void GetResult_Click()
        {
            if (one1.IsChecked == true)
            {
                resultCount[Checkd - 1] += 25;
            }
            if (one2.IsChecked == true)
            {
                resultCount[Checkd - 1] += 25;
            }
            if (one3.IsChecked == true)
            {
                resultCount[Checkd - 1] += 25;
            }
            if (one4.IsChecked == true)
            {
                resultCount[Checkd - 1] += 25;
            }
            Text1text.Text = resultCount[Checkd - 1].ToString();
        }
        private void isExecute_Click()
        {
            foreach (var item in radiosTab)
            {
                int checkd = int.Parse(item.Name[5].ToString());
                if(checkd == Checkd)
                {
                    tabItems[checkd - 1].IsEnabled = false;
                    item.IsEnabled = false;
                }
            }
        }
        private void NaxtAndSave_Click(object sender, RoutedEventArgs e)
        {
            isExecute_Click();
            for (int i = 0; i < radiosTab.Count; i++)
            {
                if (radiosTab[i].IsChecked == true)
                {

                    if (i < radiosTab.Count - 1 && radiosTab[i + 1].IsEnabled == true)
                    {
                        Checkd = i + 2;
                        //isExecute_Click();
                        radiosTab[i].IsChecked = false;
                        radiosTab[i + 1].IsChecked = true;
                        break;
                    }
                    else if (i < radiosTab.Count - 1 && radiosTab[i + 1].IsEnabled == false)
                    {
                        radiosTab[i].IsChecked = false;
                        i++;
                        while (i < radiosTab.Count - 1)
                        {
                            if (radiosTab[i + 1].IsEnabled == true)
                            {
                                Checkd = i + 1;
                                radiosTab[i + 1].IsChecked = true;
                                break;
                            }
                            i++;
                        }
                        //Checkd = i + 2;
                        if (i == radiosTab.Count - 1)
                        {
                            radiosTab[i].IsChecked = false;
                            result.IsChecked = true;
                            break;
                        }
                        break;
                    }
                    else if (i >= radiosTab.Count - 1)
                    {
                        //Checkd = i + 2;
                        radiosTab[i].IsChecked = false;
                        result.IsChecked = true;
                    }
                }
            }
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
                isExecute_Click();
                tab2.IsSelected = true;
                Checkd = 2;
        }
        private void tree_Click(object sender, RoutedEventArgs e)
        {
                isExecute_Click();
                tab3.IsSelected = true;
                Checkd = 3;
        }
        private void four_Click(object sender, RoutedEventArgs e)
        {
            isExecute_Click();
            tab4.IsSelected = true;
            Checkd = 4;
        }
        private void five_Click(object sender, RoutedEventArgs e)
        {
            isExecute_Click();
            tab5.IsSelected = true;
            Checkd = 5;
        }
        private void six_Click(object sender, RoutedEventArgs e)
        {
            isExecute_Click();
            tab6.IsSelected = true;
            Checkd = 6;
        }
        private void seven_Click(object sender, RoutedEventArgs e)
        {
            isExecute_Click();
            tab7.IsSelected = true;
            Checkd = 7;
        }
        private void result_Click(object sender, RoutedEventArgs e)
        {
            GetResult_Click();
            isExecute_Click();
            //result.IsSelected = true;
        }
        private void ShowQ_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in radioAns)
                item.Visibility = Visibility.Collapsed;
            //MessageBox.Show("ppp", e.Source.ToString());
            RadioButton radio = e.Source as RadioButton;
            if (radio.Name[1] == '1')
                FirstQoution.Visibility = Visibility.Visible;
            else if (radio.Name[1] == '2')
                SecondQoution.Visibility = Visibility.Visible;
            else if (radio.Name[1] == '3')
                ThreesQoution.Visibility = Visibility.Visible;
            else if (radio.Name[1] == '4')
                FoursQoution.Visibility = Visibility.Visible;
            else if (radio.Name[1] == '5')
                FirstQoution2.Visibility = Visibility.Visible;
            else if (radio.Name[1] == '6')
                SecondQoution2.Visibility = Visibility.Visible;
            else if (radio.Name[1] == '7')
                ThreesQoution2.Visibility = Visibility.Visible;
            else if (radio.Name[1] == '8')
                FoursQoution2.Visibility = Visibility.Visible;
        }
    }
}
