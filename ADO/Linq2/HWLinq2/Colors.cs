using System;
using System.Collections.Generic;
using System.Text;

namespace HWLinq2
{
    public class Colors
    {
        public int Id { get; set; }
        public string Color { get; set; }
        public Colors(int id, string color)
        {
            Id = id;
            Color = color;
        }

        public Colors()
        {
            Id = 0;
            Color = string.Empty;
        }
    }
}
