/* List of busy/occupied tables */
USE Restaurant

SELECT t.Id AS TableNumber, os.[Name] AS [OrderStatus]
FROM [Tables] AS t
INNER JOIN Orders AS o
	ON t.Id = o.[Table]
INNER JOIN OrderStatuses AS os
	ON o.[Status] = os.Id
WHERE o.[Status] = 1;






