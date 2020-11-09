using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DB.Models
{
    public class Account
    {
        [Display(Name = "Id *")]
        [DataType(DataType.Text)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Login *")]
        [DataType(DataType.Text)]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Length min 3 max 50  chars")]
        [Remote("CheckUsername", "Home", ErrorMessage = "Have this login")]
        public string User { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Password *")]
        [DataType(DataType.Password)]
        [StringLength(30, MinimumLength = 3, ErrorMessage ="Length min 3 max 50 chars")]
        public string Pass { get; set; }
    
        [Required(ErrorMessage = "Required field")]
        [Display(Name = "PassConfirm *")]
        [DataType(DataType.Password)]
        [Compare("Pass", ErrorMessage = "Pass do not match" )]
        public string PassConfirm { get; set; }

        [Required(ErrorMessage = "Required field")]
        [Display(Name = "Email *")]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"[A-Za-z0-9-_+%]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}", ErrorMessage = "Wrong Email")]
      
        public string Email { get; set; }
    }
}
