USE master
DROP DATABASE TripService
GO

CREATE DATABASE TripService
GO


USE TripService
GO

--1
CREATE TABLE Cities
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(20) NOT NULL,
    CountryCode CHAR(2) NOT NULL
)

CREATE TABLE Hotels
(
    Id INT PRIMARY KEY IDENTITY,
    [Name] NVARCHAR(30) NOT NULL,
    CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
    EmployeeCount INT NOT NULL,
    BaseRate DECIMAL (5,2)
)

CREATE TABLE Rooms
(
    Id INT PRIMARY KEY IDENTITY,
    Price DECIMAL (5,2) NOT NULL,
    [Type] NVARCHAR(20) NOT NULL,
    Beds INT NOT NULL,
    HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL
)

CREATE TABLE Trips
(
    Id INT PRIMARY KEY IDENTITY,
    RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
    BookDate DATE NOT NULL,
    CHECK(BookDate < ArrivalDate),
    ArrivalDate DATE NOT NULL,
    CHECK(ArrivalDate < ReturnDate),
    ReturnDate DATE NOT NULL,
    CancelDate DATE
)

CREATE TABLE Accounts
(
   Id INT PRIMARY KEY IDENTITY,
   FirstName NVARCHAR(50) NOT NULL,
   MiddleName NVARCHAR(20),
   LastName  NVARCHAR(50) NOT NULL,
   CityId INT FOREIGN KEY REFERENCES Cities(Id) NOT NULL,
   BirthDate DATE NOT NULL,
   Email VARCHAR(100) NOT NULL 
)

CREATE TABLE AccountsTrips
(
    AccountId INT FOREIGN KEY REFERENCES Accounts(Id),
    TripId INT FOREIGN KEY REFERENCES Trips(Id),
    PRIMARY KEY(AccountId,TripId),
    Luggage INT NOT NULL,
    CHECK (Luggage >= 0)
)

--3
UPDATE Rooms
SET Price *= 1.14
WHERE HotelId IN (5,7,9)

--4
DELETE FROM AccountsTrips
WHERE AccountId = 47

--5
SELECT
    a.FirstName,
    a.LastName,
    FORMAT( a.BirthDate, 'MM-dd-yyyy') AS BirthDate ,
    c.Name AS Hometown,
    a.Email
FROM Accounts AS a
    JOIN Cities AS c ON a.CityId = c.Id
WHERE Email LIKE 'e%'
ORDER BY Hometown

--6
SELECT
    c.Name AS City,
    COUNT(*) AS Hotels
FROM Hotels AS h
    JOIN Cities AS c ON  h.CityId = c.Id
GROUP BY c.Name
ORDER BY Hotels DESC , c.Name 

--7
SELECT
    a.Id AS AccountId,
    CONCAT(a.FirstName, ' ', a.LastName) AS FullName,
    MAX(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS LongestTrip,
    MIN(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate)) AS ShortestTrip
FROM Accounts AS a
    JOIN AccountsTrips AS atr ON a.Id = atr.AccountId
    JOIN Trips AS t ON atr.TripId = t.Id
WHERE a.MiddleName IS NULL AND t.CancelDate IS NULL
GROUP BY a.Id, CONCAT(a.FirstName, ' ', a.LastName)
ORDER BY LongestTrip DESC, ShortestTrip

--8
SELECT TOP(10)
    c.Id,
    c.Name AS City,
    c.CountryCode AS Country,
    COUNT(*) AS Accounts
FROM Cities AS c
    JOIN Accounts AS a ON c.Id = a.CityId
GROUP BY c.Id, c.Name, c.CountryCode
ORDER BY Accounts DESC

--9
SELECT
    a.Id, a.Email, c.Name AS City,
    COUNT(*) AS Trips
FROM Accounts AS a
    JOIN Cities AS c ON a.CityId = c.Id
    JOIN AccountsTrips AS atr ON a.Id = atr.AccountId
    JOIN Trips AS t ON atr.TripId = t.Id
    JOIN Rooms AS r ON t.RoomId = r.Id
    JOIN Hotels AS h ON r.HotelId = h.Id
WHERE a.CityId = h.CityId
GROUP BY a.Id, a.Email,c.Name
ORDER BY Trips DESC, a.Id

--10
SELECT
    t.Id,
    a.FirstName + ' ' + ISNULL((a.MiddleName + ' '),'') + a.LastName AS [Full Name],
    ac.Name AS [From],
    hc.Name AS [To],
    Duration = CASE 
        WHEN (t.CancelDate IS NOT NULL) THEN 'Canceled'
        ELSE CONCAT(DATEDIFF(DAY, t.ArrivalDate, t.ReturnDate) ,' ','days')
    END
FROM Trips AS t
    JOIN AccountsTrips AS atr ON t.Id = atr.TripId
    JOIN Accounts AS a ON atr.AccountId = a.Id
    JOIN Cities AS ac ON a.CityId = ac.Id
    JOIN Rooms AS r ON t.RoomId = r.Id
    JOIN Hotels AS h ON r.HotelId = h.Id
    JOIN Cities AS hc ON h.CityId = hc.Id
ORDER BY [Full Name], t.Id

--11
GO
CREATE FUNCTION udf_GetAvailableRoom(@HotelId INT, @Date DATE, @People INT)
RETURNS VARCHAR(50)
AS
BEGIN
    DECLARE @roomId  INT = 
                            (
                                SELECT TOP(1) r.Id 
                                FROM Rooms AS r 
                                    LEFT JOIN Trips AS t ON r.Id = t.RoomId
                                WHERE HotelId = @HotelId 
                                    AND r.Beds >= @People
                                    AND r.Id NOT IN 
                                                    (
                                                        SELECT RoomId FROM Trips
                                                        WHERE @Date BETWEEN ArrivalDate AND ReturnDate
                                                        AND CancelDate IS NULL
                                                    )
                                ORDER BY r.Price DESC
                            )
    IF @roomId IS NULL
    BEGIN
        RETURN 'No rooms available'
    END

    DECLARE @roomType NVARCHAR(20) = (SELECT [Type] FROM Rooms WHERE Id = @roomId)
    DECLARE @totalPrice DECIMAL(10,2) = ((SELECT Price FROM Rooms WHERE Id = @roomId)
                                        +(SELECT BaseRate FROM Hotels WHERE Id = @HotelId ))
                                        * @People
    DECLARE @beds INT = (SELECT Beds FROM Rooms WHERE Id = @roomId)

    RETURN CONCAT('Room ', @roomId, ': ', @roomType, ' (', @beds, ' beds) - $', @totalPrice)
END
GO

SELECT dbo.udf_GetAvailableRoom(112, '2011-12-17', 2)
SELECT dbo.udf_GetAvailableRoom(94, '2015-07-26', 3)

--12
GO
CREATE PROCEDURE usp_SwitchRoom(@TripId INT, @TargetRoomId INT)
AS
BEGIN
   DECLARE @hotelId INT = (SELECT HotelId FROM Rooms as r JOIN Trips AS t ON t.RoomId = r.Id WHERE t.Id = @TripId)
   DECLARE @targetHotelId INT = (SELECT HotelId FROM Rooms WHERE Id = @TargetRoomId)

    IF (@hotelId <> @targetHotelId)
    THROW 50001, 'Target room is in another hotel!', 1

    DECLARE @tripAccounts INT = (SELECT COUNT(AccountId) FROM AccountsTrips WHERE TripId = @TripId)
    DECLARE @targetBedsCount INT = (SELECT Beds FROM Rooms WHERE Id = @TargetRoomId)

    IF (@tripAccounts > @targetBedsCount)
    THROW 50002, 'Not enough beds in target room!', 1

    UPDATE Trips
    SET RoomId = @TargetRoomId
    WHERE Id = @TripId
  
END
GO

  UPDATE Trips
    SET RoomId =11
    WHERE Id = 10

EXEC usp_SwitchRoom 10,7
SELECT RoomId FROM Trips WHERE Id = 10
