SELECT c.CountryCode, COUNT(m.Id) AS MountainRanges
FROM Countries AS c
    JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
    JOIN Mountains as m ON mc.MountainId = m.Id
WHERE c.CountryName IN ('United States', 'Russia' , 'Bulgaria')
GROUP BY c.CountryCode