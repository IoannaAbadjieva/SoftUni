SELECT
    p.PeakName, m.MountainRange AS Mountain, cr.CountryName, ct.ContinentName
FROM Peaks AS p
    JOIN Mountains AS m ON p.MountainId = m.Id
    JOIN MountainsCountries AS mc ON m.Id = mc.MountainId
    JOIN Countries AS cr ON mc.CountryCode = cr.CountryCode
    JOIN Continents AS ct ON cr.ContinentCode = ct.ContinentCode 
ORDER BY p.PeakName, cr.CountryName