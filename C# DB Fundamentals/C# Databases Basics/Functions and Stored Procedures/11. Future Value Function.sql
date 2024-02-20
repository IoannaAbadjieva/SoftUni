CREATE FUNCTION ufn_CalculateFutureValue (@initialSum DECIMAL(15,4), @rate FLOAT, @years INT)
RETURNS DECIMAL (15,4)
BEGIN
DECLARE @vs DECIMAL(15,4)
    SET @vs = @initialSum * POWER((1 + @rate),@years)
RETURN @vs
END
