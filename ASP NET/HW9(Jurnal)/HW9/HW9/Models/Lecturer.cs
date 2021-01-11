﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HW9.Models
{
    public class Lecturer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Text)]
        [Display(Name = "Name *")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Required field")]
        [DataType(DataType.Text)]
        [Display(Name = "Last Name *")]
        public string LastName { get; set; }

        [Range(1, 110, ErrorMessage = "Invalid Age")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Required field")]
        //[Remote("CheckLecturerMail", "Home", ErrorMessage = "Have user in this Email")]
        [DataType(DataType.Text)]
        [Display(Name = "Email *")]
        public string Email { get; set; }

        public ICollection<Subject> Subjects { get; set; }
    }
}
