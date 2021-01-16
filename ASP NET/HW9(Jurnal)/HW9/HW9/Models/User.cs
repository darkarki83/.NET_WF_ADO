using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HW9.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Text)]
        [Display(Name = "Email *")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Wrong password")]
        [DataType(DataType.Password)]
        [Display(Name = "Password *")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Text)]
        [Display(Name = "Name *")]
        public string Name { get; set; }

        [Range(1, 110, ErrorMessage = "Invalid Age")]
        public int? Age { get; set; }

        public long? RoleFk { get; set; }
        [ForeignKey("RoleFk")]
        public virtual Role Role { get; set; }

        public ICollection<Appraisal> Appraisals { get; set; }
        public ICollection<Subject> Subjects { get; set; }
    }
}
