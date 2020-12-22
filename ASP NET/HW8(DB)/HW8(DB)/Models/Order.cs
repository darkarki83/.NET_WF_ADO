using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HW8_DB_.Models
{
    public class Order
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Remote("UserId", "Home", ErrorMessage = "No have user with this id")]
        [DataType(DataType.Duration)]
        [Display(Name = "User Fk *")]
        public long? UserFk { get; set; }
        [ForeignKey("UserFk")]
        public virtual User User { get; set; }   // Навигационное свойство


        [Required(ErrorMessage = "Required field")]
        [Remote("ProductId", "Home", ErrorMessage = "No have product with this id")]
        [DataType(DataType.Duration)]
        [Display(Name = "Product Fk *")]
        public long? ProductFk { get; set; }
        [ForeignKey("ProductFk")]
        public virtual Product Product { get; set; }   // Навигационное свойство


        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Duration)]
        [Display(Name = "Count *")]
        public int Count { get; set; }

        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
    }
}
