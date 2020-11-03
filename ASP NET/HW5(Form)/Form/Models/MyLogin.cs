using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Form.Models
{
    public class MyLogin
    {

        [Display(Name = "Login")]
        string Login { get; set; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        string Pass { get; set; }
    }
}
