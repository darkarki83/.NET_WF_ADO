using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    // Class Manufacturer table in database MyStore 
    /* Table : Manufacturer
     * Id
     * Name
     * 
     * ICollection<Part> Parts  all parts this Manufacturer 
     * ===>>>  Whay null??? need Initiatization
     */
    public class Manufacturer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        // Оборудование данной фабрики
        public ICollection<Part> Parts { get; set; }
    }
}
