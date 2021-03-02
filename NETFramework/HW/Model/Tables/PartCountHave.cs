using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model.Tables
{
    public class PartCountHave
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        public int Count { get; set; }

        public long? PartFk { get; set; }
        [ForeignKey("PartFk")]
        public virtual Part Part { get; set; }   // Навигационное свойство
    }
}
