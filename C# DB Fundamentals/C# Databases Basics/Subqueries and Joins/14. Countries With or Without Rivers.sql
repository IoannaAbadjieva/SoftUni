SELECT TOP 5
    ctr.CountryName, r.RiverName
FROM Continents AS ctn
    JOIN Countries AS ctr ON ctn.ContinentCode = ctr.ContinentCode
    LEFT JOIN CountriesRivers AS cr ON ctr.CountryCode = cr.CountryCode
    LEFT JOIN Rivers AS r ON cr.RiverId = r.Id
WHERE ctn.ContinentName = 'Africa'
ORDER BY ctr.CountryName