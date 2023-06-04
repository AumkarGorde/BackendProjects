using Concepts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Concepts.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Show()
        {
            var emp = createEmployee();
            var empVM = new EmployeeViewModel(emp);
            return View(empVM);
        }

        private Employee createEmployee()
        {
            Employee emp = new Employee()
            {
                Id = "WDA-786",
                Name = "Robert Oppenhimer",
                Salary = 50000,
                DateOfBirth = new DateTime(1997, 05, 06)
            };
            return emp;
        }
    }
}