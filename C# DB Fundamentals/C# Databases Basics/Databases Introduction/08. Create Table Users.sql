CREATE TABLE Users
(
    [Id] BIGINT PRIMARY KEY IDENTITY,
    [Username] VARCHAR(30) NOT NULL,
    [Password] VARCHAR(26) NOT NULL,
    [ProfilePicture] VARBINARY(MAX),
    [LastLoginTime] DATETIME2,
    [IsDeleted] BIT
)


INSERT INTO [Users]
( [Username], [Password],[ProfilePicture],[LastLoginTime],[IsDeleted])
VALUES
( 'Mag15', 'something159', NULL, GETDATE(), 0),
( 'user22', 'wrong261',NULL, GETDATE(), 0),
( 'user333', '14different', NULL,GETDATE(),1),
( 'user44','somethingBLACK',NULL,GETDATE(),1),
( 'user55','3MISSING',null,GETDATE(),0)