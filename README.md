# 🎓 Student Management System 🎓

This is a Student Management System application developed as my first GUI-based project. It allows users to manage students, lecturers, and departments in an educational institution. The application is built using C# and Windows Forms, with a MySQL database for data storage.

## ✨ Features

### 👨‍🎓 Student Management:
- Add, update, delete, and view student details
- Fields: Student ID, Name, Gender, Phone, Address, and Department

### 👩‍🏫 Lecturer Management:
- Add, update, delete, and view lecturer details
- Fields: Lecturer ID, Name, Phone, and Department

### 🏛️ Department Management:
- Add, update, delete, and view department details
- Fields: Department ID and Department Name

### 🔐 User Authentication:
- Login with a username and password
- Default credentials:
  - Username: Admin
  - Password: password

## 📋 Prerequisites

Before running the application, ensure you have the following installed:
- .NET Framework (version 4.7.2 or higher)
- MySQL Server (to host the database)
- MySQL Workbench (optional, for managing the database)
- Visual Studio (recommended for running and modifying the project)

## 🚀 Setup Instructions

### 1. Clone the Repository
Clone this repository to your local machine using the following command:

```bash
git clone https://github.com/Lahirufd/Student-Management-System.git
```
### 2. Set Up the Database
Open MySQL Workbench or any MySQL client.
Execute the provided SQL script (Student_Management.sql) to create the database and tables. This script includes:
- Database creation
- Table creation for students, lecturers, and departments
- Sample data insertion (optional)

To execute the script:
```bash
SOURCE path/to/Student_Management.sql;
```
Update the connection string in the application to match your MySQL server details. The connection string is located in the app.config file or directly in the code (depending on your implementation).
Example connection string:
```bash
string connectionString = "Data Source=YOUR_SERVER_NAME;Initial Catalog=Student_Management;User ID=YOUR_USERNAME;Password=YOUR_PASSWORD";
```
### 3. Run the Application
- Open the project in Visual Studio
- Build the solution to restore NuGet packages and compile the application
- Run the application by pressing F5 or clicking the Start button

### 4. Login to the Application
Use the following default credentials to log in:
- Username: Admin
- Password: password

## 🏗️ Application Structure

The project is organized into the following components:

### 📊 Models:
- Student.cs: Represents the student entity
- Lecturer.cs: Represents the lecturer entity
- Department.cs: Represents the department entity

### 💾 DataAccess:
- StudentDataAccess.cs: Handles database operations for students
- LecturerDataAccess.cs: Handles database operations for lecturers
- DepartmentDataAccess.cs: Handles database operations for departments

### ⚙️ Services:
- StudentService.cs: Acts as a middle layer between the UI and data access for students
- LecturerService.cs: Acts as a middle layer between the UI and data access for lecturers
- DepartmentService.cs: Acts as a middle layer between the UI and data access for departments

### 🖼️ Forms:
- ManageStudentForm.cs: Form for managing students
- ManageLecturerForm.cs: Form for managing lecturers
- ManageDepartmentForm.cs: Form for managing departments
- LoginForm.cs: Form for user authentication

## 🤝 How to Contribute

If you'd like to contribute to this project, follow these steps:
- Fork the repository
- Create a new branch for your feature or bug fix
- Make your changes and commit them with descriptive messages
- Push your changes to your forked repository
- Submit a pull request to the main repository

## 📜 License
This project is licensed under the MIT License. Feel free to use, modify, and distribute it as per the license terms.

## 💭 About This Project
This is my first GUI-based application developed as part of my learning journey in C# and Windows Forms. It was a great experience building this project, and I hope it serves as a useful example for others who are learning to create desktop applications.
If you have any questions or feedback, feel free to reach out!

## 🙏 Acknowledgments
Thanks to the .NET community for providing excellent resources and documentation
Special thanks to my mentors and peers for their guidance and support during the development of this project
