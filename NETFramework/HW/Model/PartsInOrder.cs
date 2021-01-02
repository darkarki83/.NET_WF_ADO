using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    public class PartsInOrder
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public long? PartFk { get; set; }
        [ForeignKey("PartFk")]
        public virtual Part Part { get; set; }   // Навигационное свойство

        public long? OrderFk { get; set; }
        [ForeignKey("OrderFk")]
        public virtual Order Order { get; set; }   // Навигационное свойство
        
        [Required]
        public int Count { get; set; }

        public decimal? TotalCost { get; set; }
    }
}
