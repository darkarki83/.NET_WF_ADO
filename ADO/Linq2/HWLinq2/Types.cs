using System;
using System.Collections.Generic;
using System.Text;

namespace HWLinq2
{
    public class Types
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public Types(int id, string type)
        {
            Id = id;
            Type = type;
        }

        public Types()
        {
            Id = 0;
            Type = string.Empty;
        }

    }
}
