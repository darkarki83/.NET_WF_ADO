using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Models
{
    public class Answer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Post")]
        public string Post { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Update Date")]
        public DateTime UpdateDate { get; set; }

        public long? AuthorUser { get; set; }
        [ForeignKey("UserFk")]
        public virtual User User { get; set; }

        public long? ThemeFk { get; set; }
        [ForeignKey("ThemeFk")]
        public virtual Theme Theme { get; set; }
    }
}
