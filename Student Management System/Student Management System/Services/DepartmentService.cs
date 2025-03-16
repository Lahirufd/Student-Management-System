using System.Collections.Generic;
using Student_Management_System.DataAccess;
using Student_Management_System.Models;

namespace Student_Management_System.Services
{
    public class DepartmentService
    {
        private readonly DepartmentDataAccess _dataAccess;

        public DepartmentService(string connectionString)
        {
            _dataAccess = new DepartmentDataAccess(connectionString);
        }

        // Method to add a new department
        public void AddDepartment(Department department)
        {
            _dataAccess.AddDepartment(department);
        }

        // Method to update a department
        public void UpdateDepartment(Department department)
        {
            _dataAccess.UpdateDepartment(department);
        }

        // Method to delete a department
        public void DeleteDepartment(string departmentId)
        {
            _dataAccess.DeleteDepartment(departmentId);
        }

        // Method to get all departments
        public List<Department> GetAllDepartments()
        {
            return _dataAccess.GetAllDepartments();
        }
    }
}