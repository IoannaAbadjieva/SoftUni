CREATE TABLE Categories
(
    Id INT PRIMARY KEY IDENTITY,
    CategoryName NVARCHAR(30) NOT NULL,
    DailyRate DECIMAL(5,2),
    WeeklyRate DECIMAL(5,2),
    MonthlyRate DECIMAL(5,2),
    WeekendRate DECIMAL(5,2)
)

INSERT INTO [Categories]
    (CategoryName)
VALUES
    ('SomethingWrong'),
    ('SomethingRight'),
    ('SomethingMissing')

CREATE TABLE Cars
(
    Id INT PRIMARY KEY IDENTITY,
    PlateNumber NVARCHAR (15) NOT NULL,
    Manufacturer NVARCHAR(30) ,
    Model NVARCHAR(30) ,
    CarYear SMALLINT,
    CategoryId INT NOT NULL,
    Doors TINYINT,
    Picture VARBINARY(MAX),
    Condition NVARCHAR(15),
    Available BIT NOT NULL
)

INSERT INTO [Cars]
    (PlateNumber,CategoryId,Available)
VALUES
    ('12345678', 1, 0),
    ('87654321', 1, 0),
    ('46215678', 3, 1)

CREATE TABLE Employees
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Title NVARCHAR(50),
    Notes NVARCHAR(MAX)
)

INSERT INTO [Employees]
    (FirstName,LastName)
VALUES
    ('One', 'First'),
    ('Two', 'Second'),
    ('Three', 'Third')

CREATE TABLE Customers
(
    Id INT PRIMARY KEY IDENTITY,
    DriverLicenceNumber VARCHAR(15) NOT NULL,
    FullName NVARCHAR(100),
    [Address] NVARCHAR(100),
    City NVARCHAR(50),
    ZIPCode INT,
    Notes NVARCHAR(MAX)
)

INSERT INTO [Customers]
    (DriverLicenceNumber,FullName)
VALUES
    ('12345678910', 'Something Black'),
    ('54321678910', 'Something Light'),
    ('5432110987', 'Something Different')

CREATE TABLE RentalOrders
(
    Id INT PRIMARY KEY IDENTITY,
    EmployeeId INT NOT NULL,
    CustomerId INT NOT NULL,
    CarId INT NOT NULL,
    TankLevel TINYINT ,
    KilometrageStart INT ,
    KilometrageEnd INT ,
    TotalKilometrage INT,
    StartDate DATE ,
    EndDate DATE,
    TotalDays INT,
    RateApplied INT,
    TaxRate DECIMAL(5,2),
    OrderStatus NVARCHAR(50),
    Notes NVARCHAR(MAX)
)

INSERT INTO [RentalOrders]
    (EmployeeId,CustomerId,CarId,StartDate)
VALUES
    (1, 1, 1, GETDATE()),
    (2, 2, 2, GETDATE()),
    (3, 3, 3, GETDATE())