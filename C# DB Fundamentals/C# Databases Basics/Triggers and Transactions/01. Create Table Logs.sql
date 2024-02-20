CREATE TRIGGER tr_AddToLogsOnAccountUpdate
ON Accounts FOR UPDATE
AS
BEGIN
    INSERT INTO Logs(AccountId,OldSum,NewSum)
    SELECT i.Id, d.Balance, i.Balance
    FROM inserted AS i 
    JOIN deleted AS d ON i.Id = d.Id
    WHERE d.Balance != i.Balance
END