CREATE FUNCTION ufn_IsWordComprised(@setOfLetters NVARCHAR(50), @word NVARCHAR(50)) 
RETURNS BIT
AS
BEGIN
DECLARE @index INT = 1
DECLARE @letter NVARCHAR(1)

    WHILE(@index <= LEN(@word))

    BEGIN
        SET @letter = SUBSTRING(@word,@index,1)

        IF CHARINDEX(@letter,@setOfLetters) > 0
            SET @index += 1
        ELSE
            RETURN 0
    END

RETURN 1

END