using System;
using System.Data.SqlClient;

namespace Student_Management_System.DataAccess
{
    public class DashboardDataAccess
    {
        private readonly string _connectionString;

        public DashboardDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int GetStudentCount()
        {
            return ExecuteScalarQuery("SELECT COUNT(student_id) FROM ManageStudent");
        }

        public int GetDepartmentCount()
        {
            return ExecuteScalarQuery("SELECT COUNT(department_id) FROM ManageDepartment");
        }

        public int GetLecturerCount()
        {
            return ExecuteScalarQuery("SELECT COUNT(Lecturer_id) FROM Lecturer");
        }

        public int GetMaleStudentCount()
        {
            return ExecuteScalarQuery("SELECT COUNT(student_gender) FROM ManageStudent WHERE student_gender='male'");
        }

        public int GetFemaleStudentCount()
        {
            return ExecuteScalarQuery("SELECT COUNT(student_gender) FROM ManageStudent WHERE student_gender='female'");
        }

        private int ExecuteScalarQuery(string query)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(query, con))
                    {
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                // Log the error (you can use a logging framework or write to a file)
                Console.WriteLine($"Error executing query: {ex.Message}");
                throw; // Re-throw the exception to handle it in the calling method
            }
        }
    }
}