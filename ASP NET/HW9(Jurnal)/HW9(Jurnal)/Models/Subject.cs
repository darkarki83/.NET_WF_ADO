using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HW9_Jurnal_.Models
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

        public long? LecturerFk { get; set; }
        [ForeignKey("LecturerFk")]
        public virtual Lecturer Lecturer { get; set; }

        public ICollection<Appraisal> Appraisals { get; set; }

        // Свойство, не связанное с БД

        [NotMapped]
        public int? IsbnIndex { get; set; }
    }
}
