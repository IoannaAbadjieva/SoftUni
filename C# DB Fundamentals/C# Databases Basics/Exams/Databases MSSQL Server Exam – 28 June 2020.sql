CREATE DATABASE ColonialJourney 
GO

USE ColonialJourney 
GO

CREATE TABLE Planets
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(30) NOT NULL
)

CREATE TABLE Spaceports
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    PlanetId INT FOREIGN KEY REFERENCES Planets(Id) NOT NULL
)

CREATE TABLE Spaceships
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    Manufacturer VARCHAR(30) NOT NULL,
    LightSpeedRate INT DEFAULT 0
)

CREATE TABLE Colonists
(
    Id INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(20) NOT NULL,
    LastName VARCHAR(20) NOT NULL,
    Ucn VARCHAR(10) UNIQUE NOT NULL,
    BirthDate DATE NOT NULL
)

CREATE TABLE Journeys
(
    Id INT PRIMARY KEY IDENTITY,
    JourneyStart DATETIME2 NOT NULL,
    JourneyEnd DATETIME2 NOT NULL,
    Purpose VARCHAR(11) ,
    CHECK(Purpose IN ('Medical', 'Technical', 'Educational', 'Military')),
    DestinationSpaceportId INT FOREIGN KEY REFERENCES Spaceports(Id) NOT NULL,
    SpaceshipId INT FOREIGN KEY REFERENCES Spaceships(Id) NOT NULL
)

CREATE TABLE TravelCards
(
    Id INT PRIMARY KEY IDENTITY,
    CardNumber CHAR(10) UNIQUE NOT NULL,
    JobDuringJourney VARCHAR(8),
    CHECK(JobDuringJourney IN ('Pilot', 'Engineer', 'Trooper','Cleaner', 'Cook')) ,
    ColonistId INT FOREIGN KEY REFERENCES Colonists(Id) NOT NULL,
    JourneyId INT FOREIGN KEY REFERENCES Journeys(Id) NOT NULL
)

--2
INSERT INTO Planets
    ([Name])
VALUES
    ('Mars'),
    ('Earth'),
    ('Jupiter'),
    ('Saturn')

INSERT INTO Spaceships
    ([Name], Manufacturer, LightSpeedRate)
VALUES
    ('Golf', 'VW', 3),
    ('WakaWaka', 'Wakanda', 4),
    ('Falcon9', 'SpaceX', 1),
    ('Bed', 'Vidolov', 6)

--3
UPDATE Spaceships
SET LightSpeedRate += 1
WHERE Id BETWEEN 8 AND 12


--4
DELETE FROM TravelCards
WHERE JourneyId BETWEEN 1 AND 3

DELETE FROM Journeys 
WHERE Id BETWEEN 1 AND 3

--5
SELECT
    Id,
    FORMAT(JourneyStart,'dd/MM/yyyy') AS JourneyStart,
    FORMAT(JourneyEnd,'dd/MM/yyyy') AS JourneyEnd
FROM Journeys
WHERE Purpose = 'Military'
ORDER BY JourneyStart

--6
SELECT
    c.Id,
    CONCAT(c.FirstName,' ', c.LastName) AS FullName
FROM Colonists AS c
    JOIN TravelCards AS tc ON c.Id = tc.ColonistId
WHERE tc.JobDuringJourney = 'Pilot'
ORDER BY c.Id

--7
SELECT
    COUNT(*) AS count 
FROM Journeys AS j
    JOIN TravelCards AS tc ON j.Id = tc.JourneyId
    JOIN Colonists AS c ON tc.ColonistId = c.Id
WHERE j.Purpose = 'Technical'

--8
SELECT
    s.Name, s.Manufacturer
FROM Colonists AS c
    JOIN TravelCards AS tc ON c.Id = tc.ColonistId
    JOIN Journeys AS j ON tc.JourneyId = j.Id
    JOIN Spaceships AS s ON j.SpaceshipId = s.Id
WHERE tc.JobDuringJourney = 'Pilot'
    AND DATEDIFF(YEAR,c.BirthDate, '01/01/2019') < 30
ORDER BY s.Name

--9
SELECT
    p.Name AS PlanetName,
    COUNT(j.Id) AS JourneysCount
FROM Planets AS p
    JOIN Spaceports AS s ON p.Id = s.PlanetId
    JOIN Journeys AS j ON s.Id = j.DestinationSpaceportId
GROUP BY p.Name
ORDER BY JourneysCount DESC, PlanetName

--10
SELECT
*
FROM
    (
        SELECT
            tc.JobDuringJourney,
            CONCAT(c.FirstName,' ', c.LastName) AS FullName,
            DENSE_RANK() OVER (PARTITION BY tc.JobDuringJourney ORDER BY c.BirthDate ) AS JobRank
        FROM TravelCards AS tc
        JOIN Colonists AS c ON tc.ColonistId = c.Id  
    ) AS SubQuery
WHERE JobRank = 2

--11
GO
CREATE FUNCTION udf_GetColonistsCount(@planetName VARCHAR (30))
RETURNS INT
BEGIN
    DECLARE @colonistCount INT = 
                                (
                                    SELECT COUNT(c.Id) 
                                    FROM Planets AS p
                                        LEFT JOIN Spaceports AS s ON p.Id = s.PlanetId
                                        LEFT JOIN Journeys AS j ON s.Id = j.DestinationSpaceportId
                                        LEFT JOIN TravelCards AS t ON j.Id = t.JourneyId
                                        LEFT JOIN Colonists AS c ON t.ColonistId = c.Id
                                    WHERE p.Name = @planetName
                                    GROUP BY p.Id  
                                )

    RETURN ISNULL(@colonistCount, 0)
END

GO
SELECT dbo.udf_GetColonistsCount('something')

SELECT * FROM Planets
SELECT * FROM Spaceports ORDER BY PlanetId

--12
GO
CREATE PROCEDURE usp_ChangeJourneyPurpose(@JourneyId INT, @NewPurpose VARCHAR(11))
AS
BEGIN
    DECLARE @journeyPurpose VARCHAR(11) = (SELECT Purpose FROM Journeys WHERE Id = @JourneyId)

    IF (@journeyPurpose IS NULL)
    THROW 50001, 'The journey does not exist!', 1

    IF (@journeyPurpose = @NewPurpose)
    THROW 50001, 'You cannot change the purpose!', 1

    UPDATE Journeys 
    SET Purpose = @NewPurpose
    WHERE Id = @JourneyId
END

GO

EXEC usp_ChangeJourneyPurpose 4, 'Technical'
EXEC usp_ChangeJourneyPurpose 2, 'Educational'
EXEC usp_ChangeJourneyPurpose 196, 'Technical'