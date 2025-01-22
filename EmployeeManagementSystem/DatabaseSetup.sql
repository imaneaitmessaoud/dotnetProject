-- Create the database
CREATE DATABASE EmployeeManagementSystem;

-- Use the database
USE EmployeeManagementSystem;

-- Create the employees table
CREATE TABLE employees (
    id INT PRIMARY KEY IDENTITY(1,1),
    employee_id NVARCHAR(50) NOT NULL,
    full_name NVARCHAR(100) NOT NULL,
    gender NVARCHAR(10) NOT NULL,
    contact_number NVARCHAR(15) NOT NULL,
    position NVARCHAR(50) NOT NULL,
    image NVARCHAR(255),
    salary INT NOT NULL,
    status NVARCHAR(20) NOT NULL,
    insert_date DATE NOT NULL,
    update_date DATE,
    delete_date DATE
);

-- Create the users table
CREATE TABLE users (
    id INT PRIMARY KEY IDENTITY(1,1),
    username NVARCHAR(50) NOT NULL,
    password NVARCHAR(50) NOT NULL,
    date_register DATE NOT NULL
);

-- Insert employees
INSERT INTO employees (employee_id, full_name, gender, contact_number, position, image, salary, insert_date, status)
VALUES ('E001', 'John Doe', 'Male', '1234567890', 'Manager', 'C:\\Images\\E001.jpg', 50000, GETDATE(), 'Active');

INSERT INTO employees (employee_id, full_name, gender, contact_number, position, image, salary, insert_date, status)
VALUES ('E002', 'Jane Smith', 'Female', '0987654321', 'Developer', 'C:\\Images\\E002.jpg', 60000, GETDATE(), 'Active');

INSERT INTO employees (employee_id, full_name, gender, contact_number, position, image, salary, insert_date, status)
VALUES ('E003', 'Alice Johnson', 'Female', '1122334455', 'Designer', 'C:\\Images\\E003.jpg', 55000, GETDATE(), 'Active');

INSERT INTO employees (employee_id, full_name, gender, contact_number, position, image, salary, insert_date, status)
VALUES ('E004', 'Bob Brown', 'Male', '6677889900', 'Tester', 'C:\\Images\\E004.jpg', 50000, GETDATE(), 'Active');

-- Insert an admin user
INSERT INTO users (username, password, date_register)
VALUES ('admin', 'admin123', GETDATE());
