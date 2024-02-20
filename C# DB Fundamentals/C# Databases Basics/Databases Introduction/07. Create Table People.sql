CREATE TABLE People
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	CHECK (DATALENGTH([Picture]) <= 2000000), 
	[Height] DECIMAL (3,2),
	[Weight]  DECIMAL (5,2),
	[Gender] CHAR(1) NOT NULL,
	CHECK ([Gender] = 'm' OR [Gender] ='f'),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR (MAX)
)

INSERT INTO [People]([Name], [Height], [Weight], [Gender], [Birthdate])
VALUES
('Petar', 1.87, 80.5, 'm', '1982-04-15'),
('Dimitar', 1.76, 80.5, 'm', '1976-03-28'),
('Lili', 1.64, 56.1, 'f', '1998-12-15'),
('Maria', 1.70, 76.3, 'f', '1986-07-21'),
('Gosho', 1.28, 34.0, 'm', '2015-04-15')