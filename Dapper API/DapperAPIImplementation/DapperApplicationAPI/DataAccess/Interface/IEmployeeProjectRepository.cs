using DapperApplicationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApplicationAPI.DataAccess
{
    public interface IEmployeeProjectRepository
    {
        EmployeeProject GetEmployeeProject(int employeeId, int projectId);
        IEnumerable<EmployeeProject> GetAllEmployeeProjects();
        void InsertEmployeeProject(EmployeeProject employeeProject);
        void DeleteEmployeeProject(int employeeId, int projectId);
    }
}
