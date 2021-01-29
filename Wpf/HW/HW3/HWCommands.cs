using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HW05NoMVVM
{
    public class HWCommands
    {
        public static readonly RoutedUICommand CkickTab1 = new RoutedUICommand("Tab_1", "CkickTab1", typeof(HWCommands));
        public static readonly RoutedUICommand CkickTab2 = new RoutedUICommand("Tab_2", "CkickTab2", typeof(HWCommands));
        public static readonly RoutedUICommand CkickTab3 = new RoutedUICommand("Tab_3", "CkickTab3", typeof(HWCommands));
        public static readonly RoutedUICommand CkickTab4 = new RoutedUICommand("Tab_4", "CkickTab4", typeof(HWCommands));
        public static readonly RoutedUICommand CkickTab5 = new RoutedUICommand("Tab_5", "CkickTab5", typeof(HWCommands));
        public static readonly RoutedUICommand CkickTab6 = new RoutedUICommand("Tab_6", "CkickTab6", typeof(HWCommands));
        public static readonly RoutedUICommand CkickTab7 = new RoutedUICommand("Tab_7", "CkickTab7", typeof(HWCommands));
        public static readonly RoutedUICommand ClickResult = new RoutedUICommand("Tab_result", "ClickResult", typeof(HWCommands));
        public static readonly RoutedUICommand NextTest = new RoutedUICommand("Next_and_save", "NextTest", typeof(HWCommands));
        public static readonly RoutedUICommand ShowQ = new RoutedUICommand("Q1Show", "ShowQ", typeof(HWCommands));
    }
}
