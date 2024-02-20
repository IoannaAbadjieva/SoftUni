CREATE DATABASE NationalTouristSitesOfBulgaria
GO

USE NationalTouristSitesOfBulgaria
GO

--1
CREATE TABLE Categories
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Locations
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    Municipality VARCHAR(50) ,
    Province VARCHAR(50)
)

CREATE TABLE Sites
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(100) NOT NULL,
    LocationId INT FOREIGN KEY REFERENCES Locations(Id) NOT NULL,
    CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
    Establishment VARCHAR(15)
)

CREATE TABLE Tourists
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL,
    Age INT NOT NULL,
    CHECK (Age >=0 AND Age <=120) ,
    PhoneNumber VARCHAR(20) NOT NULL,
    Nationality VARCHAR(30) NOT NULL,
    Reward VARCHAR(20)
)

CREATE TABLE SitesTourists
(
    TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
    SiteId INT FOREIGN KEY REFERENCES Sites(Id) NOT NULL,
    PRIMARY KEY(TouristId, SiteId)
)

CREATE TABLE BonusPrizes
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] VARCHAR(50) NOT NULL
)

CREATE TABLE TouristsBonusPrizes
(
    TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
    BonusPrizeId INT FOREIGN KEY REFERENCES BonusPrizes(Id) NOT NULL,
    PRIMARY KEY (TouristId, BonusPrizeId)
)

--2
INSERT INTO Tourists
    ([Name], Age, PhoneNumber, Nationality, Reward)
VALUES
    ('Borislava Kazakova', 52, '+359896354244', 'Bulgaria', NULL),
    ('Peter Bosh', 48, '+447911844141', 'UK', NULL),
    ('Martin Smith', 29, '+353863818592', 'Ireland'	, 'Bronze badge'),
    ('Svilen Dobrev', 49, '+359986584786', 'Bulgaria', 'Silver badge'),
    ('Kremena Popova', 38, '+359893298604', 'Bulgaria', NULL)
GO

INSERT INTO Sites
    ( [Name], LocationId, CategoryId, Establishment)
VALUES
    ('Ustra fortress', 90, 7, 'X'),
    ('Karlanovo Pyramids', 65, 7, NULL),
    ('The Tomb of Tsar Sevt', 63, 8, 'V BC'),
    ('Sinite Kamani Natural Park', 17, 1, NULL),
    ('St. Petka of Bulgaria – Rupite', 92, 6, '1994')

GO

--3
UPDATE Sites
SET Establishment = '(not defined)'
WHERE Establishment IS NULL

--4
DELETE FROM TouristsBonusPrizes
WHERE BonusPrizeId IN 
                        (
                            SELECT Id 
                            FROM BonusPrizes
                            WHERE [Name] = 'Sleeping bag'
                        )

DELETE FROM BonusPrizes
WHERE [Name] = 'Sleeping bag'

--5
SELECT
    [Name], Age, PhoneNumber, Nationality
FROM Tourists
ORDER BY Nationality, Age DESC, [Name]

--6
SELECT
    s.Name AS [Site], l.Name AS [Location], s.Establishment, c.Name AS	Category
FROM Sites AS s
    JOIN Locations AS l ON s.LocationId = l.Id
    JOIN Categories AS c ON s.CategoryId = c.Id
ORDER BY c.Name DESC, l.Name, s.Name

--7
SELECT
    l.Province, l.Municipality, l.Name AS [Location], COUNT(*) AS CountOfSites
FROM Sites  as s
    JOIN Locations as l ON s.LocationId = l.Id
WHERE l.Province = 'Sofia'
GROUP BY l.Province,l.Municipality,l.Name
ORDER BY COUNT(*) DESC, l.Name

--9
SELECT
    s.Name AS [Site], l.Name AS [Location], l.Municipality, l.Province, s.Establishment
FROM Sites  as s
    JOIN Locations as l ON s.LocationId = l.Id
WHERE l.Name NOT LIKE '[BMD]%' AND s.Establishment LIKE '%BC'
ORDER BY s.Name

--9
SELECT
    t.Name, t.Age, t.PhoneNumber, t.Nationality,
    ISNULL(bp.Name,'(no bonus prize)') AS Reward
FROM Tourists AS t
    LEFT JOIN TouristsBonusPrizes AS tp ON t.Id = tp.TouristId
    LEFT JOIN BonusPrizes AS bp ON tp.BonusPrizeId = bp.Id
ORDER BY t.Name

--10
SELECT DISTINCT
    TRIM(SUBSTRING(t.Name, CHARINDEX(' ',t.Name) + 1, LEN(t.Name) - CHARINDEX(' ',t.Name))) AS LastName,
    t.Nationality, t.Age, t.PhoneNumber
FROM Categories AS c
    JOIN Sites AS s ON c.Id = s.CategoryId
    JOIN SitesTourists AS st ON s.Id = st.SiteId
    JOIN Tourists AS t ON st.TouristId = t.Id
WHERE c.Name = 'History and archaeology'
ORDER BY LastName

GO
--11
CREATE FUNCTION udf_GetTouristsCountOnATouristSite (@Site VARCHAR(100))
RETURNS INT
BEGIN
    DECLARE @count INT
    SET @count = 
                (
                    SELECT
                        COUNT(*)
                    FROM Sites AS s
                        JOIN SitesTourists AS st ON s.Id = st.SiteId
                    WHERE s.Name = @Site
                )
RETURN @count
END

GO

SELECT dbo.udf_GetTouristsCountOnATouristSite ('Gorge of Erma River')

--12

GO

CREATE PROCEDURE usp_AnnualRewardLottery(@TouristName VARCHAR(50))
AS
BEGIN
    DECLARE @count  INT = 
                        (
                            SELECT
                                COUNT(*)
                            FROM Tourists AS t 
                                JOIN SitesTourists AS st ON t.Id = st.TouristId
                            WHERE t.Name = @TouristName
                        )
    
    IF @count >= 100
        BEGIN
            UPDATE Tourists
            SET Reward = 'Gold badge'
            WHERE Name = @TouristName
        END
    ELSE IF @count >= 50
         BEGIN
            UPDATE Tourists
            SET Reward = 'Silver badge'
            WHERE Name = @TouristName
        END
    ELSE IF @count >= 25
        BEGIN
            UPDATE Tourists
            SET Reward = 'Bronze badge'
            WHERE Name = @TouristName
        END
    
    SELECT 
        [Name], Reward
    FROM Tourists
    WHERE [Name] = @TouristName
END

GO

EXEC usp_AnnualRewardLottery 'Brus Brown'