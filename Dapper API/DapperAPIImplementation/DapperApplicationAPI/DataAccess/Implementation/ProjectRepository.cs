using Dapper;
using DapperApplicationAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApplicationAPI.DataAccess
{
    public class ProjectRepository : IProjectRepository
    {
        private string _dbConnectionString = string.Empty;
        public ProjectRepository()
        {
            _dbConnectionString = ApplicationConfigurations.DBConnection;
        }
        public void DeleteProject(int projectId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetAllProjects()
        {
            IEnumerable<Project> emp = new List<Project>();
            try
            {
                using (var connection = new SqlConnection(_dbConnectionString))
                {
                    connection.Open();
                    var query = "SELECT * FROM Projects";
                    emp = connection.Query<Project>(query);
                    connection.Close();
                }
                return emp;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public IEnumerable<Project> GetAllProjectsWithEmployees()
        {
            IEnumerable<Project> emp = new List<Project>();
            try
            {
                using (var connection = new SqlConnection(_dbConnectionString))
                {
                    connection.Open();
                    var query = @"
                                 SELECT p.ProjectId, p.ProjectName, e.EmployeeId, e.EmployeeName
                                 FROM Projects p
                                 LEFT JOIN EmployeeProjects ep ON p.ProjectId = ep.ProjectId
                                 LEFT JOIN Employees e ON ep.EmployeeId = e.EmployeeId";
                    var projectDictionary = new Dictionary<int, Project>();
                    emp = connection.Query<Project, Employee, Project>(
                        query, (project, employee)=> 
                        {
                            if (!projectDictionary.TryGetValue(project.ProjectId, out var currentProject))
                            {
                                currentProject = project;
                                currentProject.Employees = new List<Employee>();
                                projectDictionary.Add(currentProject.ProjectId, currentProject);
                            }

                            currentProject.Employees.Add(employee);
                            return currentProject;
                        },
                        splitOn: "EmployeeId"
                    ).Distinct();
                    connection.Close();
                }
                return emp;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Project GetProjectById(int projectId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Project> GetProjectsByEmployeeName(string employeeName)
        {
            IEnumerable<Project> emp = new List<Project>();
            try
            {
                using (var connection = new SqlConnection(_dbConnectionString))
                {
                    connection.Open();
                    var query = @"SELECT p.ProjectId, p.ProjectName
                                    FROM Projects p
                                    JOIN EmployeeProjects ep ON p.ProjectId = ep.ProjectId
                                    JOIN Employees e ON ep.EmployeeId = e.EmployeeId
                                    WHERE e.EmployeeName = @EmployeeName";
                    var parameters = new { EmployeeName = employeeName };
                    emp = connection.Query<Project>(query, parameters);
                    connection.Close();
                }
                return emp;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void InsertProject(Project project)
        {
            throw new NotImplementedException();
        }

        public void UpdateProject(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
