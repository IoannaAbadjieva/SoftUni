CREATE DATABASE Bakery
GO

USE Bakery
GO

--1
CREATE TABLE Countries
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Customers
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName NVARCHAR(25),
    LastName NVARCHAR(25),
    Gender CHAR(1),
    CHECK(Gender IN('M','F')),
    Age INT,
    PhoneNumber CHAR(10),
    CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Products
(
   Id INT PRIMARY KEY IDENTITY, 
   [Name] NVARCHAR(25) UNIQUE NOT NULL,
   [Description] NVARCHAR(250),
   Recipe NVARCHAR(MAX),
   Price MONEY NOT NULL,
   CHECK(Price > 0)
)

CREATE TABLE Feedbacks
(
    Id INT PRIMARY KEY IDENTITY,
    [Description] NVARCHAR(255),
    Rate DECIMAL(4,2) NOT NULL ,
    CHECK(Rate BETWEEN 0 AND 10),
    ProductId INT FOREIGN KEY REFERENCES Products(Id) NOT NULL,
    CustomerId INT FOREIGN KEY REFERENCES Customers(Id) NOT NULL
)

CREATE TABLE Distributors
(
     Id INT PRIMARY KEY IDENTITY, 
   [Name] NVARCHAR(25) UNIQUE NOT NULL,
   AddressText  NVARCHAR(30),
   Summary NVARCHAR(200),
   CountryId INT FOREIGN KEY REFERENCES Countries(Id)
)

CREATE TABLE Ingredients
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(30) NOT NULL,
    [Description] NVARCHAR(200),
    OriginCountryId INT FOREIGN KEY REFERENCES Countries(Id),
    DistributorId INT FOREIGN KEY REFERENCES Distributors(Id)
)

CREATE TABLE ProductsIngredients
(
    ProductId INT FOREIGN KEY REFERENCES Products(Id),
    IngredientId INT FOREIGN KEY REFERENCES Ingredients(Id),
    PRIMARY KEY (ProductId,IngredientId)
)

--3
UPDATE Ingredients
SET DistributorId = 35
WHERE [Name] IN ('Bay Leaf', 'Paprika', 'Poppy')

UPDATE Ingredients
SET OriginCountryId = 14
WHERE OriginCountryId = 8

--4
DELETE FROM Feedbacks
WHERE CustomerId = 14 OR ProductId = 5

--5
SELECT
    [Name],
    Price,
    [Description]
FROM Products
ORDER BY Price DESC, [Name]

--6
SELECT
    f.ProductId,
    f.Rate,
    f.Description,
    f.CustomerId,
    c.Age,
    c.Gender
FROM Feedbacks AS f
    JOIN Customers AS c ON f.CustomerId = c.Id
WHERE f.Rate < 5
ORDER BY f.ProductId DESC, Rate

--7
SELECT
    CONCAT(c.FirstName,' ', c.LastName) AS CustomerName ,
    c.PhoneNumber,
    c.Gender
FROM Customers AS c
    LEFT JOIN Feedbacks AS f
    ON c.Id = f.CustomerId
WHERE f.CustomerId IS NULL
ORDER BY c.Id

--8
SELECT
    c.FirstName, c.Age, c.PhoneNumber
FROM Customers AS c
    JOIN Countries AS cn ON c.CountryId = cn.Id
WHERE (c.Age >= 21 AND c.FirstName LIKE '%an%')
    OR (c.PhoneNumber LIKE '%38' AND cn.Name <> 'Greece')
ORDER BY c.FirstName, c.Age DESC

--9
SELECT
    d.Name AS DistributorName,
    i.Name AS IngredientName,
    p.Name AS ProductName,
    AVG(f.Rate) AS AverageRate
FROM Distributors AS d
    JOIN Ingredients AS i ON d.Id = i.DistributorId
    JOIN ProductsIngredients AS pi ON i.Id = pi.IngredientId
    JOIN Products AS p ON pi.ProductId = p.Id
    JOIN Feedbacks AS f ON p.Id = f.ProductId
GROUP BY d.Name, i.Name, p.Name
HAVING AVG(f.Rate) BETWEEN 5 AND 8
ORDER BY d.Name, i.Name, p.Name

--10
SELECT
    CountryName, DistributorName
FROM
    (
        SELECT
            c.Name AS CountryName,
            d.Name AS DistributorName,
            COUNT(i.Id) AS IngredientsCount,
            DENSE_RANK()OVER(PARTITION BY c.Name ORDER BY COUNT(i.Id) DESC) AS Rank
        FROM Countries AS c
            JOIN Distributors AS d ON d.CountryId = c.Id
            LEFT JOIN Ingredients AS i ON d.Id = i.DistributorId
        GROUP BY c.Name,d.Name 
     )AS SubQuery
WHERE Rank = 1
ORDER BY CountryName, DistributorName

--11
GO
CREATE VIEW v_UserWithCountries
AS
    SELECT
        CONCAT(c.FirstName,' ', c.LastName) AS CustomerName,
        c.Age,
        c.Gender,
        cn.Name
    FROM Customers AS c
        JOIN Countries AS cn ON c.CountryId = cn.Id
GO

SELECT TOP 5 *
  FROM v_UserWithCountries
 ORDER BY Age

--12
GO 

CREATE TRIGGER tr_DeleteProductsAndRelations
ON Products INSTEAD OF DELETE
AS
BEGIN

DELETE FROM Feedbacks
WHERE ProductId IN (SELECT Id FROM deleted)

DELETE FROM ProductsIngredients
WHERE ProductId IN (SELECT Id FROM deleted)

DELETE FROM Products WHERE Id IN (SELECT Id FROM deleted)

END



SELECT * FROM ProductsIngredients ORDER BY ProductId
DELETE FROM Products WHERE Id = 7






