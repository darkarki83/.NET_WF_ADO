using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MVC.Models
{
    public class MyModel
    {
        public string Name {get; set;}
        public MyModel(string name)
        {
            Name = name;
        }
    }
}