CREATE TRIGGER tr_NotificationOnBalanceChange
ON Logs FOR INSERT
AS
BEGIN
    INSERT INTO NotificationEmails(Recipient, [Subject], Body)
    SELECT
        i.AccountId,
        CONCAT('Balance change for account: ', i.AccountId),
        CONCAT('On ',FORMAT(GETDATE(),'MMM dd yyyy h:mm tt'),' your balance was changed from ',i.OldSum, ' to ', i.NewSum, '.')
    FROM inserted AS i 
END