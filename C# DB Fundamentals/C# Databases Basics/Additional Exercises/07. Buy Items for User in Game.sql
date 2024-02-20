INSERT INTO UserGameItems(UserGameId,ItemId)
SELECT ug.Id,i.Id
FROM UsersGames AS ug, Items AS i
WHERE ug.Id = (SELECT Id FROM UsersGames  WHERE  UserId = (SELECT Id FROM Users WHERE Username = 'Alex')
                                          AND GameId =(SELECT Id FROM Games WHERE Name = 'Edinburgh')) 
AND i.Id IN (SELECT Id FROM Items WHERE [Name] IN  ('Blackguard',
                                            'Bottomless Potion of Amplification', 
                                            'Eye of Etlich (Diablo III)', 
                                            'Gem of Efficacious Toxin', 
                                            'Golden Gorget of Leoric',
                                            'Hellfire Amulet'))

UPDATE UsersGames
SET Cash -= (select SUM(Price) FROM Items WHERE[Name]  IN('Blackguard',
                                            'Bottomless Potion of Amplification', 
                                            'Eye of Etlich (Diablo III)', 
                                            'Gem of Efficacious Toxin', 
                                            'Golden Gorget of Leoric',
                                            'Hellfire Amulet'))
WHERE UserId = (SELECT Id FROM Users WHERE Username = 'Alex')
AND GameId = (SELECT Id FROM Games WHERE Name = 'Edinburgh')

SELECT
    u.Username, g.Name, ug.Cash, i.Name AS [Item Name]
FROM Games AS g
    JOIN UsersGames AS ug ON ug.GameId = g.Id
    JOIN Users AS u ON ug.UserId = u.Id
    JOIN UserGameItems AS ugi ON ug.Id = ugi.UserGameId
    JOIN Items AS i ON ugi.ItemId = i.Id
WHERE g.Name = 'Edinburgh'
ORDER BY i.Name 