using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternComposite
{
  
    class Chair: ClassComponent
    {
        public Chair() : base("Chair", 120) { }
        
    }

    class Hard_disc : ClassComponent
    {
        public Hard_disc() : base("hard", 220) { }

    }

    class Display : ClassComponent
    {
        public Display() : base("display", 320) { }

    }

    class Comp_body : ClassComponent
    {
        public Comp_body() : base("comp_body", 720) { }

    }
}
