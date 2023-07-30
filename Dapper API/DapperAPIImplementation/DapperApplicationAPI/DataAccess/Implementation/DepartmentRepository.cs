using Dapper;
using DapperApplicationAPI.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApplicationAPI.DataAccess
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private string _dbConnectionString = string.Empty;
        public DepartmentRepository()
        {
            _dbConnectionString = ApplicationConfigurations.DBConnection;
        }
        public void DeleteDepartment(int departmentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            IEnumerable<Department> emp = new List<Department>();
            try
            {
                using (var connection = new SqlConnection(_dbConnectionString))
                {
                    connection.Open();
                    var query = "SELECT * FROM Departments";
                    emp = connection.Query<Department>(query);
                    connection.Close();
                }
                return emp;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        //https://www.learndapper.com/relationships
        public IEnumerable<Department> GetAllDepartmentsWithEmployees()
        {
            IEnumerable<Department> emp = new List<Department>();
            try
            {
                using (var connection = new SqlConnection(_dbConnectionString))
                {
                    connection.Open();
                    var query = @"
        SELECT d.DepartmentId, d.DepartmentName, e.EmployeeId, e.EmployeeName
            FROM Departments d
            LEFT JOIN Employees e ON d.DepartmentId = e.DepartmentId";

                    var departmentDictionary = new Dictionary<int, Department>();
                    emp = connection.Query<Department, Employee, Department>(
                        query,
                        (department, employee) =>
                        {
                            if (!departmentDictionary.TryGetValue(department.DepartmentId, out var currentDepartment))
                            {
                                currentDepartment = department;
                                currentDepartment.Employees = new List<Employee>();
                                departmentDictionary.Add(currentDepartment.DepartmentId, currentDepartment);
                            }

                            if (employee != null)
                                currentDepartment.Employees.Add(employee);

                            return currentDepartment;
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

        public Department GetDepartmentByEmployeeName(string employeeName)
        {
            Department emp = new Department();
            try
            {
                using (var connection = new SqlConnection(_dbConnectionString))
                {
                    connection.Open();
                    string storedProcedure = "GetDepartmentByEmployeeName";
                    var parameters = new { EmployeeName = employeeName };
                    emp = connection.QuerySingleOrDefault<Department>(
                        storedProcedure,
                        parameters,
                        commandType: CommandType.StoredProcedure);
                    connection.Close();
                }
                return emp;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Department GetDepartmentById(int departmentId)
        {
            throw new NotImplementedException();
        }

        public void InsertDepartment(Department department)
        {
            throw new NotImplementedException();
        }

        public void UpdateDepartment(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
