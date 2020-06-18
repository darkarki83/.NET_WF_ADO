using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    [Table("Buyers")]
    public class Buyer
    {
        [Column("Id")]  // Name Id
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] // auto Incriment
        public int Id { get; set; }

        [StringLength(50)] // Varchar(50)
        [Required]   // not null
        public string FirstName { get; set; }

        [MaxLength(50)] // Varchar(50)
        [Required]   // not null
        public string LastName { get; set; }

        // All buys this buyer
        public ICollection<Sale> Sales { get; set; }
    }
}
