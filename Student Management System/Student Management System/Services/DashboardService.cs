using System;
using Student_Management_System.DataAccess;

namespace Student_Management_System.Services
{
    public class DashboardService
    {
        private readonly DashboardDataAccess _dataAccess;

        public DashboardService()
        {
            // Define the connection string
            string connectionString = "Data Source=THADIYA;Initial Catalog=Student_Management;Integrated Security=True";

            // Initialize the data access layer
            _dataAccess = new DashboardDataAccess(connectionString);
        }

        // Methods to fetch data
        public int GetStudentCount() => _dataAccess.GetStudentCount();
        public int GetDepartmentCount() => _dataAccess.GetDepartmentCount();
        public int GetLecturerCount() => _dataAccess.GetLecturerCount();
        public int GetMaleStudentCount() => _dataAccess.GetMaleStudentCount();
        public int GetFemaleStudentCount() => _dataAccess.GetFemaleStudentCount();
    }
}