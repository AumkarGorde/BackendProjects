using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    public interface IEmployeeService
    {
        List<Employees> GetAllEmployeeName();
    }
}
