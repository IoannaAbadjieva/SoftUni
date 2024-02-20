CREATE TABLE Directors
(
    Id INT PRIMARY KEY IDENTITY,
    DirectorName NVARCHAR(100) NOT NULL,
    Notes NVARCHAR(MAX)
)

INSERT INTO Directors
    (DirectorName,Notes)
VALUES
    ('Мартин Скорсезе', NULL),
    ('Стивън Спилбърг', NULL),
    ('Куентин Тарантино', NULL),
    ('Алфред Хичкок', NULL),
    ('Гай Ричи', NULL)


CREATE TABLE Genres
(
    Id INT PRIMARY KEY IDENTITY,
    GenreName NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX)
)
   
INSERT INTO Genres
    (GenreName,Notes)
VALUES
    ('Action', NULL),
    ('Horror', NULL),
    ('Comedy', NULL),
    ('Thriller', NULL),
    ('Drama', NULL)


CREATE TABLE Categories
(
    Id INT PRIMARY KEY IDENTITY,
    CategoryName NVARCHAR(50) NOT NULL,
    Notes NVARCHAR(MAX)
)
INSERT INTO Categories
    (CategoryName,Notes)
VALUES
    ('Educational', NULL),
    ('Documentary', NULL),
    ('Animation', NULL),
    ('SomethingOther', NULL),
    ('IKnowNothingAboutThis', NULL)


CREATE TABLE Movies
(
    Id INT PRIMARY KEY IDENTITY,
    Title NVARCHAR(100) NOT NULL,
    DirectorId INT NOT NULL,
    CopyrightYear SMALLINT ,
    [Length] TIME,
    GenreId INT NOT NULL,
    CategoryId INT NOT NULL,
    Rating TINYINT,
    Notes NVARCHAR(MAX)
)

INSERT INTO Movies
    (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
VALUES
    ('Авиаторът', 1, 2004, NULL, 5, 5, NULL, NULL),
    ('Гадни копилета', 3, 2009, NULL, 4, 4, NULL, NULL),
    ('Птиците', 4, 1963, NULL, 2, 5, NULL, NULL),
    ('Шерлок Холмс', 5, 2009, NULL, 4, 4, NULL, NULL),
    ('Война на световете', 2, 2005, NULL, 4, 5, NULL, NULL)