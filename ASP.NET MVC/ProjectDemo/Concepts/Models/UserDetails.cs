using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Concepts.Models
{
    public class UserDetails
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
    }
}