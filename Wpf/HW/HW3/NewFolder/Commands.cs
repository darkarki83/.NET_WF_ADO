using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace HW3.NewFolder
{
    public static class OurCommands
    {
        public static readonly RoutedCommand ClickOne = new RoutedCommand("ClickOne", typeof(OurCommands));
    }
}
