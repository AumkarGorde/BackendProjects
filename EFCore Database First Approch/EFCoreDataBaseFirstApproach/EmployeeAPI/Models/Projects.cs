using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace EmployeeAPI.Models
{
    public partial class Projects
    {
        public Projects()
        {
            EmployeeProjects = new HashSet<EmployeeProjects>();
        }

        public int ProjectId { get; set; }
        public string ProjectName { get; set; }

        public virtual ICollection<EmployeeProjects> EmployeeProjects { get; set; }
    }
}
