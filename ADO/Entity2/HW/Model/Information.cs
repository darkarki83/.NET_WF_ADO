using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    public class Information
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(50)]
        public string Adress { get; set; }

        [StringLength(13)]
        [Required]
        public string Phone { get; set; }

        [Required]
        public bool? Admin { get; set; }

        public int? UserFK { get; set; }
        [ForeignKey("UserFK")]
        public virtual User User { get; set; }
    }
}
