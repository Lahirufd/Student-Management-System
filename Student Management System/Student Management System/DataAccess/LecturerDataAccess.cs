using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Student_Management_System.Models;

namespace Student_Management_System.DataAccess
{
    public class LecturerDataAccess
    {
        private readonly string _connectionString;

        public LecturerDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Method to fetch all lecturers
        public List<Lecturer> GetAllLecturers()
        {
            List<Lecturer> lecturers = new List<Lecturer>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Lecturer", con))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lecturers.Add(new Lecturer
                            {
                                LecturerId = reader["Lecturer_id"].ToString(),
                                Name = reader["Lecturer_name"].ToString(),
                                Phone = Convert.ToInt32(reader["Lecturer_phone"]),
                                Department = reader["Lecturer_department"].ToString()
                            });
                        }
                    }
                }
            }

            return lecturers;
        }

        // Method to add a new lecturer
        public void AddLecturer(Lecturer lecturer)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("INSERT INTO Lecturer VALUES (@id, @name, @phone, @department)", con))
                {
                    cmd.Parameters.AddWithValue("@id", lecturer.LecturerId);
                    cmd.Parameters.AddWithValue("@name", lecturer.Name);
                    cmd.Parameters.AddWithValue("@phone", lecturer.Phone);
                    cmd.Parameters.AddWithValue("@department", lecturer.Department);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Method to update a lecturer
        public void UpdateLecturer(Lecturer lecturer)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("UPDATE Lecturer SET Lecturer_name=@name, Lecturer_phone=@phone, Lecturer_department=@department WHERE Lecturer_id=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", lecturer.LecturerId);
                    cmd.Parameters.AddWithValue("@name", lecturer.Name);
                    cmd.Parameters.AddWithValue("@phone", lecturer.Phone);
                    cmd.Parameters.AddWithValue("@department", lecturer.Department);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        // Method to delete a lecturer
        public void DeleteLecturer(string lecturerId)
        {
            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM Lecturer WHERE Lecturer_id=@id", con))
                {
                    cmd.Parameters.AddWithValue("@id", lecturerId);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}