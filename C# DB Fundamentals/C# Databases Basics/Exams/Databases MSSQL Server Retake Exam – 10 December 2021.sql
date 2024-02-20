USE master
GO

DROP DATABASE Airport
GO

CREATE DATABASE Airport
GO

USE Airport
GO
--1
CREATE TABLE Passengers
(
    Id INT PRIMARY KEY IDENTITY,
    FullName VARCHAR(100) UNIQUE NOT NULL,
    Email VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Pilots
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(30) UNIQUE NOT NULL,
    LastName VARCHAR(30) UNIQUE NOT NULL,
    Age TINYINT NOT NULL,
    CHECK(Age >= 21 AND Age <= 62),
    Rating FLOAT,
    CHECK(Rating >= 0 AND Rating <= 10)
)

CREATE TABLE AircraftTypes
(
    Id INT PRIMARY KEY IDENTITY,
    TypeName VARCHAR(30) UNIQUE NOT NULL
)

CREATE TABLE Aircraft
(
    Id INT PRIMARY KEY IDENTITY,
    Manufacturer VARCHAR(25) NOT NULL,
    Model VARCHAR(30) NOT NULL,
    [Year] INT NOT NULL,
    FlightHours INT,
    Condition CHAR(1) NOT NULL,
    TypeId INT FOREIGN KEY REFERENCES AircraftTypes(Id) NOT NULL
)

CREATE TABLE PilotsAircraft
(
    AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
    PilotId INT FOREIGN KEY REFERENCES Pilots(Id) NOT NULL,
    PRIMARY KEY (AircraftId, PilotId)
)

CREATE TABLE Airports
(
    Id INT PRIMARY KEY IDENTITY,
    AirportName VARCHAR(70) NOT NULL,
    Country VARCHAR(100) NOT NULL
)

CREATE TABLE FlightDestinations
(
    Id INT PRIMARY KEY IDENTITY,
    AirportId INT FOREIGN KEY REFERENCES Airports(Id) NOT NULL,
    [Start] DATETIME NOT NULL,
    AircraftId INT FOREIGN KEY REFERENCES Aircraft(Id) NOT NULL,
    PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
    TicketPrice DECIMAL(18,2) DEFAULT 15 NOT NULL
)

GO
--2
INSERT INTO Passengers
SELECT
    CONCAT(FirstName,' ', LastName), CONCAT(FirstName, LastName, '@gmail.com')
FROM Pilots
WHERE Id BETWEEN 5 AND 15


--3
UPDATE Aircraft
SET Condition = 'A'
WHERE (FlightHours IS NULL OR FlightHours <= 100)
    AND Condition IN ('B','C')
    AND [Year] >= 2013

GO  
--4
DELETE FROM FlightDestinations
WHERE PassengerId IN 
                    (
                        SELECT Id
                        FROM Passengers
                        WHERE LEN(FullName) <= 10
                    )

DELETE FROM Passengers
WHERE LEN(FullName) <= 10

--5
SELECT
    Manufacturer, Model, FlightHours, Condition
FROM Aircraft
ORDER BY FlightHours DESC

--6
SELECT
    p.FirstName, p.LastName, a.Manufacturer, a.Model, a.FlightHours
FROM Pilots AS p
    JOIN PilotsAircraft AS pa ON p.Id = pa.PilotId
    JOIN Aircraft AS a ON pa.AircraftId = a.Id
WHERE a.FlightHours IS NOT NULL
    AND a.FlightHours < 304
ORDER BY a.FlightHours DESC, p.FirstName

--7
SELECT TOP(20)
    fd.Id AS DestinationId, fd.Start, p.FullName, a.AirportName, fd.TicketPrice
FROM Passengers AS p
    JOIN FlightDestinations AS fd ON p.Id = fd.PassengerId
    JOIN Airports AS a ON fd.AirportId = a.Id
WHERE DATEPART(DAY, fd.[Start]) % 2 = 0
ORDER BY fd.TicketPrice DESC, a.AirportName

--8
SELECT
    fd.AircraftId, a.Manufacturer, a.FlightHours,
    COUNT(*) AS FlightDestinationsCount,
    ROUND(AVG(TicketPrice), 2) AS AvgPrice
FROM Aircraft AS a
    JOIN FlightDestinations AS fd ON a.Id = fd.AircraftId
GROUP BY fd.AircraftId, a.Manufacturer, a.FlightHours
HAVING  COUNT(*) >= 2
ORDER BY FlightDestinationsCount DESC, fd.AircraftId

--9
SELECT
    FullName, COUNT(*) AS CountOfAircraft, SUM(SumByAircrafts) AS TotalPayed
FROM
    (
        SELECT
            p.FullName, fd.AircraftId, SUM(fd.TicketPrice) AS SumByAircrafts
        FROM FlightDestinations AS fd
        JOIN Passengers AS p ON fd.PassengerId = p.Id
        WHERE SUBSTRING(p.FullName, 2, 1) = 'a'
        GROUP BY p.FullName, fd.AircraftId   
    ) AS AircraftsSubquery
GROUP BY FullName
HAVING COUNT(*) >= 2
ORDER BY FullName

-- 10
SELECT
    aps.AirportName, fd.Start AS DayTime, fd.TicketPrice, p.FullName, acr.Manufacturer, acr.Model
FROM FlightDestinations AS fd
    JOIN Airports AS aps ON fd.AirportId = aps.Id
    JOIN Aircraft AS acr ON fd.AircraftId = acr.Id
    JOIN Passengers AS p ON fd.PassengerId = p.Id
WHERE DATEPART(HOUR, fd.[Start]) BETWEEN 6 AND 20
AND fd.TicketPrice > 2500
ORDER BY acr.Model

--11
GO

CREATE FUNCTION udf_FlightDestinationsByEmail(@email VARCHAR(50)) 
RETURNS INT
BEGIN
DECLARE @countOfFlights INT
    SET @countOfFlights =
                            (
                                SELECT
                                    COUNT(*)
                                FROM Passengers AS p 
                                    JOIN FlightDestinations AS fd ON p.Id = fd.PassengerId
                                WHERE p.Email = @email
                                GROUP BY p.Id
                            )
RETURN  ISNULL(@countOfFlights, 0)
END

GO
--12
CREATE PROCEDURE usp_SearchByAirportName(@airportName VARCHAR(70))
AS
BEGIN
    SELECT
        ap.AirportName,
        p.FullName,
        'LevelOfTickerPrice' = CASE 
                                    WHEN fd.TicketPrice <=400 THEN 'Low'
                                    WHEN fd.TicketPrice > 400 and fd.TicketPrice <= 1500 THEN 'Medium'
                                    WHEN fd.TicketPrice > 1500 THEN 'High'
                               END,
        ac.Manufacturer,
        ac.Condition,
        atp.TypeName
    FROM AircraftTypes AS atp
        JOIN Aircraft ac ON atp.Id = ac.TypeId
        JOIN FlightDestinations AS fd ON ac.Id = fd.AircraftId
        JOIN Airports AS ap ON fd.AirportId = ap.Id
        JOIN Passengers AS p ON fd.PassengerId = p.Id
    WHERE ap.AirportName = @airportName
    ORDER BY ac.Manufacturer, p.FullName
END

GO

EXEC usp_SearchByAirportName 'Sir Seretse Khama International Airport'