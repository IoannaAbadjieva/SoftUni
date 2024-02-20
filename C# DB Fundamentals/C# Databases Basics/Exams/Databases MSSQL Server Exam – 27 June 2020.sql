USE master
GO

DROP DATABASE WMS
GO

CREATE DATABASE WMS
GO

USE WMS
GO

CREATE TABLE Clients
(
    ClientId INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Phone CHAR(12) NOT NULL
)

CREATE TABLE Mechanics
(
    MechanicId INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    [Address] VARCHAR(255) NOT NULL
)

CREATE TABLE Models
(
    ModelId INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) UNIQUE NOT NULL 
)

CREATE TABLE Jobs
(
    JobId INT PRIMARY KEY IDENTITY,
    ModelId INT FOREIGN KEY REFERENCES Models(ModelId) NOT NULL,
    [Status] VARCHAR(11) DEFAULT 'Pending' NOT NULL,
    CHECK ([Status] IN ('Pending', 'In Progress', 'Finished')),
    ClientId INT FOREIGN KEY REFERENCES Clients(ClientId) NOT NULL,
    MechanicId INT FOREIGN KEY REFERENCES Mechanics(MechanicId),
    IssueDate DATE NOT NULL,
    FinishDate DATE
)

CREATE TABLE Orders
(
    OrderId INT PRIMARY KEY IDENTITY,
    JobId INT FOREIGN KEY REFERENCES Jobs(JobId) NOT NULL,
    IssueDate DATE,
    Delivered BIT DEFAULT 0 NOT NULL
)

CREATE TABLE Vendors
(
    VendorId INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Parts
(
    PartId INT PRIMARY KEY IDENTITY,
    SerialNumber VARCHAR(50) UNIQUE NOT NULL,
    [Description] VARCHAR(255),
    Price DECIMAL(6,2) NOT NULL,
    CHECK (Price > 0 AND Price < 10000),
    VendorId INT FOREIGN KEY REFERENCES Vendors(VendorId) NOT NULL,
    StockQty INT DEFAULT 0 NOT NULL,
    CHECK(StockQty >= 0)
)

CREATE TABLE OrderParts
(
    OrderId INT FOREIGN KEY REFERENCES Orders(OrderId),
    PartId INT FOREIGN KEY REFERENCES Parts(PartId),
    PRIMARY KEY(OrderId,PartId),
    Quantity INT DEFAULT 1 NOT NULL,
    CHECK(Quantity > 0)
)

CREATE TABLE PartsNeeded
(
    JobId INT FOREIGN KEY REFERENCES Jobs(JobId),
    PartId INT FOREIGN KEY REFERENCES Parts(PartId),
    PRIMARY KEY(JobId,PartId),
    Quantity INT DEFAULT 1 NOT NULL,
    CHECK(Quantity > 0)
)

--problem 02
INSERT INTO Clients
    (FirstName, LastName, Phone)
VALUES
    ('Teri', 'Ennaco', '570-889-5187'),
    ('Merlyn', 'Lawler', '201-588-7810'),
    ('Georgene', 'Montezuma', '925-615-5185'),
    ('Jettie', 'Mconnell', '908-802-3564'),
    ('Lemuel', 'Latzke', '631-748-6479'),
    ('Melodie', 'Knipp'	, '805-690-1682'),
    ('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts
    (SerialNumber, [Description], Price, VendorId)
VALUES
    ('WP8182119', 'Door Boot Seal', 117.86, 2),
    ('W10780048', 'Suspension Rod', 42.81, 1),
    ('W10841140', 'Silicone Adhesive', 6.77, 4),
    ('WPY055980', 'High Temperature Adhesive', 13.94, 3)

--3
SELECT * FROM Mechanics

UPDATE Jobs
SET [Status] = 'In Progress', MechanicId = 3
WHERE [Status] = 'Pending'


SELECT * FROM Mechanics

--4
DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderId = 19

--5
SELECT
CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
j.[Status],
j.IssueDate
FROM Mechanics AS m 
LEFT JOIN Jobs AS j ON m.MechanicId = j.MechanicId
ORDER BY m.MechanicId, j.IssueDate, j.JobId

--6
SELECT
    CONCAT(c.FirstName, ' ', c.LastName) AS Client,
    DATEDIFF(DAY,j.IssueDate,'2017-04-24') AS [Days going],
    j.[Status]
FROM Clients AS c
    JOIN Jobs AS j ON c.ClientId = j.ClientId
WHERE j.[Status] IN('In Progress','Pending')
ORDER BY [Days going] DESC, c.ClientId


SELECT * FROM Mechanics
SELECT * FROM Jobs ORDER BY MechanicId

--7
SELECT
    CONCAT(m.FirstName, ' ', m.LastName) AS Mechanic,
    AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
FROM
    Mechanics AS m
    JOIN Jobs AS j ON m.MechanicId = j.MechanicId
WHERE FinishDate IS NOT NULL
GROUP BY m.MechanicId,CONCAT(m.FirstName, ' ', m.LastName)
ORDER BY m.MechanicId

--8
SELECT
    CONCAT(FirstName, ' ', LastName) AS Available
FROM Mechanics
WHERE MechanicId  NOT IN
                        (
                            SELECT MechanicId
                            FROM Jobs
                            WHERE [Status] <> 'Finished' AND MechanicId IS NOT NULL
                        )
ORDER BY MechanicId

--9
SELECT
    j.JobId, ISNULL(SUM(p.Price * op.Quantity), 0) AS Total
FROM Jobs AS j
    LEFT JOIN Orders AS o ON j.JobId = o.JobId
    LEFT JOIN OrderParts AS op ON o.OrderId = op.OrderId
    LEFT JOIN Parts AS p ON op.PartId = p.PartId
WHERE j.[Status] = 'Finished'
GROUP BY j.JobId
ORDER BY Total DESC, j.JobId

 --10
 SELECT
   p.PartId, p.[Description], pn.Quantity AS [Required], p.StockQty AS [In Stock], ISNULL(op.PartId, 0) AS Ordered
FROM Jobs AS j
    JOIN PartsNeeded AS pn ON j.JobId = pn.JobId
    JOIN Parts AS p ON pn.PartId = p.PartId
    LEFT JOIN Orders AS o ON j.JobId = o.JobId
    LEFT JOIN OrderParts AS op ON (p.PartId = op.PartId AND op.OrderId = o.OrderId)
WHERE j.[Status] <> 'Finished'
AND pn.Quantity > (p.StockQty + ISNULL(op.PartId, 0))
ORDER BY p.PartId

--11
GO

CREATE PROCEDURE usp_PlaceOrder(@jobID INT, @serialnumber VARCHAR(50), @quantity INT)
AS 
BEGIN
    IF (@quantity <= 0)
    THROW 50012, 'Part quantity must be more than zero!', 1

    DECLARE @id  INT = (SELECT JobId FROM Jobs WHERE JobId = @jobID)
    IF @id IS NULL
    THROW 50013, 'Job not found!', 1

    DECLARE @status VARCHAR(11) =(SELECT [Status] FROM Jobs WHERE JobId = @jobID)
    IF (@status = 'Finished') 
    THROW 50011 ,'This job is not active!', 1

    DECLARE @partId  VARCHAR(50) = (SELECT PartId FROM Parts WHERE SerialNumber = @serialnumber)
    IF @partId IS NULL
    THROW 50014, 'Part not found!', 1

    DECLARE @orderId INT = (SELECT OrderId FROM Orders WHERE JobId = @jobID AND IssueDate IS NULL) 
    IF (@orderId IS NULL)
    BEGIN
        INSERT INTO Orders(JobId, IssueDate) VALUES (@jobID, NULL)

        SET @orderId = (SELECT OrderId FROM Orders WHERE JobId = @jobID AND IssueDate IS NULL)
      
        INSERT INTO OrderParts(OrderId, PartId, Quantity) VALUES (@orderId, @partId, @quantity) 
    END
    ELSE
    BEGIN
        SET @partId = (SELECT PartId FROM OrderParts WHERE OrderId = @orderId)
        IF (@partId IS NULL)
        INSERT INTO OrderParts (OrderId,PartId, Quantity) VALUES (@orderId, @partId, @quantity)
        ELSE
        UPDATE OrderParts
        SET Quantity += @quantity
        WHERE OrderId = @orderId AND PartId = @partId
    END
END

GO

DECLARE @err_msg AS NVARCHAR(MAX);
BEGIN TRY
  EXEC usp_PlaceOrder 1, 'ZeroQuantity', 0
END TRY

BEGIN CATCH
  SET @err_msg = ERROR_MESSAGE();
  SELECT @err_msg
END CATCH

--12
GO  

CREATE FUNCTION udf_GetCost(@jobID INT)
RETURNS DECIMAL(10,2)
BEGIN
   RETURN 
        (
            SELECT
                ISNULL(SUM(op.Quantity * p.Price), 0)
            FROM Jobs AS j 
                LEFT JOIN Orders AS o  ON  j.JobId = o.JobId
                LEFT JOIN OrderParts AS op ON o.OrderId = op.OrderId
                LEFT JOIN Parts AS p ON op.PartId = p.PartId
            WHERE j.JobId = @jobID
            GROUP BY j.JobId
        ) 
END 
GO
SELECT dbo.udf_GetCost(3)