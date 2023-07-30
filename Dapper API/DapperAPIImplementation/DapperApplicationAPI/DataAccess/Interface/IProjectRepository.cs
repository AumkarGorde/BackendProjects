using DapperApplicationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApplicationAPI.DataAccess
{
    public interface IProjectRepository
    {
        Project GetProjectById(int projectId);
        IEnumerable<Project> GetAllProjects();
        IEnumerable<Project> GetAllProjectsWithEmployees();
        IEnumerable<Project> GetProjectsByEmployeeName(string employeeName);
        void InsertProject(Project project);
        void UpdateProject(Project project);
        void DeleteProject(int projectId);
    }
}
