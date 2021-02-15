using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    // Class Client table in database MyStore 
    /* Table : Client
     * Id
     * Name
     * Adrress
     * Bonus
     * 
     * ICollection<Order> Orders  all orders this Client 
     * ===>>>  Whay null??? need Initiatization
     */
    public class Client   
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }

        [MaxLength(50)]
        [Required]
        public string Adrress { get; set; }

        [Required]
        public double Bonus { get; set; }

        // all orders this Client 
        public ICollection<Order> Orders { get; set; }
    }
}
