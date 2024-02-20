CREATE PROCEDURE usp_TransferMoney(@senderId INT, @receiverId INT,@moneyAmount DECIMAL(15,4))
AS
BEGIN
BEGIN TRANSACTION 
    EXEC usp_WithdrawMoney @senderId, @moneyAmount
    EXEC usp_DepositMoney @receiverId, @moneyAmount
    DECLARE @balance DECIMAL(15,4) = ( SELECT Balance FROM Accounts WHERE Id = @senderId ) 
    IF (@balance < 0) 
    BEGIN
        ROLLBACK
        RETURN
    END
    
COMMIT TRANSACTION
END