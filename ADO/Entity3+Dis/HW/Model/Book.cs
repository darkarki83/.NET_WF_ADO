using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    [Table("Books")]
    public class Book
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [StringLength(100)]
        [Required]
        public string Name { get; set; }

        [Range(1, 10000)]
        public int? Pages { get; set; }

        [Column(TypeName = "money")]
        [Range(0, 20000)]
        public decimal? Price { get; set; }


        public int? AuthorFK { get; set; }
        [ForeignKey("AuthorFK")]
        public virtual Author Author { get; set; }

        public int? PressFK { get; set; }
        [ForeignKey("PressFK")]
        public virtual Press Press { get; set; }
    }
}
