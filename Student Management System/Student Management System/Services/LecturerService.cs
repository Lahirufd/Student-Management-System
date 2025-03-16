using System;
using System.Collections.Generic;
using Student_Management_System.DataAccess;
using Student_Management_System.Models;

namespace Student_Management_System.Services
{
    public class LecturerService
    {
        private readonly LecturerDataAccess _dataAccess;

        public LecturerService(string connectionString)
        {
            _dataAccess = new LecturerDataAccess(connectionString);
        }

        // Method to get all lecturers
        public List<Lecturer> GetAllLecturers()
        {
            return _dataAccess.GetAllLecturers();
        }

        // Method to add a new lecturer
        public void AddLecturer(Lecturer lecturer)
        {
            _dataAccess.AddLecturer(lecturer);
        }

        // Method to update a lecturer
        public void UpdateLecturer(Lecturer lecturer)
        {
            _dataAccess.UpdateLecturer(lecturer);
        }

        // Method to delete a lecturer
        public void DeleteLecturer(string lecturerId)
        {
            _dataAccess.DeleteLecturer(lecturerId);
        }
    }
}