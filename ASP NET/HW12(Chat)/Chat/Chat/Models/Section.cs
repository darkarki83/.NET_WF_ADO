using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Chat.Models
{
    public class Section
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Text)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        public long? OpenUser { get; set; }
        [ForeignKey("UserFk")]
        public virtual User User { get; set; }

        public ICollection<Theme> Themes { get; set; }
    }
}
