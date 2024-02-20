SELECT
    Username,
    Game,
    Max([Character]) AS Character,
    SUM(itemsStrength) + MAX(gtStrength) + MAX(chStrength) AS Strength,
    SUM(itemsDef) + MAX(gtDef) + MAX(chDef) AS Defence,
    SUM(itemsSpeed) +MAX(gtSpeed) + MAX(chSpeed) AS Speed,
    SUM(itemsMind) + MAX(gtMind) + MAX(chMind) AS Mind,
    SUM(itemsLuck) + MAX(gtLuck) + MAX(chLuck) AS Luck
FROM
    (
        SELECT
            u.Username AS Username, g.Name AS Game, c.Name AS [Character],
            SUM(its.Strength) AS itemsStrength , MAX(gts.Strength) AS gtStrength , MAX(chs.Strength)  AS chStrength,
            SUM(its.Defence) AS itemsDef , MAX(gts.Defence) AS gtDef, MAX(chs.Defence) AS chDef ,
            SUM(its.Speed) AS itemsSpeed , MAX(gts.Speed) AS gtSpeed, MAX(chs.Speed) AS chSpeed ,
            SUM(its.Mind)  AS itemsMind, MAX(gts.Mind)  AS gtMind, MAX(chs.Mind) AS chMind,
            SUM(its.Luck)  AS itemsLuck, MAX(gts.Luck) AS gtLuck, MAX(chs.Luck) AS chLuck
        FROM UsersGames AS ug
            JOIN UserGameItems AS ugt ON ug.Id = ugt.UserGameId
            JOIN Items AS i ON ugt.ItemId = i.Id
            JOIN Characters AS c ON ug.CharacterId = c.Id
            JOIN Users AS u ON ug.UserId = u.Id
            JOIN Games AS g ON ug.GameId = g.Id
            JOIN GameTypes AS gt ON g.GameTypeId = gt.Id
            JOIN [Statistics] AS its ON i.StatisticId = its.Id
            JOIN [Statistics] AS gts ON gt.BonusStatsId = gts.Id
            JOIN [Statistics] AS chs ON c.StatisticId = chs.Id
        GROUP BY u.Username, g.Name, c.Name
    ) AS SubQuery
GROUP BY Username,Game
ORDER BY Strength DESC, Defence DESC,Speed DESC, Mind DESC, Luck DESC