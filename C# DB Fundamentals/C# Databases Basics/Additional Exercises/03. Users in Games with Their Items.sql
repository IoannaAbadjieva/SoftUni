SELECT
    u.Username, g.Name, COUNT(*) AS [Items Count], SUM(i.Price) AS [Items Price]
FROM UsersGames AS ug
    JOIN UserGameItems AS ugt ON ug.Id = ugt.UserGameId
    JOIN Items AS i ON ugt.ItemId = i.Id
    JOIN Users AS u ON u.Id = ug.UserId
    JOIN Games AS g ON ug.GameId = g.Id
GROUP BY  u.Username,g.Name
HAVING COUNT(*) >= 10
ORDER BY [Items Count] DESC, [Items Price] DESC,u.Username 