﻿using Dapper;
using DapperApplicationAPI.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApplicationAPI.DataAccess
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private string _dbConnectionString = string.Empty;
        public EmployeeRepository()
        {
            _dbConnectionString = ApplicationConfigurations.DBConnection;
        }
        public void DeleteEmployee(int employeeId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            IEnumerable<Employee> emp = new List<Employee>();
            try
            {
                using (var connection = new SqlConnection(_dbConnectionString))
                {
                    connection.Open();
                    var query = "SELECT * FROM Employees";
                    emp = connection.Query<Employee>(query);
                    connection.Close();
                }
                return emp;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        // splitOn will split will split the output columns of query anything up to that column maps to the first parameter employee and after that to department
        // 
        public IEnumerable<Employee> GetAllEmployeesWithDepartment()
        {
            IEnumerable<Employee> emp = new List<Employee>();
            try
            {
                using (var connection = new SqlConnection(_dbConnectionString))
                {
                    connection.Open();
                    var query = @"
                                    SELECT e.*, d.DepartmentName
                                    FROM Employees e
                                    LEFT JOIN Departments d ON e.DepartmentId = d.DepartmentId";
                    //query with 2  input types - employee and department. This returns a single output employee
                    emp = connection.Query<Employee, Department, Employee>(
                        query, (employee, department) =>
                        {
                            // this runs for each row, we fill each employee object and return the same
                            employee.Department = department;
                            employee.DepartmentId = department.DepartmentId;
                            return employee;
                        },
                        splitOn: "DepartmentId"
                     );
                    connection.Close();
                }
                return emp;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public Employee GetEmployeeById(int employeeId)
        {
            throw new NotImplementedException();
        }

        public void InsertEmployee(Employee employee)
        {
            throw new NotImplementedException();
        }

        public void UpdateEmployee(Employee employee)
        {
            try
            {
                using (var connection = new SqlConnection(_dbConnectionString))
                {
                    connection.Open();
                    var query = @"UPDATE Employees SET EmployeeName = @NewEmployeeName WHERE EmployeeId = @EmployeeId";
                    var parameters = new { EmployeeId = employee.EmployeeId, NewEmployeeName = employee.EmployeeName };
                    connection.Execute(query, parameters);
                    connection.Close();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
