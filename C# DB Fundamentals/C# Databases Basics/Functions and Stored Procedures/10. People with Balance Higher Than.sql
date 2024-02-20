CREATE PROCEDURE usp_GetHoldersWithBalanceHigherThan (@minBalance MONEY)
AS
BEGIN
    SELECT FirstName, LastName
    FROM AccountHolders AS ah
        JOIN Accounts AS a ON ah.Id = a.AccountHolderId
    GROUP BY ah.FirstName, ah.LastName
    HAVING SUM(Balance) > @minBalance
    ORDER BY FirstName, LastName
END