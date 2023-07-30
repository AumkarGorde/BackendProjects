using Dapper;
using DapperApplicationAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApplicationAPI.DataAccess
{
    public class EmployeeProjectRepository : IEmployeeProjectRepository
    {
        private string _dbConnectionString = string.Empty;
        public EmployeeProjectRepository()
        {
            _dbConnectionString = ApplicationConfigurations.DBConnection;
        }
        public void DeleteEmployeeProject(int employeeId, int projectId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<EmployeeProject> GetAllEmployeeProjects()
        {
            throw new NotImplementedException();
        }

        public EmployeeProject GetEmployeeProject(int employeeId, int projectId)
        {
            throw new NotImplementedException();
        }

        public void InsertEmployeeProject(EmployeeProject employeeProject)
        {
            throw new NotImplementedException();
        }
    }
}
