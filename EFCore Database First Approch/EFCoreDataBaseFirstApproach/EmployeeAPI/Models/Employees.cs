using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmployeeAPI.Models
{
    public partial class Employees
    {
        public Employees()
        {
            EmployeeProjects = new HashSet<EmployeeProjects>();
        }

        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
        public int? DepartmentId { get; set; }

        public virtual Departments Department { get; set; }
        public virtual ICollection<EmployeeProjects> EmployeeProjects { get; set; }
    }
}
