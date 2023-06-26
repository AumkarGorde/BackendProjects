using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Concepts.Models
{
    //Here a mistake is made while creating an id, we have marked CustomerId as key but we are also taking it as input from UI but in DB treating as Identity column
    public class Customer
    {
        [Key]         //This is required attribute for ef
        [Required]
        [RegularExpression("^[0-9]{4,4}$")]
        public int CustomerId { get; set; }
        [Required]
        [StringLength(20)]
        public string CustomerName { get; set; }
        [Required]
        [StringLength(10)]
        public string CustomerLocation { get; set; }
    }
}