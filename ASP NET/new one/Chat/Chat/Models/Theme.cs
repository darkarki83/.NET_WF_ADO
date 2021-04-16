using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Models
{
    public class Theme
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Date of open")]
        public DateTime DateOpen { get; set; }

        public long? ModeratorUser { get; set; }
        [ForeignKey("UserFk")]
        public virtual User User { get; set; }

        public long? SectionFk { get; set; }
        [ForeignKey("SectionFk")]
        public virtual Section Section { get; set; }

        public ICollection<Answer> Answers { get; set; }
    }
}
