using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Student_Management_System.Models;

namespace Student_Management_System.DataAccess
{
    public class StudentDataAccess
    {
        private readonly string _connectionString;

        public StudentDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Method to fetch all students
        public List<Student> GetAllStudents()
        {
            List<Student> students = new List<Student>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM ManageStudent", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            students.Add(new Student
                            {
                                StudentId = reader["student_id"].ToString(),
                                Name = reader["student_name"].ToString(),
                                Gender = reader["student_gender"].ToString(),
                                Phone = Convert.ToInt32(reader["Student_phone"]),
                                Address = reader["Student_address"].ToString(),
                                Department = reader["student_department"].ToString()
                            });
                        }
                    }
                }
            }

            return students;
        }

        // Method to add a new student
        public void AddStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO ManageStudent VALUES (@id, @name, @gender, @phone, @address, @department)", con))
                {
                    cmd.Parameters.AddWithValue("@id", student.StudentId);
                    cmd.Parameters.AddWithValue("@name", student.Name);
                    cmd.Parameters.AddWithValue("@gender", student.Gender);
                    cmd.Parameters.AddWithValue("@phone", student.Phone);
                    cmd.Parameters.AddWithValue("@address", student.Address);
                    cmd.Parameters.AddWithValue("@department", student.Department);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Method to update a student
        public void UpdateStudent(Student student)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE ManageStudent SET student_name=@name, student_gender=@gender, Student_phone=@phone, Student_address=@address, student_department=@department WHERE student_id=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", student.StudentId);
                    cmd.Parameters.AddWithValue("@name", student.Name);
                    cmd.Parameters.AddWithValue("@gender", student.Gender);
                    cmd.Parameters.AddWithValue("@phone", student.Phone);
                    cmd.Parameters.AddWithValue("@address", student.Address);
                    cmd.Parameters.AddWithValue("@department", student.Department);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Method to delete a student
        public void DeleteStudent(string studentId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM ManageStudent WHERE student_id=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", studentId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}