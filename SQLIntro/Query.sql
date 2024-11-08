CREATE DATABASE AB_SQLIntroDB

USE AB_SQLIntroDB

CREATE TABLE Regions
(
	region_id INT IDENTITY PRIMARY KEY,
	region_name NVARCHAR(25)
)

CREATE TABLE Countries
(
	country_id CHAR(2) PRIMARY KEY,
	country_name NVARCHAR(40),
	region_id INT REFERENCES Regions(region_id)
)

CREATE TABLE Locations
(
	location_id INT IDENTITY PRIMARY KEY,
	street_address NVARCHAR(25),
	postal_code NVARCHAR(12),
	city NVARCHAR(30),
	state_province NVARCHAR(12),
	country_id CHAR(2) REFERENCES Countries(country_id)
)

CREATE TABLE Departments
(
	department_id INT IDENTITY PRIMARY KEY,
	department_name NVARCHAR(30),
	manager_id INT,
	location_id INT REFERENCES Locations(location_id)
)

CREATE TABLE Jobs
(
	job_id NVARCHAR(10) PRIMARY KEY,
	job_title NVARCHAR(35),
	min_salary DECIMAL(10, 2),
	max_salary DECIMAL(10, 2),
)

CREATE TABLE Job_Grades
(
	grade_level NVARCHAR(2) PRIMARY KEY,
	lowest_sal DECIMAL(10, 2),
	highest_sal DECIMAL(10, 2),
)

CREATE TABLE Employees
(
	employee_id INT IDENTITY PRIMARY KEY,
	first_name NVARCHAR(20),
	last_name NVARCHAR(25),
	email NVARCHAR(25),
	phone_number NVARCHAR(20),
	hire_date DATE,
	job_id NVARCHAR(10) REFERENCES Jobs(job_id),
	salary DECIMAL(10, 2),
	commission_pct INT,
	manager_id INT,
	department_id INT REFERENCES Departments(department_id)
)

CREATE TABLE Job_History
(
	employee_id INT REFERENCES Employees(employee_id),
	start_date DATE,
	end_date DATE,
	job_id NVARCHAR(10) REFERENCES Jobs(job_id),
	department_id INT REFERENCES Departments(department_id),
	PRIMARY KEY(employee_id, start_date)
)