SELECT m.MountainRange, p.PeakName, p.Elevation
FROM Peaks  as p
    JOIN Mountains as m
    ON m.Id = p.MountainId
WHERE m.MountainRange = 'Rila'
ORDER BY p.Elevation DESC