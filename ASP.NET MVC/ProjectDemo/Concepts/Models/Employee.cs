using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concepts.Models
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int Salary { get; set; }
    }
}