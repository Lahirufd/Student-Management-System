using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Student_Management_System.Models;

namespace Student_Management_System.DataAccess
{
    public class DepartmentDataAccess
    {
        private readonly string _connectionString;

        public DepartmentDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Method to fetch all departments
        public List<Department> GetAllDepartments()
        {
            List<Department> departments = new List<Department>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ManageDepartment", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            departments.Add(new Department
                            {
                                DepartmentId = reader["department_id"].ToString(),
                                DepartmentName = reader["department_name"].ToString()
                            });
                        }
                    }
                }
            }

            return departments;
        }

        // Method to add a new department
        public void AddDepartment(Department department)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO ManageDepartment VALUES (@id, @name)", con))
                {
                    cmd.Parameters.AddWithValue("@id", department.DepartmentId);
                    cmd.Parameters.AddWithValue("@name", department.DepartmentName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Method to update a department
        public void UpdateDepartment(Department department)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE ManageDepartment SET department_name=@name WHERE department_id=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", department.DepartmentId);
                    cmd.Parameters.AddWithValue("@name", department.DepartmentName);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Method to delete a department
        public void DeleteDepartment(string departmentId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM ManageDepartment WHERE department_id=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", departmentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}