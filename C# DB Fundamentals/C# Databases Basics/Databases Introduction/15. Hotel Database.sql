CREATE TABLE Employees
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    Title NVARCHAR(50),
    Notes NVARCHAR(MAX)
)
INSERT INTO Employees
    (FirstName,LastName,Title,Notes)
VALUES
('Петър','Георгиев',NULL,NULL),
('Мария' ,'Иванова',NULL,NULL),
('Име','Фамилия',NULL,NULL)
 
Create TABLE Customers
(
    AccountNumber INT PRIMARY KEY,
    FirstName NVARCHAR(100) NOT NULL,
    LastName NVARCHAR(100) NOT NULL,
    PhoneNumber CHAR(10) NOT NULL,
    EmergencyName NVARCHAR(100) NOT NULL,
    EmergencyNumber CHAR(10) NOT NULL,
    Notes NVARCHAR(MAX)
)
INSERT INTO Customers
    (AccountNumber,FirstName,LastName,PhoneNumber,EmergencyName,EmergencyNumber, Notes)
VALUES
(123456789,'One','First',1111111111,'Someone',2222222222,NULL),
(234567891,'Two','Second',3333333333,'Someone',4444444444,NULL),
(345678912,'Three','Third',5555555555,'Somebody',6666666666,NULL)
 
CREATE TABLE RoomStatus
(
    RoomStatus NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX)
)
INSERT INTO RoomStatus
    (RoomStatus, Notes)
VALUES
('1',NULL),
('2',NULL),
('3',NULL)
 
CREATE TABLE RoomTypes
(
    RoomType NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX)
)
INSERT INTO RoomTypes
    (RoomType, Notes)
VALUES
('DoubleBed',NULL),
('Apartment',NULL),
('Studio',NULL)

CREATE TABLE BedTypes
(
    BedType NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX)
)
INSERT INTO BedTypes
    (BedType, Notes)
VALUES
    ('1', NULL),
    ('2', NULL),
    ('3', NULL)

CREATE TABLE Rooms
(
    RoomNumber INT PRIMARY KEY,
    RoomType NVARCHAR(50) NOT NULL,
    BedType NVARCHAR(50) NOT NULL,
    Rate SMALLINT,
    RoomStatus NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX)
)
INSERT INTO Rooms
    (RoomNumber, RoomType,BedType,Rate,RoomStatus,Notes)
VALUES
    (1, 'DoubleBed', '2', NULL, '3', NULL),
    (2, 'DoubleBed', '3', NULL, '3', NULL),
    (3, 'Apartment', '1', NULL, '3', NULL)

CREATE TABLE Payments
(
    Id INT PRIMARY KEY IDENTITY,
    EmployeeId INT NOT NULL,
    PaymentDate DATETIME2 NOT NULL,
    AccountNumber INT NOT NULL,
    FirstDateOccupied DATETIME2 NOT NULL,
    LastDateOccupied DATETIME2 NOT NULL,
    TotalDays INT,
    AmountCharged DECIMAL(15,2),
    TaxRate INT,
    TaxAmount DECIMAL,
    PaymentTotal DECIMAL(15,2),
    Notes NVARCHAR(MAX)
)
INSERT INTO Payments
    (EmployeeId,PaymentDate,AccountNumber,FirstDateOccupied,LastDateOccupied,TotalDays,AmountCharged,TaxRate,TaxAmount,PaymentTotal, Notes)
VALUES
    (2, GETDATE(), 123456789, GETDATE(), GETDATE(), NULL, NULL, NULL, NULL, NULL, NULL),
    (2, GETDATE(), 234567891, GETDATE(), GETDATE(), NULL, NULL, NULL, NULL, NULL, NULL),
    (1, GETDATE(), 345678912, GETDATE(), GETDATE(), NULL, NULL, NULL, NULL, NULL, NULL)

CREATE TABLE Occupancies
(
    Id INT PRIMARY KEY IDENTITY,
    EmployeeId INT NOT NULL,
    DateOccupied DATETIME2,
    AccountNumber CHAR(16),
    RoomNumber INT NOT NULL,
    RateApplied INT ,
    PhoneCharge DECIMAL(15,2),
    Notes NVARCHAR(MAX)
)
INSERT INTO Occupancies
    (EmployeeId,DateOccupied,AccountNumber,RoomNumber,RateApplied,PhoneCharge,Notes)
VALUES
    (1, GETDATE(), 123456789, 2, NULL, NULL, NULL),
    (3, GETDATE(), 234567891, 1, NULL, NULL, NULL),
    (2, GETDATE(), 345678912, 3, NULL, NULL, NULL)