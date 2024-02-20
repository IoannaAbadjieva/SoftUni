USE master
GO

DROP DATABASE [Service]


CREATE DATABASE Service
GO

USE [Service]
GO
--1
CREATE TABLE Users
(
    Id INT PRIMARY KEY IDENTITY,
    Username VARCHAR(30) UNIQUE NOT NULL,
    [Password] VARCHAR(50) NOT NULL,
    [Name] VARCHAR(50),
    Birthdate DATETIME,
    Age INT,
    CHECK(Age BETWEEN 14 AND 110),
    Email VARCHAR(50) NOT NULL
)

CREATE TABLE Departments
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(25),
    LastName VARCHAR(25),
    Birthdate DATETIME,
    Age INT,
    CHECK(Age BETWEEN 18 AND 110),
    DepartmentId INT FOREIGN KEY REFERENCES Departments(Id)
)

CREATE TABLE Categories
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL
)

CREATE TABLE Status
(
    Id INT PRIMARY KEY IDENTITY,
    Label VARCHAR(20) NOT NULL
)

CREATE TABLE Reports
(
    Id INT PRIMARY KEY IDENTITY,
    CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
    StatusId INT FOREIGN KEY REFERENCES Status(Id) NOT NULL,
    OpenDate DATETIME NOT NULL,
    CloseDate DATETIME,
    [Description] VARCHAR(200) NOT NULL,
    UserId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
    EmployeeId INT FOREIGN KEY REFERENCES Employees(Id)
)

--2


--3
UPDATE Reports
SET CloseDate = GETDATE()
WHERE CloseDate IS NULL

--4
DELETE FROM Reports
WHERE StatusId = 4

--5
SELECT
    [Description], FORMAT(OpenDate,'dd-MM-yyyy') 
FROM Reports
WHERE EmployeeId IS NULL
ORDER BY OpenDate, [Description]

--6
SELECT
    r.[Description], c.Name AS CategoryName
FROM Reports AS r
    JOIN Categories AS c ON r.CategoryId = c.Id
ORDER BY r.[Description],c.Name

--7
SELECT TOP(5)
    c.Name AS CategoryName , COUNT(*) AS ReportsNumber
FROM Reports AS r
    JOIN Categories AS c ON r.CategoryId = c.Id
GROUP BY c.Name
ORDER BY ReportsNumber DESC, c.Name

--8
SELECT
    u.Username , c.Name AS CategoryName
FROM Users AS u
    JOIN Reports AS r ON u.Id = r.UserId
    JOIN Categories AS c ON r.CategoryId = c.Id
WHERE DATEPART(MONTH,u.Birthdate) = DATEPART(MONTH,r.OpenDate)
    AND DATEPART(DAY,u.Birthdate) = DATEPART(DAY,r.OpenDate)
ORDER BY u.Username,c.Name

--9
SELECT
    CONCAT(e.FirstName,' ',e.LastName) AS FullName,
    COUNT(r.EmployeeId) AS UsersCount
FROM  Employees AS e
    LEFT JOIN Reports AS r ON r.EmployeeId = e.Id
GROUP BY e.Id, CONCAT(e.FirstName,' ',e.LastName)
ORDER BY UsersCount DESC, FullName

--10
SELECT
    ISNULL(e.FirstName + ' ' + e.LastName,'None') AS Employee,
    ISNULL(d.Name,'None') AS Department,
    c.Name AS Category,
    r.[Description],
    FORMAT(r.OpenDate,'dd.MM.yyyy') AS OpenDate,
    s.Label AS Status,
    ISNULL(u.Name,'None') AS 'User'
FROM Reports AS r
    JOIN Categories AS c ON r.CategoryId = c.Id
    JOIN [Status] AS s ON r.StatusId = s.Id
    JOIN Users AS u ON r.UserId = u.Id
    LEFT JOIN Employees AS e ON r.EmployeeId = e.Id
    LEFT JOIN Departments AS d ON e.DepartmentId = d.Id
ORDER BY
    e.FirstName DESC,
    e.LastName DESC,
    d.Name,
    c.Name,
    r.Description,
    r.OpenDate,
    s.Label,
    u.Name

    --11
    GO

    CREATE FUNCTION udf_HoursToComplete(@StartDate DATETIME, @EndDate DATETIME) 
    RETURNS INT
    BEGIN
        IF (@StartDate IS NULL OR @EndDate IS NULL)
            BEGIN
                RETURN 0    
            END
        RETURN DATEDIFF(HOUR,@StartDate,@EndDate)
    END

    GO
SELECT dbo.udf_HoursToComplete(OpenDate, CloseDate) AS TotalHours
FROM Reports

    --12
GO
CREATE PROCEDURE usp_AssignEmployeeToReport(@EmployeeId INT, @ReportId INT)
AS
BEGIN
DECLARE @EmployeeDepId INT = 
                        (
                            SELECT DepartmentId
                            FROM Employees
                            WHERE Id = @EmployeeId
                        )
DECLARE @ReportDepId INT =
                        (
                            SELECT c.DepartmentId
                            FROM Reports AS r 
                            JOIN Categories AS c ON r.CategoryId = c.Id
                            WHERE r.Id = @ReportId
                        )
IF @EmployeeDepId <> @ReportDepId
THROW 50000,'Employee doesn''t belong to the appropriate department!',1

UPDATE Reports
SET EmployeeId = @EmployeeId
WHERE Id = @ReportId 

END

EXEC usp_AssignEmployeeToReport 17, 2




