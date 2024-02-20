SELECT
    cu.CurrencyCode,
    cu.Description AS Currency,
    COUNT(c.CountryCode) AS NumberOfCountries
FROM Currencies AS cu
    LEFT JOIN Countries AS c ON cu.CurrencyCode = c.CurrencyCode
GROUP BY cu.CurrencyCode, cu.Description
ORDER BY NumberOfCountries DESC, Currency