using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW.Model
{
    [Table("Seles")]
    public class Sale
    {

        [Column("Id")]  // Name Id
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] // auto Incriment
        public int Id { get; set; }

        [Column(TypeName = "money")] // name in datebase = money
        [Range(0, 20000)]   // Range
        public decimal? SaleAmount { get; set; }

        [Column(TypeName = "date")] // name in datebase = date
        [Required]   // not null
        public DateTime? SaleDate { get; set; }

        // ForeignKey from Buyer
        public int BuyerFK { get; set; }
        [ForeignKey("BuyerFK")]
        public virtual Buyer Buyer { get; set; }

        // ForeignKey from Sale
        public int SellerFK { get; set; }
        [ForeignKey("SellerFK")]
        public virtual Seller Seller { get; set; }

    }
}
