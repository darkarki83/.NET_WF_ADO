using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Validate.Models
{
    public class Order
    {
        [Required(ErrorMessage = "Required field")]
        [StringLength(20, MinimumLength = 2)]
        [Display(Name = "Name *")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Address *")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Required field")]
        [RegularExpression(@"[A-Za-z0-9-_+%]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
        [Display(Name = "Email *")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required field")]

        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}" , ApplyFormatInEditMode = true)]
       
        [Display(Name = "Date *")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Term *")]
        public string TermsAccepted { get; set; }

    }
}
