using System;
using System.Collections.Generic;
using Student_Management_System.DataAccess;
using Student_Management_System.Models;

namespace Student_Management_System.Services
{
    public class StudentService
    {
        private readonly StudentDataAccess _dataAccess;

        public StudentService(string connectionString)
        {
            _dataAccess = new StudentDataAccess(connectionString);
        }

        // Method to add a new student
        public void AddStudent(Student student)
        {
            _dataAccess.AddStudent(student);
        }

        // Method to update a student
        public void UpdateStudent(Student student)
        {
            _dataAccess.UpdateStudent(student);
        }

        // Method to delete a student
        public void DeleteStudent(string studentId)
        {
            _dataAccess.DeleteStudent(studentId);
        }

        // Method to get all students
        public List<Student> GetAllStudents()
        {
            return _dataAccess.GetAllStudents();
        }
    }
}