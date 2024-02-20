CREATE or ALTER PROCEDURE usp_GetTownsStartingWith (@string VARCHAR(30))
AS
BEGIN
    SELECT [Name]
    FROM Towns
    WHERE [Name] LIKE CONCAT(@string,'%')
END