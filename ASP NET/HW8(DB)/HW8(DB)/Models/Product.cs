using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HW8_DB_.Models
{
    public class Product
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Remote("CheckProduct", "Home", ErrorMessage = "there is a product with that name")]
        [DataType(DataType.Text)]
        [Display(Name = "Name *")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Currency)]
        [Display(Name = "Cost *")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Required field")]
        [StringLength(400, MinimumLength = 5,  ErrorMessage = "Description length from 5 to 400 characters")]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Description *")]
        public string Description { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Add Date")]
        public DateTime Date { get; set; }

    }
}
