using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApp.Models
{
    public class Product
    {

        [Key]
        public int id { get; set; }

        [Required]
        public string productName { get; set; }

    }
}
