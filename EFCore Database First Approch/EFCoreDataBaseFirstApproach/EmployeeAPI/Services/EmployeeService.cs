using EmployeeAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly EmployeeAPIDbContext _dbContext;
        public EmployeeService(EmployeeAPIDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Employees> GetAllEmployeeName()
        {
            var result = _dbContext.Employees.ToList();
            return result;
        }
    }
}
