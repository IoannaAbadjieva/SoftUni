CREATE PROCEDURE usp_WithdrawMoney(@accountId INT, @moneyAmount DECIMAL(15,4)) 
AS
BEGIN 
    IF (@moneyAmount > 0)
        UPDATE Accounts
        SET Balance -= @moneyAmount
        WHERE Id = @accountId
END