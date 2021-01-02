using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HW9_Jurnal_.Models
{
    public class Appraisal
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Range(1, 100)]
        [Display(Name = "Appraisal")]

        public long? StudenFk { get; set; }
        [ForeignKey("StudenFk")]
        public virtual Student Student { get; set; }

        public long? SubjectFk { get; set; }
        [ForeignKey("SubjectFk")]
        public virtual Subject Subject { get; set; }
    }
}
