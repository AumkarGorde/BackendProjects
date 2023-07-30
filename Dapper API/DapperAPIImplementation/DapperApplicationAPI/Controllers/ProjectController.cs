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
    public class ProjectController : ControllerBase
    {
        public IProjectRepository _project { get; set; }
        public ProjectController(IProjectRepository project)
        {
            _project = project;
        }

        [HttpGet("Get")]
        public ActionResult GetAllProjects()
        {
            var result = _project.GetAllProjects();
            return Ok(result);
        }

        [HttpGet("GetDetails")]
        public ActionResult GetAllProjectsWithEmployees()
        {
            var result = _project.GetAllProjectsWithEmployees();
            return Ok(result);
        }

        [HttpGet("GetProjectsByEmployee/{name}")]
        public ActionResult GetProjectsWithEmployeeName(string name)
        {
            var result = _project.GetProjectsByEmployeeName(name);
            return Ok(result);
        }
    }
}
