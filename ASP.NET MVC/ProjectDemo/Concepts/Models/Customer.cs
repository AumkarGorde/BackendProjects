using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Concepts.Models
{
    public class Customer
    {
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