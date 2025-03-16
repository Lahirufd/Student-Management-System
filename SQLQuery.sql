-- Step 1: Create the database
CREATE DATABASE Student_Management;
GO

-- Step 2: Use the database
USE Student_Management;
GO

-- Step 3: Create tables and insert data
CREATE TABLE ManageStudent (
    student_id VARCHAR(10) PRIMARY KEY,
    student_name VARCHAR(30),
    student_gender VARCHAR(30),
    Student_phone INT,
    Student_address VARCHAR(30),
    student_department VARCHAR(30)
);

INSERT INTO ManageStudent VALUES
('A1', 'tharuvinda', 'male', 0764498472, 'colombo', 'management'),
('A2', 'Adithya', 'male', 0702161062, 'kandy', 'marketing'),
('A3', 'dilshan', 'male', 0783254652, 'galle', 'it'),
('A4', 'kavindi', 'female', 0712345689, 'galle', 'it');

CREATE TABLE ManageDepartment (
    department_id VARCHAR(10) PRIMARY KEY,
    department_name VARCHAR(30)
);

INSERT INTO ManageDepartment VALUES
('D1', 'management'),
('D2', 'marketing'),
('D3', 'it'),
('D4', 'accounting');

CREATE TABLE Lecturer (
    Lecturer_id VARCHAR(10) PRIMARY KEY,
    Lecturer_name VARCHAR(30),
    Lecturer_phone INT,
    Lecturer_department VARCHAR(30)
);

INSERT INTO Lecturer VALUES
('L1', 'Kasun', 0722543256, 'management'),
('L2', 'Manoj', 0725894256, 'it'),
('L3', 'Hasaranga', 0725894256, 'marketing'),
('L4', 'Wanindu', 0725886546, 'accounting');

-- Step 4: Verify the data
SELECT * FROM ManageStudent;
SELECT * FROM ManageDepartment;
SELECT * FROM Lecturer;