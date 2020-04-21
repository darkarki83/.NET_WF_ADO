using System;
using System.Collections.Generic;
using System.Text;

namespace HWLinq2
{
    public class Stones
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Transparency { get; set; }
        public string About { get; set; }
        public int ColorsFK { get; set; }
        public int TypesFK { get; set; }
        public Stones(int id, string name, bool transparency, string about, int colorsFK, int typesFK)
        {
            Id = id;
            Name = name;
            Transparency = transparency;
            About = about;
            ColorsFK = colorsFK;
            TypesFK = typesFK;
        }
    }
}
