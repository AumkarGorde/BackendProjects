using DapperApplicationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DapperApplicationAPI.DataAccess
{
    public interface IDepartmentRepository
    {
        Department GetDepartmentById(int departmentId);
        IEnumerable<Department> GetAllDepartments();
        IEnumerable<Department> GetAllDepartmentsWithEmployees();
        Department GetDepartmentByEmployeeName(string employeeName);
        void InsertDepartment(Department department);
        void UpdateDepartment(Department department);
        void DeleteDepartment(int departmentId);
    }

}
