CREATE PROCEDURE usp_AssignProject(@emloyeeId INT, @projectID INT) 
AS
BEGIN
BEGIN TRANSACTION
INSERT INTO EmployeesProjects
    (EmployeeId,ProjectId)
VALUES
    (@emloyeeId, @projectID)

DECLARE @projectsCount INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeId = @emloyeeId)
IF @projectsCount > 3
BEGIN
    ROLLBACK
    RAISERROR('The employee has too many projects!', 16, 1)
    RETURN
END
COMMIT
END