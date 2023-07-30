using DapperApplicationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApplicationAPI.DataAccess
{
    public interface IEmployeeRepository
    {
        Employee GetEmployeeById(int employeeId);
        IEnumerable<Employee> GetAllEmployees();
        IEnumerable<Employee> GetAllEmployeesWithDepartment();
        void InsertEmployee(Employee employee);
        void UpdateEmployee(Employee employee);
        void DeleteEmployee(int employeeId);
    }
}
