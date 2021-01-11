using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HW9.Models
{
    public class Appraisal
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }



        [Required(ErrorMessage = "Required field")]
        [Range(1, 100)]
        [DataType(DataType.Currency)] //Castom
        [Display(Name = "Appraisal")]
        public int Rating { get; set; }

        public long? StudentFk { get; set; }
        [ForeignKey("StudentFk")]
        public virtual Student Student { get; set; }

        public long? SubjectFk { get; set; }
        [ForeignKey("SubjectFk")]
        public virtual Subject Subject { get; set; }
    }
}
