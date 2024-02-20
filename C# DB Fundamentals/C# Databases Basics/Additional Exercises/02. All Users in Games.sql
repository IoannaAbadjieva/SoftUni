SELECT
    g.Name, gt.Name, u.Username, ug.[Level], ug.Cash, c.Name
FROM UsersGames AS ug
    JOIN Users AS u ON u.Id = ug.UserId
    JOIN Games AS g ON ug.GameId = g.Id
    JOIN GameTypes AS gt ON g.GameTypeId = gt.Id
    JOIN Characters AS c ON ug.CharacterId = c.Id
ORDER BY ug.[Level] DESC, u.Username, g.Name