using DapperApplicationAPI.DataAccess;
using DapperApplicationAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private IEmployeeRepository _employee;
        public EmployeeController(IEmployeeRepository employee)
        {
            _employee = employee;
        }

        [HttpGet("Get")]
        public ActionResult GetAllEmployees()
        {
            var result = _employee.GetAllEmployees();
            return Ok(result);
        }
        [HttpGet("GetDetails")]
        public ActionResult GetAllEmployeesWithDepartment()
        {
            var result = _employee.GetAllEmployeesWithDepartment();
            return Ok(result);
        }

        [HttpPatch("{employeeId}/{employeeName}")]
        public ActionResult GetAllEmployeesWithDepartment(int employeeId, string employeeName)
        {
            var emp = new Employee();
            emp.EmployeeId = employeeId;
            emp.EmployeeName = employeeName;
            _employee.UpdateEmployee(emp);
            return Ok();
        }
    }
}
