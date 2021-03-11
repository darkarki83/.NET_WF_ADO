using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model.Tables
{
    public class Admin
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [MaxLength(50)]
        [Required]
        public string Login { get; set; }

        [MaxLength(50)]
        [Required]
        public string Password { get; set; }

        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
    }
}
