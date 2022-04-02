/* Search by part of product name - select all matching products */
USE Restaurant

SELECT p.[Name] 
FROM Products AS p
WHERE [Name] LIKE '%ke%'
ORDER BY [Name];