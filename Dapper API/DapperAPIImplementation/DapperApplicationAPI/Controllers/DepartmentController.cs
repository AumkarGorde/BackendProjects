using DapperApplicationAPI.DataAccess;
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
    public class DepartmentController : ControllerBase
    {
        public IDepartmentRepository _department { get; set; }
        public DepartmentController(IDepartmentRepository department)
        {
            _department = department;
        }

        [HttpGet("Get")]
        public ActionResult GetAllDepartments()
        {
            var result = _department.GetAllDepartments();
            return Ok(result);
        }

        [HttpGet("GetDetails")]
        public ActionResult GetAllDepartmentsWithEmployee()
        {
            var result = _department.GetAllDepartmentsWithEmployees();
            return Ok(result);
        }

        [HttpGet("GetDepartmentByEmployeeName/{name}")]
        public ActionResult GetAllDepartmentsByEmployeeName(string name)
        {
            var result = _department.GetDepartmentByEmployeeName(name);
            return Ok(result);
        }

    }
}
