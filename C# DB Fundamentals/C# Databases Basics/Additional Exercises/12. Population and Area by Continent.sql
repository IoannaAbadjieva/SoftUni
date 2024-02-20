SELECT
    c.ContinentName,
   SUM (CAST(cn.AreaInSqKm AS BIGINT)) AS CountriesArea,
   SUM (CAST(cn.Population AS BIGINT)) AS CountriesPopulation
FROM Continents AS c
    JOIN Countries AS cn ON c.ContinentCode = cn.ContinentCode
GROUP BY c.ContinentName
ORDER BY CountriesPopulation DESC 