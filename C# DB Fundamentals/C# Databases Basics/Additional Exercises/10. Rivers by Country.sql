SELECT
    c.CountryName , ct.ContinentName, COUNT(cr.RiverId) AS RiversCount ,ISNULL(SUM(r.Length), 0)  AS TotalLength
FROM Countries AS c
    JOIN Continents AS ct ON c.ContinentCode = ct.ContinentCode
    LEFT JOIN CountriesRivers AS cr ON c.CountryCode = cr.CountryCode
    LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
GROUP BY c.CountryName,ct.ContinentName 
ORDER BY RiversCount DESC, TotalLength DESC, c.CountryName 