CREATE DATABASE TASK
GO
USE TASK

--1.Create a table named "Employees" with columns for ID (integer), Name (varchar), and Salary (decimal).
 CREATE TABLE Employees
(
  emp_id INT ,
  emp_name VARCHAR (50) ,
  emp_salary DECIMAL (8,2)
);

--2.Add a new column named "Department" to the "Employees" table with data type varchar(50).
ALTER TABLE Employees 
ADD Department  VARCHAR (50); 

--3.Remove the "Salary" column from the "Employees" table.
ALTER TABLE Employees
DROP COLUMN emp_salary;
GO

--4.Rename the "Department" column in the "Employees" table to "DeptName".
EXECUTE sp_rename'Employees .Department' ,'DeptName' , 'COLUMN'
GO

--5.Create a new table called "Projects" with columns for ProjectID (integer) and ProjectName (varchar).
CREATE TABLE Projects
(
  ProjectID INT,
  ProjectName VARCHAR(50)
);
GO

--6.Add a primary key constraint to the "Employees" table for the "ID" column.
ALTER TABLE Employees
ADD constraint pk_Employees_ID PRIMARY KEY(emp_id)
GO

--7.Add a unique constraint to the "Name" column in the "Employees" table.
ALTER TABLE Employees
ADD constraint Uk_Employees_ID UNIQUE(emp_name)
GO

--8.Create a table named "Customers" with columns for CustomerID (integer), FirstName (varchar), LastName (varchar),
--and Email (varchar), and Status (varchar).
  CREATE TABLE Customers
(
  cust_ID  INT ,
  cust_fname VARCHAR (50) ,
  cust_lname VARCHAR (50) ,
  cust_email VARCHAR (50) ,
  cust_status VARCHAR (50) ,
);
GO

--9.Add a unique constraint to the combination of "FirstName" and "LastName" columns in the "Customers" table.
ALTER TABLE Customers 
ADD constraint Uk_Customers_FullName UNIQUE(FirstName , lastName)

--10.Create a table named "Orders" with columns for OrderID (integer), CustomerID (integer), OrderDate (datetime),
--and TotalAmount (decimal).
 CREATE TABLE Orders
 (
   OrderID INT ,
   CustomerID INT ,
   OrderDate datetime2 ,
   TotalAmount decimal(8,2) ,
 );

 --11.Add a check constraint to the "TotalAmount" column in the "Orders" table 
 --to ensure that it is greater than zero.
 ALTER TABLE Orders
 ADD CONSTRAINT CHECK_Orders_TotalAmount
 check (TotalAmount > 0);

 --12.Create a schema named "Sales" and move the "Orders" table into this schema.
 -- åäÇ ãÚãáÊÔ CREATE SCHEMA  ÚÔÇä åí ãæÌæÏå ÚäÏí ÈäİÓ ÇáÇÓã
  ALTER SCHEMA Sales TRANSFER dbo.Orders;

--13.Rename the "Orders" table to "SalesOrders."
EXECUTE sp_rename'Sales.Order','SalesOrders'