using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    public class Part
    {
        [Column("Id")]   
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [Range(1, 7999)]
        public decimal Cost { get; set; }

        [Required]
        public bool Status { get; set; }


        // Внешние ключи.
        // Задаем правила сопоставления классов модели с таблицами БД.

        public long? ManufacturerFk { get; set; }
        [ForeignKey("ManufacturerFk")]
        public virtual Manufacturer Manufacturer { get; set; }   // Навигационное свойство
    
        public ICollection<PartsInOrder> PartsInOrders { get; set; }

    }
}
