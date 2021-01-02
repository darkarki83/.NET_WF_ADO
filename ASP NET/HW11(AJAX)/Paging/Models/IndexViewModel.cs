using System.Collections.Generic;

namespace Paging.Models
{
    public class IndexViewModel
    {
        public IEnumerable<Phone> Phones { get; set; }
        public Pages Pages { get; set; }
    }
}