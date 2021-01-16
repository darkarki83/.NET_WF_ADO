using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HW9.Models
{
    public class Subject
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Text)]
        [Display(Name = "Name *")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Text)]
        [Display(Name = "Faciltet *")]
        public string Faciltet { get; set; }

        public long? UserLectorFk { get; set; }
        [ForeignKey("UserLectorFk")]
        public virtual User UserLector { get; set; }


        public ICollection<Appraisal> Appraisals { get; set; }

        // Свойство, не связанное с БД  // что это
        /*
        [NotMapped]
        public int? IsbnIndex { get; set; }*/
    }
}
