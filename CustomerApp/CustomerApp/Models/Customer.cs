using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApp.Models
{
    public class Customer
    {

        [NotMapped] // write guid, expects it to have a field in sql server table, ignore it
        public Guid guid { get; set; } 

        public Customer() //auto-populate, we dont have to do anything.
        {
            // every time a instance of
            // customer class is created
            // a new GUID will be assigned
            guid = Guid.NewGuid();
        }


        [Key]
        public int id { get; set; }

        [Required]
        public string customerName { get; set; }

        [Required]
        public string address { get; set; }


        public List<Product> products { get; set; }


    }


    public class CustomerDiscounted : Customer
    {


    }

    public class CustomerDiscounted2 : Customer
    {


    }

}
