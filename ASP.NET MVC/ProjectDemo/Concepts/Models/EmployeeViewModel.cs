using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Concepts.Models
{
    public class EmployeeViewModel
    {
        public Employee _employee;
        public EmployeeViewModel(Employee employee)
        {
            _employee = employee;
        }
        public int Age 
        { 
            get 
            {
                int age = DateTime.Now.Year - _employee.DateOfBirth.Year;
                if (age <= 0)
                {
                    age = 0;
                }
                return age;
            }

        }

        public string Salary 
        {
            get 
            { 
                if(_employee.Salary > 20000)
                {
                    return "green";
                }
                else
                {
                    return "red";
                }
            } 
        }
    }
}