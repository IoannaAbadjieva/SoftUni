SELECT
    i.Name as Item, i.Price, i.MinLevel, gt.Name  AS [Forbidden Game Type]
FROM Items AS i
    LEFT JOIN GameTypeForbiddenItems AS fb ON i.Id = fb.ItemId
    LEFT JOIN GameTypes AS gt ON fb.GameTypeId = gt.Id
ORDER BY gt.Name DESC, i.Name 